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
/// Block<Praos>
/// </summary>
public readonly partial struct BlockPraos
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    public readonly partial struct EraEntity
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
                result = result.PushSchemaLocation("Ogmios/Generated/cardano.json#/definitions/Block<Praos>/properties/era");
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
            /// Gets the string 'shelley'
            /// as a <see cref="Generated.BlockPraos.EraEntity"/>.
            /// </summary>
            public static EraEntity Shelley { get; } = CorvusValidation.Enum1.As<EraEntity>();

            /// <summary>
            /// Gets the string 'shelley'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> ShelleyUtf8 => CorvusValidation.Enum1Utf8;

            /// <summary>
            /// Gets the string 'allegra'
            /// as a <see cref="Generated.BlockPraos.EraEntity"/>.
            /// </summary>
            public static EraEntity Allegra { get; } = CorvusValidation.Enum2.As<EraEntity>();

            /// <summary>
            /// Gets the string 'allegra'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> AllegraUtf8 => CorvusValidation.Enum2Utf8;

            /// <summary>
            /// Gets the string 'mary'
            /// as a <see cref="Generated.BlockPraos.EraEntity"/>.
            /// </summary>
            public static EraEntity Mary { get; } = CorvusValidation.Enum3.As<EraEntity>();

            /// <summary>
            /// Gets the string 'mary'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> MaryUtf8 => CorvusValidation.Enum3Utf8;

            /// <summary>
            /// Gets the string 'alonzo'
            /// as a <see cref="Generated.BlockPraos.EraEntity"/>.
            /// </summary>
            public static EraEntity Alonzo { get; } = CorvusValidation.Enum4.As<EraEntity>();

            /// <summary>
            /// Gets the string 'alonzo'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> AlonzoUtf8 => CorvusValidation.Enum4Utf8;

            /// <summary>
            /// Gets the string 'babbage'
            /// as a <see cref="Generated.BlockPraos.EraEntity"/>.
            /// </summary>
            public static EraEntity Babbage { get; } = CorvusValidation.Enum5.As<EraEntity>();

            /// <summary>
            /// Gets the string 'babbage'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> BabbageUtf8 => CorvusValidation.Enum5Utf8;

            /// <summary>
            /// Gets the string 'conway'
            /// as a <see cref="Generated.BlockPraos.EraEntity"/>.
            /// </summary>
            public static EraEntity Conway { get; } = CorvusValidation.Enum6.As<EraEntity>();

            /// <summary>
            /// Gets the string 'conway'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> ConwayUtf8 => CorvusValidation.Enum6Utf8;
        }

        /// <summary>
        /// Validation constants for the type.
        /// </summary>
        public static partial class CorvusValidation
        {
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum1 = JsonString.ParseValue("\"shelley\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum2 = JsonString.ParseValue("\"allegra\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum3 = JsonString.ParseValue("\"mary\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum4 = JsonString.ParseValue("\"alonzo\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum5 = JsonString.ParseValue("\"babbage\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum6 = JsonString.ParseValue("\"conway\"");

            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum1Utf8 => "\"shelley\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum2Utf8 => "\"allegra\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum3Utf8 => "\"mary\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum4Utf8 => "\"alonzo\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum5Utf8 => "\"babbage\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum6Utf8 => "\"conway\""u8;

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
                in EraEntity value,
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
                static ValidationContext ValidateEnum(in EraEntity value, in ValidationContext validationContext, ValidationLevel level)
                {
                    ValidationContext result = validationContext;
                    bool enumFoundValid = false;

                    enumFoundValid = value.Equals(CorvusValidation.Enum1);
                    if (!enumFoundValid)
                    {
                        enumFoundValid = value.Equals(CorvusValidation.Enum2);
                    }
                    if (!enumFoundValid)
                    {
                        enumFoundValid = value.Equals(CorvusValidation.Enum3);
                    }
                    if (!enumFoundValid)
                    {
                        enumFoundValid = value.Equals(CorvusValidation.Enum4);
                    }
                    if (!enumFoundValid)
                    {
                        enumFoundValid = value.Equals(CorvusValidation.Enum5);
                    }
                    if (!enumFoundValid)
                    {
                        enumFoundValid = value.Equals(CorvusValidation.Enum6);
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
}