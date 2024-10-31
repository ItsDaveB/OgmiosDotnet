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
/// CredentialOrigin
/// </summary>
public readonly partial struct CredentialOrigin
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
            result = result.PushSchemaLocation("https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Domain/Schemas/Ogmios/Generated/cardano.json#/definitions/CredentialOrigin");
        }

        JsonValueKind valueKind = this.ValueKind;

        result = CorvusValidation.TypeValidationHandler(valueKind, result, level);

        if (level == ValidationLevel.Flag && !result.IsValid)
        {
            return result;
        }

        result = CorvusValidation.CompositionAnyOfValidationHandler(this, result, level);

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
    /// Constant values for the enum keyword.
    /// </summary>
    public static class EnumValues
    {
        /// <summary>
        /// Gets the string 'verificationKey'
        /// as a <see cref="Generated.CredentialOrigin"/>.
        /// </summary>
        public static CredentialOrigin VerificationKey { get; } = CorvusValidation.Enum1.As<CredentialOrigin>();

        /// <summary>
        /// Gets the string 'verificationKey'
        /// as a UTF8 byte array.
        /// </summary>
        public static ReadOnlySpan<byte> VerificationKeyUtf8 => CorvusValidation.Enum1Utf8;

        /// <summary>
        /// Gets the string 'script'
        /// as a <see cref="Generated.CredentialOrigin"/>.
        /// </summary>
        public static CredentialOrigin Script { get; } = CorvusValidation.Enum2.As<CredentialOrigin>();

        /// <summary>
        /// Gets the string 'script'
        /// as a UTF8 byte array.
        /// </summary>
        public static ReadOnlySpan<byte> ScriptUtf8 => CorvusValidation.Enum2Utf8;
    }

    /// <summary>
    /// Validation constants for the type.
    /// </summary>
    public static partial class CorvusValidation
    {
        /// <summary>
        /// A constant for the <c>enum</c> keyword.
        /// </summary>
        public static readonly JsonString Enum1 = JsonString.ParseValue("\"verificationKey\"");
        /// <summary>
        /// A constant for the <c>enum</c> keyword.
        /// </summary>
        public static readonly JsonString Enum2 = JsonString.ParseValue("\"script\"");

        /// <summary>
        /// A constant for the <c>enum</c> keyword.
        /// </summary>
        public static ReadOnlySpan<byte> Enum1Utf8 => "\"verificationKey\""u8;
        /// <summary>
        /// A constant for the <c>enum</c> keyword.
        /// </summary>
        public static ReadOnlySpan<byte> Enum2Utf8 => "\"script\""u8;

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
        /// Composition validation (any-of).
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The current validation context.</param>
        /// <param name="level">The current validation level.</param>
        /// <returns>The resulting validation context after validation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValidationContext CompositionAnyOfValidationHandler(
            in CredentialOrigin value,
            in ValidationContext validationContext,
            ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext;

            result = ValidateEnum(value, result, level);
            if (!result.IsValid && level == ValidationLevel.Flag)
            {
                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static ValidationContext ValidateEnum(in CredentialOrigin value, in ValidationContext validationContext, ValidationLevel level)
            {
                ValidationContext result = validationContext;
                bool enumFoundValid = false;

                enumFoundValid = value.Equals(CorvusValidation.Enum1);
                if (!enumFoundValid)
                {
                    enumFoundValid = value.Equals(CorvusValidation.Enum2);
                }

                if (enumFoundValid)
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true, "Validation enum - validated against the enumeration.", "enum");
                    }
                }
                else
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation enum - did not validate against the enumeration.", "enum");
                    }
                    else
                    {
                        result = result.WithResult(isValid: false);
                    }
                }

                return result;
            }

            return result;
        }
    }
}
