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
        /// SubmitTransactionFailure&lt;MetadataHashMismatch&gt;
        /// </summary>
        /// <remarks>
        /// <para>
        /// There&#39;s a mismatch between the provided metadata hash digest and the one computed from the actual metadata. The two must match exactly. The field &#39;data.provided.hash&#39; references the provided hash as found in the transaction body, whereas &#39;data.computed.hash&#39; contains the one the ledger computed from the actual metadata.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureMetadataHashMismatch
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct RequiredComputedAndProvided
            {
                /// <summary>
                /// Generated from JSON Schema.
                /// </summary>
                public readonly partial struct RequiredComputedAndProvidedRequiredHash
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

                            result = result.PushSchemaLocation("OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/ogmios.json#/definitions/SubmitTransactionFailure/oneOf/8/properties/data/properties/provided");
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
                            in RequiredComputedAndProvidedRequiredHash value,
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

                            bool hasSeenHash = false;

                            int propertyCount = 0;
                            foreach (JsonObjectProperty property in value.EnumerateObject())
                            {
                                string? propertyNameAsString = null;

                                if (property.NameEquals(JsonPropertyNames.HashUtf8, JsonPropertyNames.Hash))
                                {
                                    hasSeenHash = true;
                                    result = result.WithLocalProperty(propertyCount);
                                    if (level > ValidationLevel.Basic)
                                    {
                                        result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/hash/$ref"), JsonPropertyNames.Hash);
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

                            if (!hasSeenHash)
                            {
                                if (level >= ValidationLevel.Basic)
                                {
                                    result = result.WithResult(isValid: false, "Validation properties - the required property 'hash' was not present.");
                                }
                                else
                                {
                                    return ValidationContext.InvalidContext;
                                }
                            }
                            else if (level == ValidationLevel.Verbose)
                            {
                                result = result.WithResult(isValid: true, "Validation properties - the required property 'hash' was present.");
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
