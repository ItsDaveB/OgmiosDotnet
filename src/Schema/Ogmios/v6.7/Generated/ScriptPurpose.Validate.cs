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
/// ScriptPurpose
/// </summary>
public readonly partial struct ScriptPurpose
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
            result = result.PushSchemaLocation("Ogmios/Generated/cardano.json#/definitions/ScriptPurpose");
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
            in ScriptPurpose value,
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

            ValidationContext oneOfResult0 = value.As<Generated.ScriptPurpose.ScriptPurposeSpend>().Validate(oneOfChildContext0, level);

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

            ValidationContext oneOfResult1 = value.As<Generated.ScriptPurpose.ScriptPurposeMint>().Validate(oneOfChildContext1, level);

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

            ValidationContext oneOfResult2 = value.As<Generated.ScriptPurpose.ScriptPurposePublish>().Validate(oneOfChildContext2, level);

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
                oneOfChildContext3 = oneOfChildContext3.PushValidationLocationReducedPathModifier(new("#/oneOf/3"));
            }

            ValidationContext oneOfResult3 = value.As<Generated.ScriptPurpose.ScriptPurposeWithdraw>().Validate(oneOfChildContext3, level);

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
                oneOfChildContext4 = oneOfChildContext4.PushValidationLocationReducedPathModifier(new("#/oneOf/4"));
            }

            ValidationContext oneOfResult4 = value.As<Generated.ScriptPurpose.ScriptPurposePropose>().Validate(oneOfChildContext4, level);

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
                oneOfChildContext5 = oneOfChildContext5.PushValidationLocationReducedPathModifier(new("#/oneOf/5"));
            }

            ValidationContext oneOfResult5 = value.As<Generated.ScriptPurpose.ScriptPurposeVote>().Validate(oneOfChildContext5, level);

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
