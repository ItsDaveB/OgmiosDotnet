using System.Text.Json;

namespace Ogmios.Services.TransactionSubmission
{
    internal static class EvaluateTransactionFailureFormatter
    {
        public static bool TryGetLabel(int code, out string? label) => CodeMap.TryGetValue(code, out label);

        public static string Format(Generated.Ogmios.EvaluateTransactionFailure failure, string rawJson)
        {
            try
            {
                JsonElement elem = failure.AsJsonElement;

                if (elem.ValueKind == JsonValueKind.Object)
                {
                    if (elem.TryGetProperty("message", out JsonElement messageProp) && messageProp.ValueKind == JsonValueKind.String)
                    {
                        return messageProp.GetString() ?? elem.ToString();
                    }

                    if (elem.TryGetProperty("objectUid", out JsonElement uidProp))
                    {
                        return $"Failure {uidProp.GetRawText()}: {GetShortData(elem)}";
                    }

                    if (elem.TryGetProperty("code", out JsonElement codeProp))
                    {
                        return $"Failure code {codeProp.GetRawText()}: {GetShortData(elem)}";
                    }

                    if (elem.TryGetProperty("validator", out JsonElement validatorProp) && elem.TryGetProperty("budget", out JsonElement budgetProp))
                    {
                        return $"validator: {validatorProp.GetRawText()}, budget: {GetShortData(budgetProp)}";
                    }

                    return GetShortData(elem);
                }

                switch (elem.ValueKind)
                {
                    case JsonValueKind.Array: return FormatArray(elem);
                    case JsonValueKind.String:
                    case JsonValueKind.Number:
                    case JsonValueKind.True:
                    case JsonValueKind.False:
                    case JsonValueKind.Null:
                        return elem.GetRawText();
                    default:
                        return elem.ToString();
                }
            }
            catch
            {
                return rawJson ?? "<no response>";
            }
        }

        private static string FormatArray(JsonElement array)
        {
            var items = new List<string>();
            var i = 0;
            foreach (var el in array.EnumerateArray())
            {
                if (i++ >= 4) break;
                items.Add(el.ValueKind == JsonValueKind.Object ? GetShortData(el) : el.GetRawText());
            }

            var joined = string.Join(", ", items);
            if (array.GetArrayLength() > 4) joined += ", ...";
            return $"[{joined}]";
        }

        private static string GetShortData(JsonElement elem)
        {
            if (elem.TryGetProperty("data", out JsonElement dataProp))
            {
                try
                {
                    switch (dataProp.ValueKind)
                    {
                        case JsonValueKind.Object:
                            {
                                var names = new List<string>();
                                foreach (var p in dataProp.EnumerateObject())
                                {
                                    names.Add(p.Name);
                                    if (names.Count >= 6) break;
                                }
                                return $"data: [{string.Join(", ", names)}]";
                            }
                        case JsonValueKind.Array:
                            {
                                var count = dataProp.GetArrayLength();
                                var first = new List<string>();
                                var j = 0;
                                foreach (var a in dataProp.EnumerateArray())
                                {
                                    if (j++ >= 3) break;
                                    first.Add(a.ValueKind == JsonValueKind.Object ? GetShortData(a) : a.GetRawText());
                                }
                                var joined = string.Join(", ", first);
                                if (count > 3) joined += ", ...";
                                return $"data: [{joined}]";
                            }
                        default:
                            return dataProp.GetRawText();
                    }
                }
                catch
                {
                    return elem.ToString();
                }
            }

            var raw = elem.ToString();
            if (raw.Length > 400) return raw.Substring(0, 400) + "...";
            return raw;
        }

        private static readonly Dictionary<int, string> CodeMap = new()
        {
            {3000, "IncompatibleEra"}, {3001, "UnsupportedEra"}, {3002, "OverlappingAdditionalUtxo"}, {3003, "NodeTipTooOld"}, {3004, "CannotCreateEvaluationContext"}, {3005, "EraMismatch"},
            {3010, "ScriptExecutionFailure"}, {3011, "InvalidRedeemerPointers"}, {3012, "ValidationFailure"}, {3013, "UnsuitableOutputReference"}, {3100, "InvalidSignatories"},
            {3101, "MissingSignatories"}, {3102, "MissingScripts"}, {3103, "FailingNativeScript"}, {3104, "ExtraneousScripts"}, {3105, "MissingMetadataHash"}, {3106, "MissingMetadata"},
            {3107, "MetadataHashMismatch"}, {3108, "InvalidMetadata"}, {3109, "MissingRedeemers"}, {3110, "ExtraneousRedeemers"}, {3111, "MissingDatums"}, {3112, "ExtraneousDatums"},
            {3113, "ScriptIntegrityHashMismatch"}, {3114, "OrphanScriptInputs"}, {3115, "MissingCostModels"}, {3116, "MalformedScripts"}, {3117, "UnknownOutputReference"},
            {3118, "OutsideOfValidityInterval"}, {3119, "TransactionTooLarge"}, {3120, "ValueTooLarge"}, {3121, "EmptyInputSet"}, {3122, "FeeTooSmall"}, {3123, "ValueNotConserved"},
            {3124, "NetworkMismatch"}, {3125, "InsufficientlyFundedOutputs"}, {3126, "BootstrapAttributesTooLarge"}, {3127, "MintingOrBurningAda"}, {3128, "InsufficientCollateral"},
            {3129, "CollateralLockedByScript"}, {3130, "UnforeseeableSlot"}, {3131, "TooManyCollateralInputs"}, {3132, "MissingCollateralInputs"}, {3133, "NonAdaCollateral"},
            {3134, "ExecutionUnitsTooLarge"}, {3135, "TotalCollateralMismatch"}, {3136, "SpendsMismatch"}, {3137, "UnauthorizedVotes"}, {3138, "UnknownGovernanceProposals"},
            {3139, "InvalidProtocolParametersUpdate"}, {3140, "UnknownStakePool"}, {3141, "IncompleteWithdrawals"}, {3142, "RetirementTooLate"}, {3143, "StakePoolCostTooLow"},
            {3144, "MetadataHashTooLarge"}, {3145, "CredentialAlreadyRegistered"}, {3146, "UnknownCredential"}, {3147, "NonEmptyRewardAccount"}, {3148, "InvalidGenesisDelegation"},
            {3149, "InvalidMIRTransfer"}, {3150, "ForbiddenWithdrawal"}, {3151, "CredentialDepositMismatch"}, {3152, "DRepAlreadyRegistered"}, {3153, "DRepNotRegistered"},
            {3154, "UnknownConstitutionalCommitteeMember"}, {3155, "GovernanceProposalDepositMismatch"}, {3156, "ConflictingCommitteeUpdate"}, {3157, "InvalidCommitteeUpdate"},
            {3158, "TreasuryWithdrawalMismatch"}, {3159, "InvalidOrMissingPreviousProposals"}, {3160, "VotingOnExpiredActions"}, {3161, "ExecutionBudgetOutOfBounds"},
            {3162, "InvalidHardForkVersionBump"}, {3163, "ConstitutionGuardrailsHashMismatch"}, {3164, "ConflictingInputsAndReferences"}, {3165, "UnauthorizedGovernanceAction"},
            {3166, "ReferenceScriptsTooLarge"}, {3167, "UnknownVoters"}, {3168, "EmptyTreasuryWithdrawal"}, {3997, "UnexpectedMempoolError"}, {3998, "UnrecognizedCertificateType"}
        };
    }
}
