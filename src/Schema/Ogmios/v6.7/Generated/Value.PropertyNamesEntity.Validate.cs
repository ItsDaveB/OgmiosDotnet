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
/// Value
/// </summary>
public readonly partial struct Value
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    public readonly partial struct PropertyNamesEntity
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
                result = result.PushSchemaLocation("Ogmios/Generated/cardano.json#/definitions/Value/propertyNames");
            }

            JsonValueKind valueKind = this.ValueKind;

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
            /// String validation.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
            /// <param name="validationContext">The current validation context.</param>
            /// <param name="level">The current validation level.</param>
            /// <returns>The resulting validation context after validation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static ValidationContext StringValidationHandler(
                in PropertyNamesEntity value,
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
                value.AsString.TryGetValue(StringValidator, new Corvus.Json.Validate.ValidationContextWrapper(result, level), out result);

                return result;

                static bool StringValidator(ReadOnlySpan<char> input, in Corvus.Json.Validate.ValidationContextWrapper context, out ValidationContext result)
                {
                    result = context.Context;

                    if (context.Level > ValidationLevel.Basic)
                    {
                        result = result.PushValidationLocationReducedPathModifier(new("#/pattern"));
                    }

                    if (Pattern.IsMatch(input))
                    {
                        if (context.Level == ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true, $"Validation pattern - {input.ToString()} matched  '^[0-9a-f]{56}$'");
                        }
                    }
                    else
                    {
                        if (context.Level >= ValidationLevel.Detailed)
                        {
                            result = result.WithResult(isValid: false, $"Validation pattern - {input.ToString()} did not match  '^[0-9a-f]{56}$'");
                        }
                        else if (context.Level >= ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, "Validation pattern - The value did not match  '^[0-9a-f]{56}$'");
                        }
                        else
                        {
                            result = context.Context.WithResult(isValid: false);
                            return true;
                        }
                    }

                    if (context.Level > ValidationLevel.Basic)
                    {
                        result = result.PopLocation();
                    }

                    return true;
                }
            }

#if NET8_0_OR_GREATER && !DYNAMIC_BUILD
            [GeneratedRegex("^[0-9a-f]{56}$")]
            private static partial Regex CreatePattern();
#else
            private static Regex CreatePattern() => new("^[0-9a-f]{56}$", RegexOptions.Compiled);
#endif
        }
    }
}
