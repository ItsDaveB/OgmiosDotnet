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
    /// QueryLedgerStateDelegateRepresentatives
    /// </summary>
    /// <remarks>
    /// <para>
    /// Query currently registered delegate representatives, their stake (i.e. voting powers) and metadata about them. Note that &#39;params&#39; is optional and can be used to filter out delegates. When omitted, ALL delegates are returned. Pre-defined options (always abstain and always no confidence) are ALWAYS returned.
    /// </para>
    /// </remarks>
    public readonly partial struct QueryLedgerStateDelegateRepresentatives
    {
        /// <summary>
        /// Generated from JSON Schema.
        /// </summary>
        public readonly partial struct ParamsEntity
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct ScriptsAnyDelegateRepresentativeCreArray
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

                        result = result.PushSchemaLocation("OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/ogmios.json#/properties/QueryLedgerStateDelegateRepresentatives/properties/params/properties/scripts");
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
                        in ScriptsAnyDelegateRepresentativeCreArray value,
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
                        using JsonArrayEnumerator<Generated.Ogmios.AnyDelegateRepresentativeCredential> arrayEnumerator = value.EnumerateArray();
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

                            var nonTupleItemsResult = arrayEnumerator.Current.Validate(result.CreateChildContext(), level);
                            if (level == ValidationLevel.Flag && !nonTupleItemsResult.IsValid)
                            {
                                return nonTupleItemsResult;
                            }

                            result = result.MergeResults(nonTupleItemsResult.IsValid, level, nonTupleItemsResult);
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
}
