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
/// DelegateRepresentativeVotingThresholds
/// </summary>
public readonly partial struct DelegateRepresentativeVotingThresholds
{
    /// <inheritdoc/>
    public ValidationContext Validate(in ValidationContext validationContext, ValidationLevel level = ValidationLevel.Flag)
    {
        ValidationContext result = validationContext;
        if (level > ValidationLevel.Flag)
        {
            result = result.UsingResults();
        }

        if (level > ValidationLevel.Basic)
        {
            result = result.UsingStack();
            result = result.PushSchemaLocation("https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Domain/Schemas/Ogmios/Generated/cardano.json#/definitions/DelegateRepresentativeVotingThresholds");
        }

        JsonValueKind valueKind = this.ValueKind;
        result = result.UsingEvaluatedProperties();

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
            in DelegateRepresentativeVotingThresholds value,
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

            bool hasSeenConstitution = false;
            bool hasSeenConstitutionalCommittee = false;
            bool hasSeenHardForkInitiation = false;
            bool hasSeenNoConfidence = false;
            bool hasSeenProtocolParametersUpdate = false;
            bool hasSeenTreasuryWithdrawals = false;

            int propertyCount = 0;
            foreach (JsonObjectProperty property in value.EnumerateObject())
            {
                string? propertyNameAsString = null;

                if (property.NameEquals(JsonPropertyNames.ConstitutionUtf8, JsonPropertyNames.Constitution))
                {
                    hasSeenConstitution = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/constitution/$ref"), JsonPropertyNames.Constitution);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Ratio>().Validate(result.CreateChildContext(), level);
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
                else if (property.NameEquals(JsonPropertyNames.ConstitutionalCommitteeUtf8, JsonPropertyNames.ConstitutionalCommittee))
                {
                    hasSeenConstitutionalCommittee = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/constitutionalCommittee"), JsonPropertyNames.ConstitutionalCommittee);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.DelegateRepresentativeVotingThresholds.RequiredDefaultAndStateOfNoConfidence>().Validate(result.CreateChildContext(), level);
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
                else if (property.NameEquals(JsonPropertyNames.HardForkInitiationUtf8, JsonPropertyNames.HardForkInitiation))
                {
                    hasSeenHardForkInitiation = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/hardForkInitiation/$ref"), JsonPropertyNames.HardForkInitiation);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Ratio>().Validate(result.CreateChildContext(), level);
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
                else if (property.NameEquals(JsonPropertyNames.NoConfidenceUtf8, JsonPropertyNames.NoConfidence))
                {
                    hasSeenNoConfidence = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/noConfidence/$ref"), JsonPropertyNames.NoConfidence);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Ratio>().Validate(result.CreateChildContext(), level);
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
                else if (property.NameEquals(JsonPropertyNames.ProtocolParametersUpdateUtf8, JsonPropertyNames.ProtocolParametersUpdate))
                {
                    hasSeenProtocolParametersUpdate = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/protocolParametersUpdate"), JsonPropertyNames.ProtocolParametersUpdate);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.DelegateRepresentativeVotingThresholds.RequiredEconomicAndGovernanceAndNetworkAndTechnical>().Validate(result.CreateChildContext(), level);
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
                else if (property.NameEquals(JsonPropertyNames.TreasuryWithdrawalsUtf8, JsonPropertyNames.TreasuryWithdrawals))
                {
                    hasSeenTreasuryWithdrawals = true;
                    result = result.WithLocalProperty(propertyCount);
                    if (level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/treasuryWithdrawals/$ref"), JsonPropertyNames.TreasuryWithdrawals);
                    }

                    ValidationContext propertyResult = property.Value.As<Generated.Ratio>().Validate(result.CreateChildContext(), level);
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

                    result = property.Value.As<Corvus.Json.JsonNotAny>().Validate(result, level);
                    if (level == ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }

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
                result = result.PushValidationLocationReducedPathModifier(new("#/required/2"));
            }

            if (!hasSeenConstitution)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'constitution' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'constitution' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/1"));
            }

            if (!hasSeenConstitutionalCommittee)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'constitutionalCommittee' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'constitutionalCommittee' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/3"));
            }

            if (!hasSeenHardForkInitiation)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'hardForkInitiation' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'hardForkInitiation' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/0"));
            }

            if (!hasSeenNoConfidence)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'noConfidence' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'noConfidence' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/4"));
            }

            if (!hasSeenProtocolParametersUpdate)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'protocolParametersUpdate' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'protocolParametersUpdate' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PushValidationLocationReducedPathModifier(new("#/required/5"));
            }

            if (!hasSeenTreasuryWithdrawals)
            {
                if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation properties - the required property 'treasuryWithdrawals' was not present.");
                }
                else
                {
                    return ValidationContext.InvalidContext;
                }
            }
            else if (level == ValidationLevel.Verbose)
            {
                result = result.WithResult(isValid: true, "Validation properties - the required property 'treasuryWithdrawals' was present.");
            }

            if (level > ValidationLevel.Basic)
            {
                result = result.PopLocation();
            }

            return result;
        }
    }
}