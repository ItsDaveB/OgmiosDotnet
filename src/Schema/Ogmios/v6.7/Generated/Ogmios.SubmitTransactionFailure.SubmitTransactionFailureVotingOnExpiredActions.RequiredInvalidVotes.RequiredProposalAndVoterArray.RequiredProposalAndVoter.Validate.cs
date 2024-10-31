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
/// ogmios
/// </summary>
public readonly partial struct Ogmios
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    public readonly partial struct SubmitTransactionFailure
    {
        /// <summary>
        /// SubmitTransactionFailure<VotingOnExpiredActions>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The transaction contains votes for an expired proposal. The field 'data.invalidVotes' indicates the faulty voters and the proposal they attempted to vote for.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureVotingOnExpiredActions
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct RequiredInvalidVotes
            {
                /// <summary>
                /// Generated from JSON Schema.
                /// </summary>
                public readonly partial struct RequiredProposalAndVoterArray
                {
                    /// <summary>
                    /// Generated from JSON Schema.
                    /// </summary>
                    public readonly partial struct RequiredProposalAndVoter
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
                                result = result.PushSchemaLocation("https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Domain/Schemas/Ogmios/Generated/ogmios.json#/definitions/SubmitTransactionFailure/oneOf/61/properties/data/properties/invalidVotes/items");
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
                                in RequiredProposalAndVoter value,
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

                                bool hasSeenProposal = false;
                                bool hasSeenVoter = false;

                                int propertyCount = 0;
                                foreach (JsonObjectProperty property in value.EnumerateObject())
                                {
                                    string? propertyNameAsString = null;

                                    if (property.NameEquals(JsonPropertyNames.ProposalUtf8, JsonPropertyNames.Proposal))
                                    {
                                        hasSeenProposal = true;
                                        result = result.WithLocalProperty(propertyCount);
                                        if (level > ValidationLevel.Basic)
                                        {
                                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/proposal/$ref"), JsonPropertyNames.Proposal);
                                        }

                                        ValidationContext propertyResult = property.Value.As<Generated.GovernanceProposalReference>().Validate(result.CreateChildContext(), level);
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
                                    else if (property.NameEquals(JsonPropertyNames.VoterUtf8, JsonPropertyNames.Voter))
                                    {
                                        hasSeenVoter = true;
                                        result = result.WithLocalProperty(propertyCount);
                                        if (level > ValidationLevel.Basic)
                                        {
                                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/voter/$ref"), JsonPropertyNames.Voter);
                                        }

                                        ValidationContext propertyResult = property.Value.As<Generated.GovernanceVoter>().Validate(result.CreateChildContext(), level);
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
                                    result = result.PushValidationLocationReducedPathModifier(new("#/required/0"));
                                }

                                if (!hasSeenProposal)
                                {
                                    if (level >= ValidationLevel.Basic)
                                    {
                                        result = result.WithResult(isValid: false, "Validation properties - the required property 'proposal' was not present.");
                                    }
                                    else
                                    {
                                        return ValidationContext.InvalidContext;
                                    }
                                }
                                else if (level == ValidationLevel.Verbose)
                                {
                                    result = result.WithResult(isValid: true, "Validation properties - the required property 'proposal' was present.");
                                }

                                if (level > ValidationLevel.Basic)
                                {
                                    result = result.PopLocation();
                                }

                                if (level > ValidationLevel.Basic)
                                {
                                    result = result.PushValidationLocationReducedPathModifier(new("#/required/1"));
                                }

                                if (!hasSeenVoter)
                                {
                                    if (level >= ValidationLevel.Basic)
                                    {
                                        result = result.WithResult(isValid: false, "Validation properties - the required property 'voter' was not present.");
                                    }
                                    else
                                    {
                                        return ValidationContext.InvalidContext;
                                    }
                                }
                                else if (level == ValidationLevel.Verbose)
                                {
                                    result = result.WithResult(isValid: true, "Validation properties - the required property 'voter' was present.");
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
            }
        }
    }
}
