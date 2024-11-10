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
/// RedeemerPointer
/// </summary>
public readonly partial struct RedeemerPointer
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    public readonly partial struct PurposeEntity
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
                result = result.PushSchemaLocation("Ogmios/Generated/cardano.json#/definitions/RedeemerPointer/properties/purpose");
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
            /// Gets the string 'spend'
            /// as a <see cref="Generated.RedeemerPointer.PurposeEntity"/>.
            /// </summary>
            public static PurposeEntity Spend { get; } = CorvusValidation.Enum1.As<PurposeEntity>();

            /// <summary>
            /// Gets the string 'spend'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> SpendUtf8 => CorvusValidation.Enum1Utf8;

            /// <summary>
            /// Gets the string 'mint'
            /// as a <see cref="Generated.RedeemerPointer.PurposeEntity"/>.
            /// </summary>
            public static PurposeEntity Mint { get; } = CorvusValidation.Enum2.As<PurposeEntity>();

            /// <summary>
            /// Gets the string 'mint'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> MintUtf8 => CorvusValidation.Enum2Utf8;

            /// <summary>
            /// Gets the string 'publish'
            /// as a <see cref="Generated.RedeemerPointer.PurposeEntity"/>.
            /// </summary>
            public static PurposeEntity Publish { get; } = CorvusValidation.Enum3.As<PurposeEntity>();

            /// <summary>
            /// Gets the string 'publish'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> PublishUtf8 => CorvusValidation.Enum3Utf8;

            /// <summary>
            /// Gets the string 'withdraw'
            /// as a <see cref="Generated.RedeemerPointer.PurposeEntity"/>.
            /// </summary>
            public static PurposeEntity Withdraw { get; } = CorvusValidation.Enum4.As<PurposeEntity>();

            /// <summary>
            /// Gets the string 'withdraw'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> WithdrawUtf8 => CorvusValidation.Enum4Utf8;

            /// <summary>
            /// Gets the string 'vote'
            /// as a <see cref="Generated.RedeemerPointer.PurposeEntity"/>.
            /// </summary>
            public static PurposeEntity Vote { get; } = CorvusValidation.Enum5.As<PurposeEntity>();

            /// <summary>
            /// Gets the string 'vote'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> VoteUtf8 => CorvusValidation.Enum5Utf8;

            /// <summary>
            /// Gets the string 'propose'
            /// as a <see cref="Generated.RedeemerPointer.PurposeEntity"/>.
            /// </summary>
            public static PurposeEntity Propose { get; } = CorvusValidation.Enum6.As<PurposeEntity>();

            /// <summary>
            /// Gets the string 'propose'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> ProposeUtf8 => CorvusValidation.Enum6Utf8;
        }

        /// <summary>
        /// Validation constants for the type.
        /// </summary>
        public static partial class CorvusValidation
        {
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum1 = JsonString.ParseValue("\"spend\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum2 = JsonString.ParseValue("\"mint\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum3 = JsonString.ParseValue("\"publish\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum4 = JsonString.ParseValue("\"withdraw\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum5 = JsonString.ParseValue("\"vote\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum6 = JsonString.ParseValue("\"propose\"");

            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum1Utf8 => "\"spend\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum2Utf8 => "\"mint\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum3Utf8 => "\"publish\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum4Utf8 => "\"withdraw\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum5Utf8 => "\"vote\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum6Utf8 => "\"propose\""u8;

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
                in PurposeEntity value,
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
                static ValidationContext ValidateEnum(in PurposeEntity value, in ValidationContext validationContext, ValidationLevel level)
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
