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
    /// AnyDelegateRepresentativeCredential
    /// </summary>
    public readonly partial struct AnyDelegateRepresentativeCredential
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

                result = result.PushSchemaLocation("https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.11/Source/ogmios.json#/definitions/AnyDelegateRepresentativeCredential");
            }

            result = CorvusValidation.CompositionOneOfValidationHandler(this, result, level);

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
            /// Composition validation (one-of).
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="validationContext">The current validation context.</param>
            /// <param name="level">The current validation level.</param>
            /// <returns>The resulting validation context after validation.</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static ValidationContext CompositionOneOfValidationHandler(
                in AnyDelegateRepresentativeCredential value,
                in ValidationContext validationContext,
                ValidationLevel level = ValidationLevel.Flag)
            {
                ValidationContext result = validationContext;

                int oneOfFoundValid = 0;

                ValidationContext oneOfChildContext0 = validationContext.CreateChildContext();
                if (level > ValidationLevel.Basic)
                {
                    oneOfChildContext0 = oneOfChildContext0.PushValidationLocationReducedPathModifier(new("#/oneOf/0/$ref"));
                }

                ValidationContext oneOfResult0 = value.As<Generated.Ogmios.EncodingBase16>().Validate(oneOfChildContext0, level);

                if (oneOfResult0.IsValid)
                {
                    result = result.MergeChildContext(oneOfResult0, level >= ValidationLevel.Verbose);
                    oneOfFoundValid++;
                }
                else
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.MergeResults(result.IsValid, level, oneOfResult0);
                    }
                }

                ValidationContext oneOfChildContext1 = validationContext.CreateChildContext();
                if (level > ValidationLevel.Basic)
                {
                    oneOfChildContext1 = oneOfChildContext1.PushValidationLocationReducedPathModifier(new("#/oneOf/1"));
                }

                ValidationContext oneOfResult1 = value.As<Generated.Ogmios.AnyDelegateRepresentativeCredential.Bech32DrepVkhDrepScript>().Validate(oneOfChildContext1, level);

                if (oneOfResult1.IsValid)
                {
                    result = result.MergeChildContext(oneOfResult1, level >= ValidationLevel.Verbose);
                    oneOfFoundValid++;
                }
                else
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.MergeResults(result.IsValid, level, oneOfResult1);
                    }
                }

                if (oneOfFoundValid == 1)
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.WithResult(isValid: true, "Validation oneOf - validated against the schema.", "oneOf");
                    }
                }
                else if (oneOfFoundValid > 1)
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation oneOf - validated against more than 1 of the schema.", "oneOf");
                    }
                    else
                    {
                        result = result.WithResult(isValid: false);
                    }
                }
                else
                {
                    if (level >= ValidationLevel.Basic)
                    {
                        result = result.WithResult(isValid: false, "Validation oneOf - did not validate against any of the schema.", "oneOf");
                    }
                    else
                    {
                        result = result.WithResult(isValid: false);
                    }
                }

                return result;
            }
        }
    }
}
