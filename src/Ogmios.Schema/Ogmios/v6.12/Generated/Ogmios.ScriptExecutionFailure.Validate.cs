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
    public readonly partial struct ScriptExecutionFailure
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

                result = result.PushSchemaLocation("OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.12/Source/ogmios.json#/definitions/ScriptExecutionFailure");
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
                in ScriptExecutionFailure value,
                in ValidationContext validationContext,
                ValidationLevel level = ValidationLevel.Flag)
            {
                ValidationContext result = validationContext;

                int oneOfFoundValid = 0;

                ValidationContext oneOfChildContext0 = validationContext.CreateChildContext();
                if (level > ValidationLevel.Basic)
                {
                    oneOfChildContext0 = oneOfChildContext0.PushValidationLocationReducedPathModifier(new("#/oneOf/0"));
                }

                ValidationContext oneOfResult0 = value.As<Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureInvalidRedeemerPointers>().Validate(oneOfChildContext0, level);

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

                ValidationContext oneOfResult1 = value.As<Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureValidationFailure>().Validate(oneOfChildContext1, level);

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

                ValidationContext oneOfChildContext2 = validationContext.CreateChildContext();
                if (level > ValidationLevel.Basic)
                {
                    oneOfChildContext2 = oneOfChildContext2.PushValidationLocationReducedPathModifier(new("#/oneOf/2"));
                }

                ValidationContext oneOfResult2 = value.As<Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference>().Validate(oneOfChildContext2, level);

                if (oneOfResult2.IsValid)
                {
                    result = result.MergeChildContext(oneOfResult2, level >= ValidationLevel.Verbose);
                    oneOfFoundValid++;
                }
                else
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.MergeResults(result.IsValid, level, oneOfResult2);
                    }
                }

                ValidationContext oneOfChildContext3 = validationContext.CreateChildContext();
                if (level > ValidationLevel.Basic)
                {
                    oneOfChildContext3 = oneOfChildContext3.PushValidationLocationReducedPathModifier(new("#/oneOf/3/$ref"));
                }

                ValidationContext oneOfResult3 = value.As<Generated.Ogmios.SubmitTransactionFailureExtraneousRedeemers>().Validate(oneOfChildContext3, level);

                if (oneOfResult3.IsValid)
                {
                    result = result.MergeChildContext(oneOfResult3, level >= ValidationLevel.Verbose);
                    oneOfFoundValid++;
                }
                else
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.MergeResults(result.IsValid, level, oneOfResult3);
                    }
                }

                ValidationContext oneOfChildContext4 = validationContext.CreateChildContext();
                if (level > ValidationLevel.Basic)
                {
                    oneOfChildContext4 = oneOfChildContext4.PushValidationLocationReducedPathModifier(new("#/oneOf/4/$ref"));
                }

                ValidationContext oneOfResult4 = value.As<Generated.Ogmios.SubmitTransactionFailureMissingDatums>().Validate(oneOfChildContext4, level);

                if (oneOfResult4.IsValid)
                {
                    result = result.MergeChildContext(oneOfResult4, level >= ValidationLevel.Verbose);
                    oneOfFoundValid++;
                }
                else
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.MergeResults(result.IsValid, level, oneOfResult4);
                    }
                }

                ValidationContext oneOfChildContext5 = validationContext.CreateChildContext();
                if (level > ValidationLevel.Basic)
                {
                    oneOfChildContext5 = oneOfChildContext5.PushValidationLocationReducedPathModifier(new("#/oneOf/5/$ref"));
                }

                ValidationContext oneOfResult5 = value.As<Generated.Ogmios.SubmitTransactionFailureUnknownOutputReference>().Validate(oneOfChildContext5, level);

                if (oneOfResult5.IsValid)
                {
                    result = result.MergeChildContext(oneOfResult5, level >= ValidationLevel.Verbose);
                    oneOfFoundValid++;
                }
                else
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.MergeResults(result.IsValid, level, oneOfResult5);
                    }
                }

                ValidationContext oneOfChildContext6 = validationContext.CreateChildContext();
                if (level > ValidationLevel.Basic)
                {
                    oneOfChildContext6 = oneOfChildContext6.PushValidationLocationReducedPathModifier(new("#/oneOf/6/$ref"));
                }

                ValidationContext oneOfResult6 = value.As<Generated.Ogmios.SubmitTransactionFailureMissingCostModels>().Validate(oneOfChildContext6, level);

                if (oneOfResult6.IsValid)
                {
                    result = result.MergeChildContext(oneOfResult6, level >= ValidationLevel.Verbose);
                    oneOfFoundValid++;
                }
                else
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.MergeResults(result.IsValid, level, oneOfResult6);
                    }
                }

                ValidationContext oneOfChildContext7 = validationContext.CreateChildContext();
                if (level > ValidationLevel.Basic)
                {
                    oneOfChildContext7 = oneOfChildContext7.PushValidationLocationReducedPathModifier(new("#/oneOf/7/$ref"));
                }

                ValidationContext oneOfResult7 = value.As<Generated.Ogmios.SubmitTransactionFailureExecutionBudgetOutOfBounds>().Validate(oneOfChildContext7, level);

                if (oneOfResult7.IsValid)
                {
                    result = result.MergeChildContext(oneOfResult7, level >= ValidationLevel.Verbose);
                    oneOfFoundValid++;
                }
                else
                {
                    if (level >= ValidationLevel.Verbose)
                    {
                        result = result.MergeResults(result.IsValid, level, oneOfResult7);
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
