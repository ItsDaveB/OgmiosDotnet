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
/// TransactionId
/// </summary>
/// <remarks>
/// <para>
/// A Blake2b 32-byte hash digest of a transaction body
/// </para>
/// </remarks>
public readonly partial struct TransactionId
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

            result = result.PushSchemaLocation("OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.12/Source/cardano.json#/definitions/TransactionId");
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
            in TransactionId value,
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
            in TransactionId value,
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

                if (length <= MaxLength)
                {
                    if (context.Level == ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true, validationLocationReducedPathModifier: new JsonReference("maxLength"), $"Validation maxLength - {input.ToString()} of {length} is less than or equal to {MaxLength}");
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
                        result = result.WithResult(isValid: false, validationLocationReducedPathModifier: new JsonReference("maxLength"), $"Validation maxLength - {input.ToString()} of {length} is greater than {MaxLength}");
                    }
                    else
                    {
                        result = result.WithResult(isValid: false, validationLocationReducedPathModifier: new JsonReference("maxLength"), "Validation maxLength - is greater than the required length.");
                    }
                }

                if (length >= MinLength)
                {
                    if (context.Level == ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true, validationLocationReducedPathModifier: new JsonReference("minLength"), $"Validation minLength - {input.ToString()} of {length} is greater than or equal to {MinLength}");
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
                        result = result.WithResult(isValid: false, validationLocationReducedPathModifier: new JsonReference("minLength"), $"Validation minLength - {input.ToString()} of {length} is less than {MinLength}");
                    }
                    else
                    {
                        result = result.WithResult(isValid: false, validationLocationReducedPathModifier: new JsonReference("minLength"), "Validation minLength - is less than the required length.");
                    }
                }

                return true;
            }
        }
    }
}
