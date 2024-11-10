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
/// Genesis<Conway>
/// </summary>
/// <remarks>
/// <para>
/// An Conway genesis configuration, with information used to bootstrap the era. Some parameters are also updatable across the era.
/// </para>
/// </remarks>
public readonly partial struct GenesisConway
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    public readonly partial struct UpdatableParametersEntity
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
                result = result.PushSchemaLocation("Ogmios/Generated/cardano.json#/definitions/Genesis<Conway>/properties/updatableParameters");
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
                in UpdatableParametersEntity value,
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

                bool hasSeenConstitutionalCommitteeMaxTermLength = false;
                bool hasSeenConstitutionalCommitteeMinSize = false;
                bool hasSeenDelegateRepresentativeDeposit = false;
                bool hasSeenDelegateRepresentativeMaxIdleTime = false;
                bool hasSeenDelegateRepresentativeVotingThresholds = false;
                bool hasSeenGovernanceActionDeposit = false;
                bool hasSeenGovernanceActionLifetime = false;
                bool hasSeenStakePoolVotingThresholds = false;

                int propertyCount = 0;
                foreach (JsonObjectProperty property in value.EnumerateObject())
                {
                    string? propertyNameAsString = null;

                    if (property.NameEquals(JsonPropertyNames.ConstitutionalCommitteeMaxTermLengthUtf8, JsonPropertyNames.ConstitutionalCommitteeMaxTermLength))
                    {
                        hasSeenConstitutionalCommitteeMaxTermLength = true;
                        result = result.WithLocalProperty(propertyCount);
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/constitutionalCommitteeMaxTermLength/$ref"), JsonPropertyNames.ConstitutionalCommitteeMaxTermLength);
                        }

                        ValidationContext propertyResult = property.Value.As<Generated.UInt64>().Validate(result.CreateChildContext(), level);
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
                    else if (property.NameEquals(JsonPropertyNames.ConstitutionalCommitteeMinSizeUtf8, JsonPropertyNames.ConstitutionalCommitteeMinSize))
                    {
                        hasSeenConstitutionalCommitteeMinSize = true;
                        result = result.WithLocalProperty(propertyCount);
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/constitutionalCommitteeMinSize/$ref"), JsonPropertyNames.ConstitutionalCommitteeMinSize);
                        }

                        ValidationContext propertyResult = property.Value.As<Generated.UInt64>().Validate(result.CreateChildContext(), level);
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
                    else if (property.NameEquals(JsonPropertyNames.DelegateRepresentativeDepositUtf8, JsonPropertyNames.DelegateRepresentativeDeposit))
                    {
                        hasSeenDelegateRepresentativeDeposit = true;
                        result = result.WithLocalProperty(propertyCount);
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/delegateRepresentativeDeposit/$ref"), JsonPropertyNames.DelegateRepresentativeDeposit);
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
                    else if (property.NameEquals(JsonPropertyNames.DelegateRepresentativeMaxIdleTimeUtf8, JsonPropertyNames.DelegateRepresentativeMaxIdleTime))
                    {
                        hasSeenDelegateRepresentativeMaxIdleTime = true;
                        result = result.WithLocalProperty(propertyCount);
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/delegateRepresentativeMaxIdleTime/$ref"), JsonPropertyNames.DelegateRepresentativeMaxIdleTime);
                        }

                        ValidationContext propertyResult = property.Value.As<Generated.Epoch>().Validate(result.CreateChildContext(), level);
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
                    else if (property.NameEquals(JsonPropertyNames.DelegateRepresentativeVotingThresholdsUtf8, JsonPropertyNames.DelegateRepresentativeVotingThresholds))
                    {
                        hasSeenDelegateRepresentativeVotingThresholds = true;
                        result = result.WithLocalProperty(propertyCount);
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/delegateRepresentativeVotingThresholds/$ref"), JsonPropertyNames.DelegateRepresentativeVotingThresholds);
                        }

                        ValidationContext propertyResult = property.Value.As<Generated.DelegateRepresentativeVotingThresholds>().Validate(result.CreateChildContext(), level);
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
                    else if (property.NameEquals(JsonPropertyNames.GovernanceActionDepositUtf8, JsonPropertyNames.GovernanceActionDeposit))
                    {
                        hasSeenGovernanceActionDeposit = true;
                        result = result.WithLocalProperty(propertyCount);
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/governanceActionDeposit/$ref"), JsonPropertyNames.GovernanceActionDeposit);
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
                    else if (property.NameEquals(JsonPropertyNames.GovernanceActionLifetimeUtf8, JsonPropertyNames.GovernanceActionLifetime))
                    {
                        hasSeenGovernanceActionLifetime = true;
                        result = result.WithLocalProperty(propertyCount);
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/governanceActionLifetime/$ref"), JsonPropertyNames.GovernanceActionLifetime);
                        }

                        ValidationContext propertyResult = property.Value.As<Generated.Epoch>().Validate(result.CreateChildContext(), level);
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
                    else if (property.NameEquals(JsonPropertyNames.StakePoolVotingThresholdsUtf8, JsonPropertyNames.StakePoolVotingThresholds))
                    {
                        hasSeenStakePoolVotingThresholds = true;
                        result = result.WithLocalProperty(propertyCount);
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/stakePoolVotingThresholds/$ref"), JsonPropertyNames.StakePoolVotingThresholds);
                        }

                        ValidationContext propertyResult = property.Value.As<Generated.StakePoolVotingThresholds>().Validate(result.CreateChildContext(), level);
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

                if (!hasSeenConstitutionalCommitteeMaxTermLength)
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation properties - the required property 'constitutionalCommitteeMaxTermLength' was not present.");
                    }
                    else
                    {
                        return ValidationContext.InvalidContext;
                    }
                }
                else if (level == ValidationLevel.Verbose)
                {
                    result = result.WithResult(isValid: true, "Validation properties - the required property 'constitutionalCommitteeMaxTermLength' was present.");
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PopLocation();
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PushValidationLocationReducedPathModifier(new("#/required/1"));
                }

                if (!hasSeenConstitutionalCommitteeMinSize)
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation properties - the required property 'constitutionalCommitteeMinSize' was not present.");
                    }
                    else
                    {
                        return ValidationContext.InvalidContext;
                    }
                }
                else if (level == ValidationLevel.Verbose)
                {
                    result = result.WithResult(isValid: true, "Validation properties - the required property 'constitutionalCommitteeMinSize' was present.");
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PopLocation();
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PushValidationLocationReducedPathModifier(new("#/required/6"));
                }

                if (!hasSeenDelegateRepresentativeDeposit)
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation properties - the required property 'delegateRepresentativeDeposit' was not present.");
                    }
                    else
                    {
                        return ValidationContext.InvalidContext;
                    }
                }
                else if (level == ValidationLevel.Verbose)
                {
                    result = result.WithResult(isValid: true, "Validation properties - the required property 'delegateRepresentativeDeposit' was present.");
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PopLocation();
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PushValidationLocationReducedPathModifier(new("#/required/7"));
                }

                if (!hasSeenDelegateRepresentativeMaxIdleTime)
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation properties - the required property 'delegateRepresentativeMaxIdleTime' was not present.");
                    }
                    else
                    {
                        return ValidationContext.InvalidContext;
                    }
                }
                else if (level == ValidationLevel.Verbose)
                {
                    result = result.WithResult(isValid: true, "Validation properties - the required property 'delegateRepresentativeMaxIdleTime' was present.");
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PopLocation();
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PushValidationLocationReducedPathModifier(new("#/required/5"));
                }

                if (!hasSeenDelegateRepresentativeVotingThresholds)
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation properties - the required property 'delegateRepresentativeVotingThresholds' was not present.");
                    }
                    else
                    {
                        return ValidationContext.InvalidContext;
                    }
                }
                else if (level == ValidationLevel.Verbose)
                {
                    result = result.WithResult(isValid: true, "Validation properties - the required property 'delegateRepresentativeVotingThresholds' was present.");
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PopLocation();
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PushValidationLocationReducedPathModifier(new("#/required/4"));
                }

                if (!hasSeenGovernanceActionDeposit)
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation properties - the required property 'governanceActionDeposit' was not present.");
                    }
                    else
                    {
                        return ValidationContext.InvalidContext;
                    }
                }
                else if (level == ValidationLevel.Verbose)
                {
                    result = result.WithResult(isValid: true, "Validation properties - the required property 'governanceActionDeposit' was present.");
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PopLocation();
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PushValidationLocationReducedPathModifier(new("#/required/3"));
                }

                if (!hasSeenGovernanceActionLifetime)
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation properties - the required property 'governanceActionLifetime' was not present.");
                    }
                    else
                    {
                        return ValidationContext.InvalidContext;
                    }
                }
                else if (level == ValidationLevel.Verbose)
                {
                    result = result.WithResult(isValid: true, "Validation properties - the required property 'governanceActionLifetime' was present.");
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PopLocation();
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PushValidationLocationReducedPathModifier(new("#/required/0"));
                }

                if (!hasSeenStakePoolVotingThresholds)
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation properties - the required property 'stakePoolVotingThresholds' was not present.");
                    }
                    else
                    {
                        return ValidationContext.InvalidContext;
                    }
                }
                else if (level == ValidationLevel.Verbose)
                {
                    result = result.WithResult(isValid: true, "Validation properties - the required property 'stakePoolVotingThresholds' was present.");
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PopLocation();
                }

                return result;
            }
        }
    }
}
