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
/// VerificationKey
/// </summary>
/// <remarks>
/// <para>
/// An Ed25519 verification key.
/// </para>
/// </remarks>
public readonly partial struct VerificationKey
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
            result = result.PushSchemaLocation("https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Domain/Schemas/Ogmios/Generated/cardano.json#/definitions/VerificationKey");
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
        /// A constant for the <c>maxLength</c> keyword.
        /// </summary>
        public static readonly long MaxLength = 64;

        /// <summary>
        /// A constant for the <c>minLength</c> keyword.
        /// </summary>
        public static readonly long MinLength = 64;

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
            in VerificationKey value,
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
            in VerificationKey value,
            JsonValueKind valueKind,
            in ValidationContext validationContext,
            ValidationLevel level = ValidationLevel.Flag)
        {
            if (valueKind != JsonValueKind.String)
            {
                if (level == ValidationLevel.Verbose)
                {
                    ValidationContext ignoredResult = validationContext;
                    ignoredResult = ignoredResult.WithResult(isValid: true, "Validation maxLength - ignored because the value is not a string", "maxLength");
                    ignoredResult = ignoredResult.WithResult(isValid: true, "Validation minLength - ignored because the value is not a string", "minLength");

                    return ignoredResult;
                }

                return validationContext;
            }

            ValidationContext result = validationContext;
            value.TryGetValue(StringValidator, new Corvus.Json.Validate.ValidationContextWrapper(result, level), out result);

            return result;

            static bool StringValidator(ReadOnlySpan<char> input, in Corvus.Json.Validate.ValidationContextWrapper context, out ValidationContext result)
            {
                int length = Corvus.Json.Validate.CountRunes(input);
                result = context.Context;

                if (context.Level > ValidationLevel.Basic)
                {
                    result = result.PushValidationLocationReducedPathModifier(new("#/maxLength"));
                }

                if (length <= MaxLength)
                {
                    if (context.Level == ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true, $"Validation maxLength - {input.ToString()} of {length} is less than or equal to {MaxLength}");
                    }
                }
                else
                {
                    if (context.Level >= ValidationLevel.Detailed)
                    {
                        result = result.WithResult(isValid: false, $"Validation maxLength - {input.ToString()} of {length} is greater than {MaxLength}");
                    }
                    else if (context.Level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation maxLength - is greater than the required length.");
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

                if (context.Level > ValidationLevel.Basic)
                {
                    result = result.PushValidationLocationReducedPathModifier(new("#/minLength"));
                }

                if (length >= MinLength)
                {
                    if (context.Level == ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true, $"Validation minLength - {input.ToString()} of {length} is greater than or equal to {MinLength}");
                    }
                }
                else
                {
                    if (context.Level >= ValidationLevel.Detailed)
                    {
                        result = result.WithResult(isValid: false, $"Validation minLength - {input.ToString()} of {length} is less than {MinLength}");
                    }
                    else if (context.Level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation minLength - is less than the required length.");
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
    }
}
