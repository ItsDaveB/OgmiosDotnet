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
    /// QueryLedgerStateEraStart
    /// </summary>
    /// <remarks>
    /// <para>
    /// Query the start of the current ledger era.
    /// </para>
    /// </remarks>
    public readonly partial struct QueryLedgerStateEraStart
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

                result = result.PushSchemaLocation("OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/ogmios.json#/properties/QueryLedgerStateEraStart");
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
                in QueryLedgerStateEraStart value,
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

                bool hasSeenJsonrpc = false;
                bool hasSeenMethod = false;

                int propertyCount = 0;
                foreach (JsonObjectProperty property in value.EnumerateObject())
                {
                    string? propertyNameAsString = null;

                    if (property.NameEquals(JsonPropertyNames.IdUtf8, JsonPropertyNames.Id))
                    {
                        result = result.WithLocalProperty(propertyCount);
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/id"), JsonPropertyNames.Id);
                        }

                        ValidationContext propertyResult = property.Value.As<Corvus.Json.JsonAny>().Validate(result.CreateChildContext(), level);
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
                    else if (property.NameEquals(JsonPropertyNames.JsonrpcUtf8, JsonPropertyNames.Jsonrpc))
                    {
                        hasSeenJsonrpc = true;
                        result = result.WithLocalProperty(propertyCount);
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/jsonrpc"), JsonPropertyNames.Jsonrpc);
                        }

                        ValidationContext propertyResult = property.Value.As<Generated.Ogmios.QueryLedgerStateEraStart.JsonrpcEntity>().Validate(result.CreateChildContext(), level);
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
                    else if (property.NameEquals(JsonPropertyNames.MethodUtf8, JsonPropertyNames.Method))
                    {
                        hasSeenMethod = true;
                        result = result.WithLocalProperty(propertyCount);
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifierAndProperty(new("#/properties/method"), JsonPropertyNames.Method);
                        }

                        ValidationContext propertyResult = property.Value.As<Generated.Ogmios.QueryLedgerStateEraStart.MethodEntity>().Validate(result.CreateChildContext(), level);
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

                if (!hasSeenJsonrpc)
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation properties - the required property 'jsonrpc' was not present.");
                    }
                    else
                    {
                        return ValidationContext.InvalidContext;
                    }
                }
                else if (level == ValidationLevel.Verbose)
                {
                    result = result.WithResult(isValid: true, "Validation properties - the required property 'jsonrpc' was present.");
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PopLocation();
                }

                if (level > ValidationLevel.Basic)
                {
                    result = result.PushValidationLocationReducedPathModifier(new("#/required/1"));
                }

                if (!hasSeenMethod)
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation properties - the required property 'method' was not present.");
                    }
                    else
                    {
                        return ValidationContext.InvalidContext;
                    }
                }
                else if (level == ValidationLevel.Verbose)
                {
                    result = result.WithResult(isValid: true, "Validation properties - the required property 'method' was present.");
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
