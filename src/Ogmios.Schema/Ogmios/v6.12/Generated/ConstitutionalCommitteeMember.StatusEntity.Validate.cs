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
/// ConstitutionalCommitteeMember
/// </summary>
/// <remarks>
/// <para>
/// A constitutional committee member as seen in the context of a specific epoch. Statuses and next states are to be seen from this specific epoch. The field &#39;next&#39;, when present, refers to any change happening to this member in the following epoch.
/// </para>
/// </remarks>
public readonly partial struct ConstitutionalCommitteeMember
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A member status. &#39;active&#39; indicates that this member vote will count during the ratification of the ongoing epoch. &#39;unrecognized&#39; means that some hot credential currently points to a non-existing (or no longer existing) member.
    /// </para>
    /// </remarks>
    public readonly partial struct StatusEntity
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

                result = result.PushSchemaLocation("OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.12/Source/cardano.json#/definitions/ConstitutionalCommitteeMember/properties/status");
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
            /// Gets the string 'active'
            /// as a <see cref="Generated.ConstitutionalCommitteeMember.StatusEntity"/>.
            /// </summary>
            public static StatusEntity Active { get; } = CorvusValidation.Enum1.As<StatusEntity>();

            /// <summary>
            /// Gets the string 'active'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> ActiveUtf8 => CorvusValidation.Enum1Utf8;

            /// <summary>
            /// Gets the string 'expired'
            /// as a <see cref="Generated.ConstitutionalCommitteeMember.StatusEntity"/>.
            /// </summary>
            public static StatusEntity Expired { get; } = CorvusValidation.Enum2.As<StatusEntity>();

            /// <summary>
            /// Gets the string 'expired'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> ExpiredUtf8 => CorvusValidation.Enum2Utf8;

            /// <summary>
            /// Gets the string 'unrecognized'
            /// as a <see cref="Generated.ConstitutionalCommitteeMember.StatusEntity"/>.
            /// </summary>
            public static StatusEntity Unrecognized { get; } = CorvusValidation.Enum3.As<StatusEntity>();

            /// <summary>
            /// Gets the string 'unrecognized'
            /// as a UTF8 byte array.
            /// </summary>
            public static ReadOnlySpan<byte> UnrecognizedUtf8 => CorvusValidation.Enum3Utf8;
        }

        /// <summary>
        /// Validation constants for the type.
        /// </summary>
        public static partial class CorvusValidation
        {
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum1 = JsonString.ParseValue("\"active\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum2 = JsonString.ParseValue("\"expired\"");
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static readonly JsonString Enum3 = JsonString.ParseValue("\"unrecognized\"");

            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum1Utf8 => "\"active\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum2Utf8 => "\"expired\""u8;
            /// <summary>
            /// A constant for the <c>enum</c> keyword.
            /// </summary>
            public static ReadOnlySpan<byte> Enum3Utf8 => "\"unrecognized\""u8;

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
                in StatusEntity value,
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
                static ValidationContext ValidateEnum(in StatusEntity value, in ValidationContext validationContext, ValidationLevel level)
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

                    if (enumFoundValid)
                    {
                        if (level >= ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true, "Validation enum - validated against the enumeration.", "enum");
                        }
                    }
                    else
                    {
                        if (level == ValidationLevel.Flag)
                        {
                            result = result.WithResult(isValid: false);
                        }
                        else
                        {
                            result = result.WithResult(isValid: false, "Validation enum - did not validate against the enumeration.", "enum");
                        }
                    }

                    return result;
                }

                return result;
            }
        }
    }
}
