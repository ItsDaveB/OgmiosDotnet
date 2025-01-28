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
    /// Generated from JSON Schema.
    /// </summary>
    public readonly partial struct AcquireLedgerStateResponseEntity
    {
        /// <summary>
        /// AcquireLedgerStateSuccess
        /// </summary>
        /// <remarks>
        /// <para>
        /// Response to an &#39;acquireLedgerState&#39; request.
        /// </para>
        /// </remarks>
        public readonly partial struct AcquireLedgerStateSuccess
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct RequiredAcquiredAndPoint
            {
                /// <summary>
                /// Generated from JSON Schema.
                /// </summary>
                public readonly partial struct AcquiredEntity
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

                            result = result.PushSchemaLocation("OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/ogmios.json#/properties/AcquireLedgerStateResponse/oneOf/0/properties/result/properties/acquired");
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
                        /// Gets the string 'ledgerState'
                        /// as a <see cref="Generated.Ogmios.AcquireLedgerStateResponseEntity.AcquireLedgerStateSuccess.RequiredAcquiredAndPoint.AcquiredEntity"/>.
                        /// </summary>
                        public static AcquiredEntity LedgerState { get; } = CorvusValidation.Enum.As<AcquiredEntity>();

                        /// <summary>
                        /// Gets the string 'ledgerState'
                        /// as a UTF8 byte array.
                        /// </summary>
                        public static ReadOnlySpan<byte> LedgerStateUtf8 => CorvusValidation.EnumUtf8;
                    }

                    /// <summary>
                    /// Validation constants for the type.
                    /// </summary>
                    public static partial class CorvusValidation
                    {
                        /// <summary>
                        /// A constant for the <c>enum</c> keyword.
                        /// </summary>
                        public static readonly JsonString Enum = JsonString.ParseValue("\"ledgerState\"");

                        /// <summary>
                        /// A constant for the <c>enum</c> keyword.
                        /// </summary>
                        public static ReadOnlySpan<byte> EnumUtf8 => "\"ledgerState\""u8;

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
                            in AcquiredEntity value,
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
                            static ValidationContext ValidateEnum(in AcquiredEntity value, in ValidationContext validationContext, ValidationLevel level)
                            {
                                ValidationContext result = validationContext;
                                bool enumFoundValid = false;

                                enumFoundValid = value.Equals(CorvusValidation.Enum);

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
        }
    }
}
