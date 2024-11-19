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
        /// SubmitTransactionFailure<InsufficientlyFundedOutputs>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Some outputs have an insufficient amount of Ada attached to them. In fact, any new output created in a system must pay for the resources it occupies. Because user-created assets are worthless (from the point of view of the protocol), those resources must be paid in the form of a Ada deposit. The exact depends on the size of the serialized output: the more assets, the higher the amount. The field 'data.insufficientlyFundedOutputs.[].output' contains a list of all transaction outputs that are insufficiently funded. Starting from the Babbage era, the field 'data.insufficientlyFundedOutputs.[].minimumRequiredValue' indicates the required amount of Lovelace (1e6 Lovelace = 1 Ada) needed for each output.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureInsufficientlyFundedOutputs
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct RequiredInsufficientlyFundedOutputs
            {
                /// <summary>
                /// Generated from JSON Schema.
                /// </summary>
                public readonly partial struct RequiredOutputArray
                {
                    /// <summary>
                    /// Generated from JSON Schema.
                    /// </summary>
                    public readonly partial struct RequiredOutput
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
                                result = result.PushSchemaLocation("Ogmios/Generated/ogmios.json#/definitions/SubmitTransactionFailure/oneOf/26/properties/data/properties/insufficientlyFundedOutputs/items");
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
                                in RequiredOutput value,
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

                                bool hasSeenOutput = false;

                                int propertyCount = 0;
                                foreach (JsonObjectProperty property in value.EnumerateObject())
                                {
                                    string? propertyNameAsString = null;

                                    if (property.NameEquals(JsonPropertyNames.MinimumRequiredValueUtf8, JsonPropertyNames.MinimumRequiredValue))
                                    {
                                        result = result.WithLocalProperty(propertyCount);
                                        if (level > ValidationLevel.Basic)
                                        {
                                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/minimumRequiredValue/$ref"), JsonPropertyNames.MinimumRequiredValue);
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
                                    else if (property.NameEquals(JsonPropertyNames.OutputUtf8, JsonPropertyNames.Output))
                                    {
                                        hasSeenOutput = true;
                                        result = result.WithLocalProperty(propertyCount);
                                        if (level > ValidationLevel.Basic)
                                        {
                                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/output/$ref"), JsonPropertyNames.Output);
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

                                if (!hasSeenOutput)
                                {
                                    if (level >= ValidationLevel.Basic)
                                    {
                                        result = result.WithResult(isValid: false, "Validation properties - the required property 'output' was not present.");
                                    }
                                    else
                                    {
                                        return ValidationContext.InvalidContext;
                                    }
                                }
                                else if (level == ValidationLevel.Verbose)
                                {
                                    result = result.WithResult(isValid: true, "Validation properties - the required property 'output' was present.");
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