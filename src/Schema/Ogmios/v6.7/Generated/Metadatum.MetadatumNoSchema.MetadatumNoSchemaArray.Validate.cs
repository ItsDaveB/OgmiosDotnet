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
/// Metadatum
/// </summary>
public readonly partial struct Metadatum
{
    /// <summary>
    /// Metadatum<NoSchema>
    /// </summary>
    public readonly partial struct MetadatumNoSchema
    {
        /// <summary>
        /// Array<NoSchema>
        /// </summary>
        public readonly partial struct MetadatumNoSchemaArray
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
                    result = result.PushSchemaLocation("Ogmios/Generated/cardano.json#/definitions/Metadatum/anyOf/0/oneOf/2");
                }

                JsonValueKind valueKind = this.ValueKind;

                result = CorvusValidation.TypeValidationHandler(valueKind, result, level);

                if (level == ValidationLevel.Flag && !result.IsValid)
                {
                    return result;
                }

                result = CorvusValidation.ArrayValidationHandler(this, valueKind, result, level);

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
                    return Corvus.Json.ValidateWithoutCoreType.TypeArray(valueKind, validationContext, level, "type");
                }

                /// <summary>
                /// Array validation.
                /// </summary>
                /// <param name="value">The value to validate.</param>
                /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
                /// <param name="validationContext">The current validation context.</param>
                /// <param name="level">The current validation level.</param>
                /// <returns>The resulting validation context after validation.</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                internal static ValidationContext ArrayValidationHandler(
                    in MetadatumNoSchemaArray value,
                    JsonValueKind valueKind,
                    in ValidationContext validationContext,
                    ValidationLevel level)
                {
                    ValidationContext result = validationContext;
                    if (valueKind != JsonValueKind.Array)
                    {
                        if (level == ValidationLevel.Verbose)
                        {
                            ValidationContext ignoredResult = validationContext;
                            ignoredResult = ignoredResult.WithResult(isValid: true, "Validation items - ignored because the value is not an array", "items");

                            return ignoredResult;
                        }

                        return validationContext;
                    }

                    int length = 0;
                    using JsonArrayEnumerator<Generated.Metadatum.MetadatumNoSchema> arrayEnumerator = value.EnumerateArray();
                    while (arrayEnumerator.MoveNext())
                    {
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushDocumentArrayIndex(length);
                        }
                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PushValidationLocationReducedPathModifier(new("#/items/$ref"));
                        }

                        result = arrayEnumerator.Current.Validate(result, level);
                        if (level == ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }

                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PopLocation();
                        }

                        result = result.WithLocalItemIndex(length);

                        if (level > ValidationLevel.Basic)
                        {
                            result = result.PopLocation();
                        }

                        length++;
                    }

                    return result;
                }
            }
        }
    }
}
