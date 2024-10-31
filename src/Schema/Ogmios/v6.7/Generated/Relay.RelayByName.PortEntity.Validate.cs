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
/// Relay
/// </summary>
public readonly partial struct Relay
{
    /// <summary>
    /// Relay<ByName>
    /// </summary>
    public readonly partial struct RelayByName
    {
        /// <summary>
        /// Generated from JSON Schema.
        /// </summary>
        public readonly partial struct PortEntity
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
                    result = result.PushSchemaLocation("https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Domain/Schemas/Ogmios/Generated/cardano.json#/definitions/Relay/oneOf/1/properties/port");
                }

                JsonValueKind valueKind = this.ValueKind;

                result = CorvusValidation.TypeValidationHandler(this, valueKind, result, level);

                if (level == ValidationLevel.Flag && !result.IsValid)
                {
                    return result;
                }

                result = CorvusValidation.NumberValidationHandler(this, valueKind, result, level);

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
                /// A constant for the <c>maximum</c> keyword.
                /// </summary>
                public static readonly BinaryJsonNumber Maximum = new(65535);

                /// <summary>
                /// A constant for the <c>minimum</c> keyword.
                /// </summary>
                public static readonly BinaryJsonNumber Minimum = new(0);

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
                    in PortEntity value,
                    JsonValueKind valueKind,
                    in ValidationContext validationContext,
                    ValidationLevel level = ValidationLevel.Flag)
                {
                    return Corvus.Json.ValidateWithoutCoreType.TypeInteger(value, validationContext, level, "type");
                }

                /// <summary>
                /// Numeric validation.
                /// </summary>
                /// <param name="value">The value to validate.</param>
                /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
                /// <param name="validationContext">The current validation context.</param>
                /// <param name="level">The current validation level.</param>
                /// <returns>The resulting validation context after validation.</returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                internal static ValidationContext NumberValidationHandler(
                    in PortEntity value,
                    JsonValueKind valueKind,
                    in ValidationContext validationContext,
                    ValidationLevel level = ValidationLevel.Flag)
                {
                    if (valueKind != JsonValueKind.Number)
                    {
                        if (level == ValidationLevel.Verbose)
                        {
                            ValidationContext ignoredResult = validationContext;
                            ignoredResult = ignoredResult.WithResult(isValid: true, "Validation maximum - ignored because the value is not a number", "maximum");
                            ignoredResult = ignoredResult.WithResult(isValid: true, "Validation minimum - ignored because the value is not a number", "minimum");

                            return ignoredResult;
                        }

                        return validationContext;
                    }

                    ValidationContext result = validationContext;

                    if ((value.HasJsonElementBacking
                        ? BinaryJsonNumber.Compare(value.AsJsonElement, Maximum)
                        : BinaryJsonNumber.Compare(value.AsBinaryJsonNumber, Maximum))<= 0)
                    {
                        if (level == ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true, $"Validation maximum - {value} is less than or equal to {Maximum}", "maximum");
                        }
                    }
                    else
                    {
                        if (level >= ValidationLevel.Detailed)
                        {
                            result = result.WithResult(isValid: false, $"Validation maximum - {value} is greater than {Maximum}", "maximum");
                        }
                        else if (level >= ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, "Validation maximum - is greater than the required value.", "maximum");
                        }
                        else
                        {
                            return ValidationContext.InvalidContext;
                        }
                    }

                    if ((value.HasJsonElementBacking
                        ? BinaryJsonNumber.Compare(value.AsJsonElement, Minimum)
                        : BinaryJsonNumber.Compare(value.AsBinaryJsonNumber, Minimum))>= 0)
                    {
                        if (level == ValidationLevel.Verbose)
                        {
                            result = result.WithResult(isValid: true, $"Validation minimum - {value} is greater than or equal to {Minimum}", "minimum");
                        }
                    }
                    else
                    {
                        if (level >= ValidationLevel.Detailed)
                        {
                            result = result.WithResult(isValid: false, $"Validation minimum - {value} is less than {Minimum}", "minimum");
                        }
                        else if (level >= ValidationLevel.Basic)
                        {
                            result = result.WithResult(isValid: false, "Validation minimum - is less than the required value.", "minimum");
                        }
                        else
                        {
                            return ValidationContext.InvalidContext;
                        }
                    }
                    return result;
                }
            }
        }
    }
}
