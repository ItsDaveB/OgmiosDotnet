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
/// Generated from JSON Schema.
/// </summary>
public readonly partial struct GovernanceVoter
{
    /// <summary>
    /// Voter&lt;StakePoolOperator&gt;
    /// </summary>
    public readonly partial struct VoterStakePoolOperator
    {
        /// <summary>
        /// Generated from JSON Schema.
        /// </summary>
        public readonly partial struct RoleEntity
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

                    result = result.PushSchemaLocation("OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/cardano.json#/definitions/GovernanceVoter/oneOf/3/properties/role");
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
                /// Gets the string 'stakePoolOperator'
                /// as a <see cref="Generated.GovernanceVoter.VoterStakePoolOperator.RoleEntity"/>.
                /// </summary>
                public static RoleEntity StakePoolOperator { get; } = CorvusValidation.Enum.As<RoleEntity>();

                /// <summary>
                /// Gets the string 'stakePoolOperator'
                /// as a UTF8 byte array.
                /// </summary>
                public static ReadOnlySpan<byte> StakePoolOperatorUtf8 => CorvusValidation.EnumUtf8;
            }

            /// <summary>
            /// Validation constants for the type.
            /// </summary>
            public static partial class CorvusValidation
            {
                /// <summary>
                /// A constant for the <c>enum</c> keyword.
                /// </summary>
                public static readonly JsonString Enum = JsonString.ParseValue("\"stakePoolOperator\"");

                /// <summary>
                /// A constant for the <c>enum</c> keyword.
                /// </summary>
                public static ReadOnlySpan<byte> EnumUtf8 => "\"stakePoolOperator\""u8;

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
                    in RoleEntity value,
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
                    static ValidationContext ValidateEnum(in RoleEntity value, in ValidationContext validationContext, ValidationLevel level)
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
