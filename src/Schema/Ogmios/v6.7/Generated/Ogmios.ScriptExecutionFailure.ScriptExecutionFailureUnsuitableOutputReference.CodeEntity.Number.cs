//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

using System.Diagnostics.CodeAnalysis;

#if NET8_0_OR_GREATER
using System.Numerics;
#endif
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

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
        /// <summary>
        /// ScriptExecutionFailure<UnsuitableOutputReference>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A redeemer points to an input that isn't locked by a Plutus script. Double-check your redeemer pointers and note that, inputs are ordered lexicographically by the ledger (using their transaction id and output index). This order may differ from the one you originally defined in your transaction and may be the cause of misalignment of your redeemer pointers. The field 'data.unsuitableOutputReference' indicates which input was wrongly targeted by a redeemer.
        /// </para>
        /// </remarks>
        public readonly partial struct ScriptExecutionFailureUnsuitableOutputReference
        {
            /// <summary>
            /// Generated from JSON Schema.
            /// </summary>
            public readonly partial struct CodeEntity
#if NET8_0_OR_GREATER
                : IJsonNumber<Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity>,
                  IAdditionOperators<Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity, Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity, Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity>,
                  ISubtractionOperators<Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity, Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity, Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity>,
                  IMultiplyOperators<Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity, Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity, Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity>,
                  IDivisionOperators<Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity, Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity, Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity>,
                  IIncrementOperators<Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity>,
                  IDecrementOperators<Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity>
#else
                : IJsonNumber<Generated.Ogmios.ScriptExecutionFailure.ScriptExecutionFailureUnsuitableOutputReference.CodeEntity>
#endif
            {
                /// <summary>
                /// Initializes a new instance of the <see cref = "CodeEntity"/> struct.
                /// </summary>
                /// <param name="value">The value from which to construct the instance.</param>
                public CodeEntity(long value)
                    : this(new BinaryJsonNumber(value))
                {
                }

                /// <summary>
                /// Conversion from JsonNumber.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                public static implicit operator CodeEntity(JsonNumber value)
                {
                    if (value.HasDotnetBacking && value.ValueKind == JsonValueKind.Number)
                    {
                        return new(
                            value.AsBinaryJsonNumber);
                    }

                    return new(value.AsJsonElement);
                }

                /// <summary>
                /// Conversion to JsonNumber.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                public static implicit operator JsonNumber(CodeEntity value)
                {
                    return
                        value.AsNumber;
                }

                /// <summary>
                /// Conversion to JsonInteger.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                public static implicit operator JsonInteger(CodeEntity value)
                {
                    return
                        value.As<JsonInteger>();
                }

                /// <summary>
                /// Conversion to byte.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the byte.</returns>
                public static explicit operator byte(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetByte();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<byte>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from byte.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(byte value)
                {
                    return new(new BinaryJsonNumber(value));
                }

                /// <summary>
                /// Conversion to decimal.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the decimal.</returns>
                public static explicit operator decimal(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetDecimal();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<decimal>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from decimal.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(decimal value)
                {
                    return new(new BinaryJsonNumber(value));
                }

                /// <summary>
                /// Conversion to double.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the double.</returns>
                public static explicit operator double(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetDouble();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<double>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from double.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(double value)
                {
                    return new(new BinaryJsonNumber(value));
                }

                /// <summary>
                /// Conversion to short.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the short.</returns>
                public static explicit operator short(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetInt16();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<short>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from short.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(short value)
                {
                    return new(new BinaryJsonNumber(value));
                }

                /// <summary>
                /// Conversion to int.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the int.</returns>
                public static explicit operator int(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetInt32();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<int>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from int.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(int value)
                {
                    return new(new BinaryJsonNumber(value));
                }

                /// <summary>
                /// Conversion to long.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the long.</returns>
                public static implicit operator long(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetInt64();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<long>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from long.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static implicit operator CodeEntity(long value)
                {
                    return new(new BinaryJsonNumber(value));
                }

#if NET8_0_OR_GREATER
                /// <summary>
                /// Conversion to Int128.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the Int128.</returns>
                public static explicit operator Int128(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetInt128();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<Int128>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from Int128.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(Int128 value)
                {
                    return new(new BinaryJsonNumber(value));
                }
#endif

                /// <summary>
                /// Conversion to sbyte.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the sbyte.</returns>
                public static explicit operator sbyte(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetSByte();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<sbyte>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from sbyte.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(sbyte value)
                {
                    return new(new BinaryJsonNumber(value));
                }

#if NET8_0_OR_GREATER
                /// <summary>
                /// Conversion to Half.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the Half.</returns>
                public static explicit operator Half(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetHalf();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<Half>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from Half.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(Half value)
                {
                    return new(new BinaryJsonNumber(value));
                }
#endif

                /// <summary>
                /// Conversion to float.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the float.</returns>
                public static explicit operator float(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetSingle();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<float>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from float.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(float value)
                {
                    return new(new BinaryJsonNumber(value));
                }

                /// <summary>
                /// Conversion to ushort.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the ushort.</returns>
                public static explicit operator ushort(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetUInt16();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<ushort>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from ushort.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(ushort value)
                {
                    return new(new BinaryJsonNumber(value));
                }

                /// <summary>
                /// Conversion to uint.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the uint.</returns>
                public static explicit operator uint(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetUInt32();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<uint>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from uint.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(uint value)
                {
                    return new(new BinaryJsonNumber(value));
                }

                /// <summary>
                /// Conversion to ulong.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the ulong.</returns>
                public static explicit operator ulong(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetUInt64();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<ulong>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from ulong.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(ulong value)
                {
                    return new(new BinaryJsonNumber(value));
                }

#if NET8_0_OR_GREATER
                /// <summary>
                /// Conversion to UInt128.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the UInt128.</returns>
                public static explicit operator UInt128(CodeEntity value)
                {
                    if ((value.backing & Backing.JsonElement) != 0)
                    {
                        return value.jsonElementBacking.SafeGetUInt128();
                    }

                    if ((value.backing & Backing.Number) != 0)
                    {
                        return value.numberBacking.CreateChecked<UInt128>();
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Conversion from UInt128.
                /// </summary>
                /// <param name="value">The value from which to convert.</param>
                /// <returns>An instance of the <see cref="CodeEntity"/>.</returns>
                public static explicit operator CodeEntity(UInt128 value)
                {
                    return new(new BinaryJsonNumber(value));
                }
#endif

                /// <summary>
                /// Less than operator.
                /// </summary>
                /// <param name="left">The LHS of the comparison.</param>
                /// <param name="right">The RHS of the comparison.</param>
                /// <returns>
                /// <see langword="true"/> if the left is less than the right, otherwise <see langword="false"/>.
                /// </returns>
                public static bool operator <(CodeEntity left, CodeEntity right)
                {
                    return left.IsNotNullOrUndefined() && right.IsNotNullOrUndefined() && Compare(left, right) < 0;
                }

                /// <summary>
                /// Less than or equals operator.
                /// </summary>
                /// <param name="left">The LHS of the comparison.</param>
                /// <param name="right">The RHS of the comparison.</param>
                /// <returns>
                /// <see langword="true"/> if the left is less than or equal to the right, otherwise <see langword="false"/>.
                /// </returns>
                public static bool operator <=(CodeEntity left, CodeEntity right)
                {
                    return left.IsNotNullOrUndefined() && right.IsNotNullOrUndefined() && Compare(left, right) <= 0;
                }

                /// <summary>
                /// Greater than operator.
                /// </summary>
                /// <param name="left">The LHS of the comparison.</param>
                /// <param name="right">The RHS of the comparison.</param>
                /// <returns>
                /// <see langword="true"/> if the left is greater than the right, otherwise <see langword="false"/>.
                /// </returns>
                public static bool operator >(CodeEntity left, CodeEntity right)
                {
                    return left.IsNotNullOrUndefined() && right.IsNotNullOrUndefined() && Compare(left, right) > 0;
                }

                /// <summary>
                /// Greater than or equals operator.
                /// </summary>
                /// <param name="left">The LHS of the comparison.</param>
                /// <param name="right">The RHS of the comparison.</param>
                /// <returns>
                /// <see langword="true"/> if the left is greater than or equal to the right, otherwise <see langword="false"/>.
                /// </returns>
                public static bool operator >=(CodeEntity left, CodeEntity right)
                {
                    return left.IsNotNullOrUndefined() && right.IsNotNullOrUndefined() && Compare(left, right) >= 0;
                }

                /// <summary>
                /// Adds two numbers to produce their sum.
                /// </summary>
                /// <param name="left">The left hand side of the binary operator.</param>
                /// <param name="right">The right hand side of the binary operator.</param>
                /// <returns>The result of the operation.</returns>
                public static CodeEntity operator +(CodeEntity left, CodeEntity right)
                {
                    return new(left.AsBinaryJsonNumber + right.AsBinaryJsonNumber);
                }

                /// <summary>
                /// Subtracts two numbers to produce their difference.
                /// </summary>
                /// <param name="left">The left hand side of the binary operator.</param>
                /// <param name="right">The right hand side of the binary operator.</param>
                /// <returns>The result of the operation.</returns>
                public static CodeEntity operator -(CodeEntity left, CodeEntity right)
                {
                    return new(left.AsBinaryJsonNumber - right.AsBinaryJsonNumber);
                }

                /// <summary>
                /// Multiplies two numbers.
                /// </summary>
                /// <param name="left">The left hand side of the binary operator.</param>
                /// <param name="right">The right hand side of the binary operator.</param>
                /// <returns>The result of the operation.</returns>
                public static CodeEntity operator *(CodeEntity left, CodeEntity right)
                {
                    return new(left.AsBinaryJsonNumber * right.AsBinaryJsonNumber);
                }

                /// <summary>
                /// Divides two numbers.
                /// </summary>
                /// <param name="left">The left hand side of the binary operator.</param>
                /// <param name="right">The right hand side of the binary operator.</param>
                /// <returns>The result of the operation.</returns>
                public static CodeEntity operator /(CodeEntity left, CodeEntity right)
                {
                    return new(left.AsBinaryJsonNumber / right.AsBinaryJsonNumber);
                }

                /// <summary>
                /// Increments the number.
                /// </summary>
                /// <param name="value">The value on which to operate.</param>
                /// <returns>The result of the operation.</returns>
                public static CodeEntity operator ++(CodeEntity value)
                {
                    BinaryJsonNumber num = value.AsBinaryJsonNumber;                    return new(num++);
                }

                /// <summary>
                /// Decrements the number.
                /// </summary>
                /// <param name="value">The value on which to operate.</param>
                /// <returns>The result of the operation.</returns>
                public static CodeEntity operator --(CodeEntity value)
                {
                    BinaryJsonNumber num = value.AsBinaryJsonNumber;                    return new(num--);
                }

                /// <summary>
                /// Compare two numbers.
                /// </summary>
                /// <param name="lhs">The left hand side of the comparison.</param>
                /// <param name="rhs">The right hand side of the comparison.</param>
                /// <returns>
                /// 0 if the numbers are equal, -1 if <paramref name="lhs"/> is less than <paramref name="rhs"/>,
                /// and 1 if <paramref name="lhs"/> is greater than <paramref name="rhs"/>.
                /// </returns>
                public static int Compare(in CodeEntity lhs, in CodeEntity rhs)
                {
                    if (lhs.ValueKind != rhs.ValueKind)
                    {
                        // We can't be equal if we are not the same underlying type
                        return lhs.IsNullOrUndefined() ? 1 : -1;
                    }

                    if (lhs.IsNull())
                    {
                        // Nulls are always equal
                        return 0;
                    }

                    if (lhs.backing == Backing.Number && rhs.backing == Backing.Number)
                    {
                        return BinaryJsonNumber.Compare(lhs.numberBacking, rhs.numberBacking);
                    }

                    if (lhs.backing == Backing.Number && rhs.backing == Backing.JsonElement)
                    {
                        return BinaryJsonNumber.Compare(lhs.numberBacking, rhs.jsonElementBacking);
                    }

                    if (lhs.backing == Backing.JsonElement && rhs.backing == Backing.Number)
                    {
                        return BinaryJsonNumber.Compare(lhs.jsonElementBacking, rhs.numberBacking);
                    }

                    if (lhs.backing == Backing.JsonElement && rhs.backing == Backing.JsonElement && rhs.jsonElementBacking.ValueKind == JsonValueKind.Number)
                    {
                        return JsonValueHelpers.NumericCompare(lhs.jsonElementBacking, rhs.jsonElementBacking);
                    }

                    throw new InvalidOperationException();
                }

                /// <summary>
                /// Gets the value as a <see cref="BinaryJsonNumber"/>.
                /// </summary>
                public BinaryJsonNumber AsBinaryJsonNumber
                {
                    get
                    {
                        if ((this.backing & Backing.Number) != 0)
                        {
                            return this.numberBacking;
                        }

                        if ((this.backing & Backing.JsonElement) != 0)
                        {
                            return BinaryJsonNumber.FromJson(this.jsonElementBacking, BinaryJsonNumber.Kind.Int64);
                        }

                        throw new InvalidOperationException();
                    }
                }

                /// <summary>
                /// Gets the value as a long.
                /// </summary>
                public long AsInt64() => (long)this;

                /// <summary>
                /// Equality comparison.
                /// </summary>
                /// <param name="other">The <c>long</c> with which to compare.</param>
                /// <returns><see langword="true"/> if the values were equal.</returns>
                public bool Equals(long other)
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        return this.jsonElementBacking.ValueKind == JsonValueKind.Number && BinaryJsonNumber.Equals(this.jsonElementBacking, new BinaryJsonNumber(other));
                    }

                    if ((this.backing & Backing.Number) != 0)
                    {
                        return BinaryJsonNumber.Equals(new BinaryJsonNumber(other), this.numberBacking);
                    }

                    return false;
                }

                /// <summary>
                /// Equality comparison.
                /// </summary>
                /// <param name="other">The <see cref="BinaryJsonNumber"/> with which to compare.</param>
                /// <returns><see langword="true"/> if the values were equal.</returns>
                public bool Equals(in BinaryJsonNumber other)
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        return this.jsonElementBacking.ValueKind == JsonValueKind.Number && other.Equals(this.jsonElementBacking);
                    }

                    if ((this.backing & Backing.Number) != 0)
                    {
                        return BinaryJsonNumber.Equals(other, this.numberBacking);
                    }

                    return false;
                }
            }
        }
    }
}
