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
        /// SubmitTransactionFailure<NetworkMismatch>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Some discriminated entities in the transaction are configured for another network. In fact, payment addresses, stake addresses and stake pool registration certificates are bound to a specific network identifier. This identifier must match the network you're trying to submit them to. Since the Alonzo era, transactions themselves may also contain a network identifier. The field 'data.expectedNetwork' indicates what is the currrently expected network. The field 'data.discriminatedType' indicates what type of entity is causing an issue here. And 'data.invalidEntities' lists all the culprits found in the transaction. The latter isn't present when the transaction's network identifier itself is wrong.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureNetworkMismatch
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct DataEntity
            {
                /// <summary>
                /// Generated from JSON Schema.
                /// </summary>
                public readonly partial struct DataEntityRequiredDiscriminatedTypeAndExpectedNetworkAndInvalidEntities
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
                            result = result.PushSchemaLocation("Ogmios/Generated/ogmios.json#/definitions/SubmitTransactionFailure/oneOf/25/properties/data/oneOf/1");
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
                            in DataEntityRequiredDiscriminatedTypeAndExpectedNetworkAndInvalidEntities value,
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

                            bool hasSeenDiscriminatedType = false;
                            bool hasSeenExpectedNetwork = false;
                            bool hasSeenInvalidEntities = false;

                            int propertyCount = 0;
                            foreach (JsonObjectProperty property in value.EnumerateObject())
                            {
                                string? propertyNameAsString = null;

                                if (property.NameEquals(JsonPropertyNames.DiscriminatedTypeUtf8, JsonPropertyNames.DiscriminatedType))
                                {
                                    hasSeenDiscriminatedType = true;
                                    result = result.WithLocalProperty(propertyCount);
                                    if (level > ValidationLevel.Basic)
                                    {
                                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/discriminatedType"), JsonPropertyNames.DiscriminatedType);
                                    }

                                    ValidationContext propertyResult = property.Value.As<Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureNetworkMismatch.DataEntity.DataEntityRequiredDiscriminatedTypeAndExpectedNetworkAndInvalidEntities.DiscriminatedTypeEntity>().Validate(result.CreateChildContext(), level);
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
                                else if (property.NameEquals(JsonPropertyNames.ExpectedNetworkUtf8, JsonPropertyNames.ExpectedNetwork))
                                {
                                    hasSeenExpectedNetwork = true;
                                    result = result.WithLocalProperty(propertyCount);
                                    if (level > ValidationLevel.Basic)
                                    {
                                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/expectedNetwork/$ref"), JsonPropertyNames.ExpectedNetwork);
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
                                else if (property.NameEquals(JsonPropertyNames.InvalidEntitiesUtf8, JsonPropertyNames.InvalidEntities))
                                {
                                    hasSeenInvalidEntities = true;
                                    result = result.WithLocalProperty(propertyCount);
                                    if (level > ValidationLevel.Basic)
                                    {
                                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/invalidEntities"), JsonPropertyNames.InvalidEntities);
                                    }

                                    ValidationContext propertyResult = property.Value.As<Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureNetworkMismatch.DataEntity.DataEntityRequiredDiscriminatedTypeAndExpectedNetworkAndInvalidEntities.RewardAccountArray>().Validate(result.CreateChildContext(), level);
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
                                result = result.PushValidationLocationReducedPathModifier(new("#/required/1"));
                            }

                            if (!hasSeenDiscriminatedType)
                            {
                                if (level >= ValidationLevel.Basic)
                                {
                                    result = result.WithResult(isValid: false, "Validation properties - the required property 'discriminatedType' was not present.");
                                }
                                else
                                {
                                    return ValidationContext.InvalidContext;
                                }
                            }
                            else if (level == ValidationLevel.Verbose)
                            {
                                result = result.WithResult(isValid: true, "Validation properties - the required property 'discriminatedType' was present.");
                            }

                            if (level > ValidationLevel.Basic)
                            {
                                result = result.PopLocation();
                            }

                            if (level > ValidationLevel.Basic)
                            {
                                result = result.PushValidationLocationReducedPathModifier(new("#/required/0"));
                            }

                            if (!hasSeenExpectedNetwork)
                            {
                                if (level >= ValidationLevel.Basic)
                                {
                                    result = result.WithResult(isValid: false, "Validation properties - the required property 'expectedNetwork' was not present.");
                                }
                                else
                                {
                                    return ValidationContext.InvalidContext;
                                }
                            }
                            else if (level == ValidationLevel.Verbose)
                            {
                                result = result.WithResult(isValid: true, "Validation properties - the required property 'expectedNetwork' was present.");
                            }

                            if (level > ValidationLevel.Basic)
                            {
                                result = result.PopLocation();
                            }

                            if (level > ValidationLevel.Basic)
                            {
                                result = result.PushValidationLocationReducedPathModifier(new("#/required/2"));
                            }

                            if (!hasSeenInvalidEntities)
                            {
                                if (level >= ValidationLevel.Basic)
                                {
                                    result = result.WithResult(isValid: false, "Validation properties - the required property 'invalidEntities' was not present.");
                                }
                                else
                                {
                                    return ValidationContext.InvalidContext;
                                }
                            }
                            else if (level == ValidationLevel.Verbose)
                            {
                                result = result.WithResult(isValid: true, "Validation properties - the required property 'invalidEntities' was present.");
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
