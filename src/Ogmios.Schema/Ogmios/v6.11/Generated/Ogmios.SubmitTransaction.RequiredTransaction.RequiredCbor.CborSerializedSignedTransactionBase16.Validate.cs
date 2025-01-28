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
using System.Text.RegularExpressions;
using Corvus.Json;

namespace Generated;

/// <summary>
/// ogmios
/// </summary>
public readonly partial struct Ogmios
{
    /// <summary>
    /// SubmitTransaction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Submit a signed and serialized transaction to the network.
    /// </para>
    /// </remarks>
    public readonly partial struct SubmitTransaction
    {
        /// <summary>
        /// Generated from JSON Schema.
        /// </summary>
        public readonly partial struct RequiredTransaction
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct RequiredCbor
            {
                /// <summary>
                /// Generated from JSON Schema.
                /// </summary>
                /// <remarks>
                /// <para>
                /// CBOR-serialized signed transaction (base16)
                /// </para>
                /// </remarks>
                public readonly partial struct CborSerializedSignedTransactionBase16
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

                            result = result.PushSchemaLocation("OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/ogmios.json#/properties/SubmitTransaction/properties/params/properties/transaction/properties/cbor");
                        }

                        JsonValueKind valueKind = this.ValueKind;

                        result = CorvusValidation.TypeValidationHandler(valueKind, result, level);

                        if (level == ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }

                        result = CorvusValidation.FormatValidationHandler(this, valueKind, result, level);

                        if (level == ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }

                        result = CorvusValidation.StringValidationHandler(this, valueKind, result, level);

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
                        /// A regular expression for the <c>pattern</c> keyword.
                        /// </summary>
                        public static readonly Regex Pattern = CreatePattern();

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
                            return Corvus.Json.ValidateWithoutCoreType.TypeString(valueKind, validationContext, level, "type");
                        }

                        /// <summary>
                        /// Numeric and string format validation.
                        /// </summary>
                        /// <param name="value">The value to validate.</param>
                        /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
                        /// <param name="validationContext">The current validation context.</param>
                        /// <param name="level">The current validation level.</param>
                        /// <returns>The resulting validation context after validation.</returns>
                        [MethodImpl(MethodImplOptions.AggressiveInlining)]
                        internal static ValidationContext FormatValidationHandler(
                            in CborSerializedSignedTransactionBase16 value,
                            JsonValueKind valueKind,
                            in ValidationContext validationContext,
                            ValidationLevel level = ValidationLevel.Flag)
                        {
                            return validationContext;
                        }

                        /// <summary>
                        /// String validation.
                        /// </summary>
                        /// <param name="value">The value to validate.</param>
                        /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
                        /// <param name="validationContext">The current validation context.</param>
                        /// <param name="level">The current validation level.</param>
                        /// <returns>The resulting validation context after validation.</returns>
                        [MethodImpl(MethodImplOptions.AggressiveInlining)]
                        internal static ValidationContext StringValidationHandler(
                            in CborSerializedSignedTransactionBase16 value,
                            JsonValueKind valueKind,
                            in ValidationContext validationContext,
                            ValidationLevel level = ValidationLevel.Flag)
                        {
                            if (valueKind != JsonValueKind.String)
                            {
                                if (level == ValidationLevel.Verbose)
                                {
                                    ValidationContext ignoredResult = validationContext;
                                    ignoredResult = ignoredResult.WithResult(isValid: true, "Validation pattern - ignored because the value is not a string", "pattern");

                                    return ignoredResult;
                                }

                                return validationContext;
                            }

                            ValidationContext result = validationContext;
                            value.TryGetValue(StringValidator, new Corvus.Json.Validate.ValidationContextWrapper(result, level), out result);

                            return result;

                            static bool StringValidator(ReadOnlySpan<char> input, in Corvus.Json.Validate.ValidationContextWrapper context, out ValidationContext result)
                            {
                                result = context.Context;

                                if (Pattern.IsMatch(input))
                                {
                                    if (context.Level == ValidationLevel.Verbose)
                                    {
                                        result = result.WithResult(isValid: true, validationLocationReducedPathModifier: new JsonReference("pattern"), $"Validation pattern - {input.ToString()} matched '^[0-9a-f]+$'");
                                    }
                                }
                                else
                                {
                                    if (context.Level == ValidationLevel.Flag)
                                    {
                                        result = context.Context.WithResult(isValid: false);
                                        return true;
                                    }
                                    else if (context.Level >= ValidationLevel.Detailed)
                                    {
                                        result = result.WithResult(isValid: false, validationLocationReducedPathModifier: new JsonReference("pattern"), $"Validation pattern - {input.ToString()} did not match '^[0-9a-f]+$'");
                                    }
                                    else
                                    {
                                        result = result.WithResult(isValid: false, validationLocationReducedPathModifier: new JsonReference("pattern"), "Validation pattern - The value did not match '^[0-9a-f]+$'");
                                    }
                                }

                                return true;
                            }
                        }

#if NET8_0_OR_GREATER && !DYNAMIC_BUILD
                        [GeneratedRegex("^[0-9a-f]+$")]
                        private static partial Regex CreatePattern();
#else
                        private static Regex CreatePattern() => new("^[0-9a-f]+$", RegexOptions.Compiled);
#endif
                    }
                }
            }
        }
    }
}
