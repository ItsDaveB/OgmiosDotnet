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
/// Metadatum
/// </summary>
public readonly partial struct Metadatum
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

            result = result.PushSchemaLocation("OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.12/Source/cardano.json#/definitions/Metadatum");
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
    /// Validation constants for the type.
    /// </summary>
    public static partial class CorvusValidation
    {
        /// <summary>
        /// Composition validation (any-of).
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The current validation context.</param>
        /// <param name="level">The current validation level.</param>
        /// <returns>The resulting validation context after validation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ValidationContext CompositionAnyOfValidationHandler(
            in Metadatum value,
            in ValidationContext validationContext,
            ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext;

            bool anyOfFoundValid = false;

            ValidationContext anyOfChildContext0 = validationContext.CreateChildContext();
            if (level > ValidationLevel.Basic)
            {
                anyOfChildContext0 = anyOfChildContext0.PushValidationLocationReducedPathModifier(new("#/anyOf/0"));
            }

            ValidationContext anyOfResult0 = value.As<Generated.Metadatum.MetadatumNoSchema>().Validate(anyOfChildContext0, level);

            if (anyOfResult0.IsValid)
            {
                if (level == ValidationLevel.Flag)
                {
                    return result;
                }
                else
                {
                    result = result.MergeChildContext(anyOfResult0, level >= ValidationLevel.Verbose);
                    anyOfFoundValid = true;
                }
            }
            else
            {
                if (level >= ValidationLevel.Verbose)
                {
                    result = result.MergeResults(result.IsValid, level, anyOfResult0);
                }
            }

            ValidationContext anyOfChildContext1 = validationContext.CreateChildContext();
            if (level > ValidationLevel.Basic)
            {
                anyOfChildContext1 = anyOfChildContext1.PushValidationLocationReducedPathModifier(new("#/anyOf/1"));
            }

            ValidationContext anyOfResult1 = value.As<Generated.Metadatum.MetadatumDetailedSchema>().Validate(anyOfChildContext1, level);

            if (anyOfResult1.IsValid)
            {
                if (level == ValidationLevel.Flag)
                {
                    return result;
                }
                else
                {
                    result = result.MergeChildContext(anyOfResult1, level >= ValidationLevel.Verbose);
                    anyOfFoundValid = true;
                }
            }
            else
            {
                if (level >= ValidationLevel.Verbose)
                {
                    result = result.MergeResults(result.IsValid, level, anyOfResult1);
                }
            }

            if (anyOfFoundValid)
            {
                if (level >= ValidationLevel.Verbose)
                {
                    result = result.WithResult(isValid: true, "Validation anyOf - validated against the schema.", "anyOf");
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
                    result = result.WithResult(isValid: false, "Validation anyOf - did not validate against the schema.", "anyOf");
                }
            }

            return result;
        }
    }
}
