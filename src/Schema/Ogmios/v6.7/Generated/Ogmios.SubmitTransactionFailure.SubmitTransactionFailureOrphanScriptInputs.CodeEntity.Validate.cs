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
    public readonly partial struct SubmitTransactionFailure
    {
        /// <summary>
        /// SubmitTransactionFailure<OrphanScriptInputs>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is bad, you're trying to spend inputs that are locked by Plutus scripts, but have no associated datums. Those inputs are so-to-speak unspendable (at least with the current ledger rules). There's nothing you can do apart from re-creating these UTxOs but with a corresponding datum this time. The field 'data.orphanScriptInputs' lists all such inputs found in the transaction.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureOrphanScriptInputs
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct CodeEntity
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
                        result = result.PushSchemaLocation("Ogmios/Generated/ogmios.json#/definitions/SubmitTransactionFailure/oneOf/15/properties/code");
                    }

                    JsonValueKind valueKind = this.ValueKind;

                    result = CorvusValidation.TypeValidationHandler(this, valueKind, result, level);

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
                    /// Gets the number '3114'
                    /// as a <see cref="Generated.Ogmios.SubmitTransactionFailure.SubmitTransactionFailureOrphanScriptInputs.CodeEntity"/>.
                    /// </summary>
                    public static CodeEntity Item1 { get; } = new(CorvusValidation.Enum);
                }

                /// <summary>
                /// Validation constants for the type.
                /// </summary>
                public static partial class CorvusValidation
                {
                    /// <summary>
                    /// A constant for the <c>enum</c> keyword.
                    /// </summary>
                    public static readonly BinaryJsonNumber Enum = new(3114);

                    /// <summary>
                    /// Core type validation.
                    /// </summary>
                    /// <param name="value">The value to validate.</param>
                    /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
                    /// <param name="validationContext">The current validation context.</param>
                    /// <param name="level">The current validation level.</param>
                    /// <returns>The resulting validation context after validation.</returns>
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    internal static ValidationContext TypeValidationHandler(
                        in CodeEntity value,
                        JsonValueKind valueKind,
                        in ValidationContext validationContext,
                        ValidationLevel level = ValidationLevel.Flag)
                    {
                        return Corvus.Json.ValidateWithoutCoreType.TypeInteger(value, validationContext, level, "type");
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
                        in CodeEntity value,
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
                        static ValidationContext ValidateEnum(in CodeEntity value, in ValidationContext validationContext, ValidationLevel level)
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
    }
}
