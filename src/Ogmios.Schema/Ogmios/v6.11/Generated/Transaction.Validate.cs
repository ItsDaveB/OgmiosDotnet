//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Corvus.Json;

namespace Generated;
/// <summary>
/// Transaction
/// </summary>
public readonly partial struct Transaction
{
    /// <inheritdoc/>
    public ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
    {
        ValidationContext result = validationContext;
        if (level > ValidationLevel.Flag && !result.IsUsingResults)
        {
            result = result.UsingResults();
        }

        if (level > ValidationLevel.Basic)
        {
            if (!result.IsUsingStack)
            {
                result = result.UsingStack();
            }

            result = result.PushSchemaLocation("OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/cardano.json#/definitions/Transaction");
        }

        JsonValueKind valueKind = this.ValueKind;
        if (!result.IsUsingEvaluatedProperties)
        {
            result = result.UsingEvaluatedProperties();
        }

        result = CorvusValidation.TypeValidationHandler(valueKind, result, level);

        if (level == ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }

        result = CorvusValidation.ObjectValidationHandler(this, valueKind, result, level);

        if (level == ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }

        if (level > ValidationLevel.Basic)
        {
            result = result.PopLocation();
        }

        return result;
    }

    /// <summary>
    /// Validation constants for the type.
    /// </summary>
    public static partial class CorvusValidation
    {
        /// <summary>
        /// Core type validation.
        /// </summary>
        /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
        /// <param name="validationContext">The current validation context.</param>
        /// <param name="level">The current validation level.</param>
        /// <returns>The resulting validation context after validation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValidationContext TypeValidationHandler(
            JsonValueKind valueKind,
            in ValidationContext validationContext,
            ValidationLevel level = ValidationLevel.Flag)
        {
            return Corvus.Json.ValidateWithoutCoreType.TypeObject(valueKind, validationContext, level, "type");
        }

        /// <summary>
        /// Object validation.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
        /// <param name="validationContext">The current validation context.</param>
        /// <param name="level">The current validation level.</param>
        /// <returns>The resulting validation context after validation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValidationContext ObjectValidationHandler(
            in Transaction value,
            JsonValueKind valueKind,
            in ValidationContext validationContext,
            ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext;
            if (valueKind != JsonValueKind.Object)
            {
                if (level == ValidationLevel.Verbose)
                {
                    ValidationContext ignoredResult = validationContext;
                    ignoredResult = ignoredResult.WithResult(isValid: true, "Validation additionalProperties - ignored because the value is not an object", "additionalProperties");
                    ignoredResult = ignoredResult.WithResult(isValid: true, "Validation properties - ignored because the value is not an object", "properties");
                    ignoredResult = ignoredResult.WithResult(isValid: true, "Validation required - ignored because the value is not an object", "required");

                    return ignoredResult;
                }

                return validationContext;
            }

            bool hasSeenId = false;
            bool hasSeenInputs = false;
            bool hasSeenOutputs = false;
            bool hasSeenSignatories = false;
            bool hasSeenSpends = false;

            int propertyCount = 0;
            foreach (JsonObjectProperty property in value.EnumerateObject())
            {
                string? propertyNameAsString = null;

                if (property.NameEquals(JsonPropertyNames.CborUtf8, JsonPropertyNames.Cbor))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/cbor"), JsonPropertyNames.Cbor);
                    }

                    ValidationContext propertyResult = property.Value.As<Corvus.Json.JsonString>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.CertificatesUtf8, JsonPropertyNames.Certificates))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/certificates"), JsonPropertyNames.Certificates);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.CertificateArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.CollateralReturnUtf8, JsonPropertyNames.CollateralReturn))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/collateralReturn/$ref"), JsonPropertyNames.CollateralReturn);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.TransactionOutput>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.CollateralsUtf8, JsonPropertyNames.Collaterals))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/collaterals"), JsonPropertyNames.Collaterals);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.TransactionOutputReferenceArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.DatumsUtf8, JsonPropertyNames.Datums))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/datums"), JsonPropertyNames.Datums);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.DatumsEntity>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.FeeUtf8, JsonPropertyNames.Fee))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/fee/$ref"), JsonPropertyNames.Fee);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.ValueAdaOnly>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.IdUtf8, JsonPropertyNames.Id))
                {
                    hasSeenId = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/id/$ref"), JsonPropertyNames.Id);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.DigestBlake2b256>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.InputsUtf8, JsonPropertyNames.Inputs))
                {
                    hasSeenInputs = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/inputs"), JsonPropertyNames.Inputs);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.InputsTransactionOutputRefArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.MetadataUtf8, JsonPropertyNames.Metadata))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/metadata/$ref"), JsonPropertyNames.Metadata);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Metadata>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.MintUtf8, JsonPropertyNames.Mint))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/mint/$ref"), JsonPropertyNames.Mint);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Assets>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.NetworkUtf8, JsonPropertyNames.Network))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/network/$ref"), JsonPropertyNames.Network);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Network>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.OutputsUtf8, JsonPropertyNames.Outputs))
                {
                    hasSeenOutputs = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/outputs"), JsonPropertyNames.Outputs);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.TransactionOutputArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.ProposalsUtf8, JsonPropertyNames.Proposals))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/proposals"), JsonPropertyNames.Proposals);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.GovernanceProposalArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.RedeemersUtf8, JsonPropertyNames.Redeemers))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/redeemers"), JsonPropertyNames.Redeemers);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.RedeemerArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.ReferencesUtf8, JsonPropertyNames.References))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/references"), JsonPropertyNames.References);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.ReferencesTransactionOutpuArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.RequiredExtraScriptsUtf8, JsonPropertyNames.RequiredExtraScripts))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/requiredExtraScripts"), JsonPropertyNames.RequiredExtraScripts);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.DigestBlake2b224Array>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.RequiredExtraSignatoriesUtf8, JsonPropertyNames.RequiredExtraSignatories))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/requiredExtraSignatories"), JsonPropertyNames.RequiredExtraSignatories);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.RequiredExtraSigArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.ScriptIntegrityHashUtf8, JsonPropertyNames.ScriptIntegrityHash))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/scriptIntegrityHash/$ref"), JsonPropertyNames.ScriptIntegrityHash);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.DigestBlake2b256>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.ScriptsUtf8, JsonPropertyNames.Scripts))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/scripts"), JsonPropertyNames.Scripts);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.ScriptsEntity>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.SignatoriesUtf8, JsonPropertyNames.Signatories))
                {
                    hasSeenSignatories = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/signatories"), JsonPropertyNames.Signatories);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.SignatoryArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.SpendsUtf8, JsonPropertyNames.Spends))
                {
                    hasSeenSpends = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/spends/$ref"), JsonPropertyNames.Spends);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.InputSource>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.TotalCollateralUtf8, JsonPropertyNames.TotalCollateral))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/totalCollateral/$ref"), JsonPropertyNames.TotalCollateral);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.ValueAdaOnly>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.TreasuryUtf8, JsonPropertyNames.Treasury))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/treasury"), JsonPropertyNames.Treasury);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.TreasuryEntity>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.ValidityIntervalUtf8, JsonPropertyNames.ValidityInterval))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/validityInterval/$ref"), JsonPropertyNames.ValidityInterval);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.ValidityInterval>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.VotesUtf8, JsonPropertyNames.Votes))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/votes"), JsonPropertyNames.Votes);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Transaction.GovernanceVoteArray>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                else if (property.NameEquals(JsonPropertyNames.WithdrawalsUtf8, JsonPropertyNames.Withdrawals))
                {
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/withdrawals/$ref"), JsonPropertyNames.Withdrawals);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Withdrawals>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }
                }
                if (!result.HasEvaluatedLocalProperty(propertyCount))
                {
                    if (level > ValidationLevel.Basic)
                    {
                        string localEvaluatedPropertyName = (propertyNameAsString ??= property.Name.GetString());
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new JsonReference("#/additionalProperties").AppendUnencodedPropertyNameToFragment(localEvaluatedPropertyName), localEvaluatedPropertyName);
                    }

                    ValidationContext propertyResult = property.Value.As<Corvus.Json.JsonNotAny>().Validate(result.CreateChildContext(), level);
                    if (level == ValidationLevel.Flag && !propertyResult.IsValid)
                    {
                        return propertyResult;
                    }

                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);

                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }

                    result = result.WithLocalProperty(propertyCount);
                }

                propertyCount++;
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/0"));
            }

            if (!hasSeenId)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'id' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'id' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/2"));
            }

            if (!hasSeenInputs)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'inputs' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'inputs' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/3"));
            }

            if (!hasSeenOutputs)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'outputs' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'outputs' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/4"));
            }

            if (!hasSeenSignatories)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'signatories' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'signatories' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/1"));
            }

            if (!hasSeenSpends)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'spends' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'spends' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            return result;
        }
    }
}
