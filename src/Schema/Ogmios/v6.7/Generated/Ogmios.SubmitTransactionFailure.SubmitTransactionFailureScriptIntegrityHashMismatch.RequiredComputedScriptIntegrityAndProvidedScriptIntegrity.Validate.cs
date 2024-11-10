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
        /// SubmitTransactionFailure<ScriptIntegrityHashMismatch>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The transaction failed because the provided script integrity hash doesn't match the computed one. This is crucial for ensuring the integrity of cost models and Plutus version used during script execution. The field 'data.providedScriptIntegrity' correspond to what was given, if any, and 'data.computedScriptIntegrity' is what was expected. If the latter is null, this means you shouldn't have included a script integrity hash to begin with.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureScriptIntegrityHashMismatch
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct RequiredComputedScriptIntegrityAndProvidedScriptIntegrity
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
                        result = result.PushSchemaLocation("Ogmios/Generated/ogmios.json#/definitions/SubmitTransactionFailure/oneOf/14/properties/data");
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
                        in RequiredComputedScriptIntegrityAndProvidedScriptIntegrity value,
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

                        bool hasSeenComputedScriptIntegrity = false;
                        bool hasSeenProvidedScriptIntegrity = false;

                        int propertyCount = 0;
                        foreach (JsonObjectProperty property in value.EnumerateObject())
                        {
                            string? propertyNameAsString = null;

                            if (property.NameEquals(JsonPropertyNames.ComputedScriptIntegrityUtf8, JsonPropertyNames.ComputedScriptIntegrity))
                            {
                                hasSeenComputedScriptIntegrity = true;
                                result = result.WithLocalProperty(propertyCount);
                                if (level > ValidationLevel.Basic)
                                {
                                    result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/computedScriptIntegrity"), JsonPropertyNames.ComputedScriptIntegrity);
                                }

                                ValidationContext propertyResult = property.Value.As<Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureScriptIntegrityHashMismatch.RequiredComputedScriptIntegrityAndProvidedScriptIntegrity.ComputedScriptIntegrityEntity>().Validate(result.CreateChildContext(), level);
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
                            else if (property.NameEquals(JsonPropertyNames.ProvidedScriptIntegrityUtf8, JsonPropertyNames.ProvidedScriptIntegrity))
                            {
                                hasSeenProvidedScriptIntegrity = true;
                                result = result.WithLocalProperty(propertyCount);
                                if (level > ValidationLevel.Basic)
                                {
                                    result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/providedScriptIntegrity"), JsonPropertyNames.ProvidedScriptIntegrity);
                                }

                                ValidationContext propertyResult = property.Value.As<Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureScriptIntegrityHashMismatch.RequiredComputedScriptIntegrityAndProvidedScriptIntegrity.ProvidedScriptIntegrityEntity>().Validate(result.CreateChildContext(), level);
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

                        if (!hasSeenComputedScriptIntegrity)
                        {
                            if (level >= ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, "Validation properties - the required property 'computedScriptIntegrity' was not present.");
                            }
                            else
                            {
                                return ValidationContext.InvalidContext;
                            }
                        }
                        else if (level == ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true, "Validation properties - the required property 'computedScriptIntegrity' was present.");
                        }

                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PopLocation();
                        }

                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifier(new("#/required/0"));
                        }

                        if (!hasSeenProvidedScriptIntegrity)
                        {
                            if (level >= ValidationLevel.Basic)
                            {
                                result = result.WithResult(isValid: false, "Validation properties - the required property 'providedScriptIntegrity' was not present.");
                            }
                            else
                            {
                                return ValidationContext.InvalidContext;
                            }
                        }
                        else if (level == ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true, "Validation properties - the required property 'providedScriptIntegrity' was present.");
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
