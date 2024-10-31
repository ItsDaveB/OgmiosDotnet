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
        /// SubmitTransactionFailure<CollateralLockedByScript>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Invalid choice of collateral: an input provided for collateral is locked by script. Collateral inputs must be spendable, and the ledger must be able to assert their validity during the first phase of validations (a.k.a phase-1). This discards any input locked by a Plutus script to be used as collateral. Note that for some reason inputs locked by native scripts are also excluded from candidates collateral. The field 'data.unsuitableCollateralInputs' lists all the problematic output references.
        /// </para>
        /// </remarks>
        public readonly partial struct SubmitTransactionFailureCollateralLockedByScript
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct RequiredUnsuitableCollateralInputs
            {
                /// <summary>
                /// Generated from JSON Schema.
                /// </summary>
                public readonly partial struct TransactionOutputReferenceArray
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
                            result = result.PushSchemaLocation("https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Domain/Schemas/Ogmios/Generated/ogmios.json#/definitions/SubmitTransactionFailure/oneOf/30/properties/data/properties/unsuitableCollateralInputs");
                        }

                        JsonValueKind valueKind = this.ValueKind;

                        result = CorvusValidation.TypeValidationHandler(valueKind, result, level);

                        if (level == ValidationLevel.Flag && !result.IsValid)
                        {
                            return result;
                        }

                        result = CorvusValidation.ArrayValidationHandler(this, valueKind, result, level);

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
                            return Corvus.Json.ValidateWithoutCoreType.TypeArray(valueKind, validationContext, level, "type");
                        }

                        /// <summary>
                        /// Array validation.
                        /// </summary>
                        /// <param name="value">The value to validate.</param>
                        /// <param name="valueKind">The <see cref="JsonValueKind" /> of the value to validate.</param>
                        /// <param name="validationContext">The current validation context.</param>
                        /// <param name="level">The current validation level.</param>
                        /// <returns>The resulting validation context after validation.</returns>
                        [MethodImpl(MethodImplOptions.AggressiveInlining)]
                        internal static ValidationContext ArrayValidationHandler(
                            in TransactionOutputReferenceArray value,
                            JsonValueKind valueKind,
                            in ValidationContext validationContext,
                            ValidationLevel level)
                        {
                            ValidationContext result = validationContext;
                            if (valueKind != JsonValueKind.Array)
                            {
                                if (level == ValidationLevel.Verbose)
                                {
                                    ValidationContext ignoredResult = validationContext;
                                    ignoredResult = ignoredResult.WithResult(isValid: true, "Validation items - ignored because the value is not an array", "items");

                                    return ignoredResult;
                                }

                                return validationContext;
                            }

                            int length = 0;
                            using JsonArrayEnumerator<Generated.TransactionOutputReference> arrayEnumerator = value.EnumerateArray();
                            while (arrayEnumerator.MoveNext())
                            {
                                if (level > ValidationLevel.Basic)
                                {
                                    result = result.PushDocumentArrayIndex(length);
                                }
                                if (level > ValidationLevel.Basic)
                                {
                                    result = result.PushValidationLocationReducedPathModifier(new("#/items/$ref"));
                                }

                                result = arrayEnumerator.Current.Validate(result, level);
                                if (level == ValidationLevel.Flag && !result.IsValid)
                                {
                                    return result;
                                }

                                if (level > ValidationLevel.Basic)
                                {
                                    result = result.PopLocation();
                                }

                                result = result.WithLocalItemIndex(length);

                                if (level > ValidationLevel.Basic)
                                {
                                    result = result.PopLocation();
                                }

                                length++;
                            }

                            return result;
                        }
                    }
                }
            }
        }
    }
}