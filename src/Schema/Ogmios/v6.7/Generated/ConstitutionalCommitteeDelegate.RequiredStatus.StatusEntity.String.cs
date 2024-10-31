//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

namespace Generated;

/// <summary>
/// ConstitutionalCommitteeDelegate
/// </summary>
public readonly partial struct ConstitutionalCommitteeDelegate
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    public readonly partial struct RequiredStatus
    {
        /// <summary>
        /// Generated from JSON Schema.
        /// </summary>
        public readonly partial struct StatusEntity
#if NET8_0_OR_GREATER
            : IJsonString<Generated.ConstitutionalCommitteeDelegate.RequiredStatus.StatusEntity>,
              ISpanFormattable
#else
            : IJsonString<Generated.ConstitutionalCommitteeDelegate.RequiredStatus.StatusEntity>
#endif
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StatusEntity"/> struct.
            /// </summary>
            /// <param name="value">The value from which to construct the instance.</param>
            public StatusEntity(in ReadOnlySpan<char> value)
            {
                this.backing = Backing.String;
                this.jsonElementBacking = default;
                this.stringBacking = value.ToString();
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="StatusEntity"/> struct.
            /// </summary>
            /// <param name="value">The value from which to construct the instance.</param>
            public StatusEntity(in ReadOnlySpan<byte> value)
            {
                this.backing = Backing.String;
                this.jsonElementBacking = default;

#if NET8_0_OR_GREATER
                this.stringBacking = System.Text.Encoding.UTF8.GetString(value);
#else
                byte[] bytes = ArrayPool<byte>.Shared.Rent(value.Length);
                try
                {
                    value.CopyTo(bytes);
                    this.stringBacking = System.Text.Encoding.UTF8.GetString(bytes);
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(bytes);
                }
#endif
            }

            /// <summary>
            /// Conversion from <see cref="string"/>.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            public static implicit operator StatusEntity(string value)
            {
                return new(value);
            }

            /// <summary>
            /// Conversion from JsonString.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            public static implicit operator StatusEntity(JsonString value)
            {
                if (value.HasDotnetBacking && value.ValueKind == JsonValueKind.String)
                {
                    return new(
                        (string)value);
                }

                return new(value.AsJsonElement);
            }

            /// <summary>
            /// Conversion to JsonString.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            public static implicit operator JsonString(StatusEntity value)
            {
                return
                    value.AsString;
            }

            /// <summary>
            /// Conversion to string.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            /// <exception cref="InvalidOperationException">The value was not a string.</exception>
            public static explicit operator string(StatusEntity value)
            {
                if ((value.backing & Backing.JsonElement) != 0)
                {
                    if (value.jsonElementBacking.GetString() is string result)
                    {
                        return result;
                    }

                    throw new InvalidOperationException();
                }

                if ((value.backing & Backing.String) != 0)
                {
                    return value.stringBacking;
                }

                throw new InvalidOperationException();
            }

            /// <summary>
            /// Concatenate 2 JSON values, producing an instance of the string type StatusEntity.
            /// </summary>
            /// <typeparam name="T1">The type of the 1st value.</typeparam>
            /// <typeparam name="T2">The type of the 2nd value.</typeparam>
            /// <param name="buffer">The buffer into which to concatenate the values.</param>
            /// <param name="value1">The 1st value.</param>
            /// <param name="value2">The 2nd value.</param>
            /// <returns>An instance of this string type.</returns>
            public static StatusEntity Concatenate<T1, T2>(Span<byte> buffer, in T1 value1, in T2 value2)
                where T1 : struct, IJsonValue<T1>
                where T2 : struct, IJsonValue<T2>
            {
                int written = LowAllocJsonUtils.ConcatenateAsUtf8JsonString(buffer, value1, value2);
                return ParseValue(buffer[..written]);
            }

            /// <summary>
            /// Concatenate 3 JSON values, producing an instance of the string type StatusEntity.
            /// </summary>
            /// <typeparam name="T1">The type of the 1st value.</typeparam>
            /// <typeparam name="T2">The type of the 2nd value.</typeparam>
            /// <typeparam name="T3">The type of the 3rd value.</typeparam>
            /// <param name="buffer">The buffer into which to concatenate the values.</param>
            /// <param name="value1">The 1st value.</param>
            /// <param name="value2">The 2nd value.</param>
            /// <param name="value3">The 3rd value.</param>
            /// <returns>An instance of this string type.</returns>
            public static StatusEntity Concatenate<T1, T2, T3>(Span<byte> buffer, in T1 value1, in T2 value2, in T3 value3)
                where T1 : struct, IJsonValue<T1>
                where T2 : struct, IJsonValue<T2>
                where T3 : struct, IJsonValue<T3>
            {
                int written = LowAllocJsonUtils.ConcatenateAsUtf8JsonString(buffer, value1, value2, value3);
                return ParseValue(buffer[..written]);
            }

            /// <summary>
            /// Concatenate 4 JSON values, producing an instance of the string type StatusEntity.
            /// </summary>
            /// <typeparam name="T1">The type of the 1st value.</typeparam>
            /// <typeparam name="T2">The type of the 2nd value.</typeparam>
            /// <typeparam name="T3">The type of the 3rd value.</typeparam>
            /// <typeparam name="T4">The type of the 4th value.</typeparam>
            /// <param name="buffer">The buffer into which to concatenate the values.</param>
            /// <param name="value1">The 1st value.</param>
            /// <param name="value2">The 2nd value.</param>
            /// <param name="value3">The 3rd value.</param>
            /// <param name="value4">The 4th value.</param>
            /// <returns>An instance of this string type.</returns>
            public static StatusEntity Concatenate<T1, T2, T3, T4>(Span<byte> buffer, in T1 value1, in T2 value2, in T3 value3, in T4 value4)
                where T1 : struct, IJsonValue<T1>
                where T2 : struct, IJsonValue<T2>
                where T3 : struct, IJsonValue<T3>
                where T4 : struct, IJsonValue<T4>
            {
                int written = LowAllocJsonUtils.ConcatenateAsUtf8JsonString(buffer, value1, value2, value3, value4);
                return ParseValue(buffer[..written]);
            }

            /// <summary>
            /// Concatenate 5 JSON values, producing an instance of the string type StatusEntity.
            /// </summary>
            /// <typeparam name="T1">The type of the 1st value.</typeparam>
            /// <typeparam name="T2">The type of the 2nd value.</typeparam>
            /// <typeparam name="T3">The type of the 3rd value.</typeparam>
            /// <typeparam name="T4">The type of the 4th value.</typeparam>
            /// <typeparam name="T5">The type of the 5th value.</typeparam>
            /// <param name="buffer">The buffer into which to concatenate the values.</param>
            /// <param name="value1">The 1st value.</param>
            /// <param name="value2">The 2nd value.</param>
            /// <param name="value3">The 3rd value.</param>
            /// <param name="value4">The 4th value.</param>
            /// <param name="value5">The 5th value.</param>
            /// <returns>An instance of this string type.</returns>
            public static StatusEntity Concatenate<T1, T2, T3, T4, T5>(Span<byte> buffer, in T1 value1, in T2 value2, in T3 value3, in T4 value4, in T5 value5)
                where T1 : struct, IJsonValue<T1>
                where T2 : struct, IJsonValue<T2>
                where T3 : struct, IJsonValue<T3>
                where T4 : struct, IJsonValue<T4>
                where T5 : struct, IJsonValue<T5>
            {
                int written = LowAllocJsonUtils.ConcatenateAsUtf8JsonString(buffer, value1, value2, value3, value4, value5);
                return ParseValue(buffer[..written]);
            }

            /// <summary>
            /// Concatenate 6 JSON values, producing an instance of the string type StatusEntity.
            /// </summary>
            /// <typeparam name="T1">The type of the 1st value.</typeparam>
            /// <typeparam name="T2">The type of the 2nd value.</typeparam>
            /// <typeparam name="T3">The type of the 3rd value.</typeparam>
            /// <typeparam name="T4">The type of the 4th value.</typeparam>
            /// <typeparam name="T5">The type of the 5th value.</typeparam>
            /// <typeparam name="T6">The type of the 6th value.</typeparam>
            /// <param name="buffer">The buffer into which to concatenate the values.</param>
            /// <param name="value1">The 1st value.</param>
            /// <param name="value2">The 2nd value.</param>
            /// <param name="value3">The 3rd value.</param>
            /// <param name="value4">The 4th value.</param>
            /// <param name="value5">The 5th value.</param>
            /// <param name="value6">The 6th value.</param>
            /// <returns>An instance of this string type.</returns>
            public static StatusEntity Concatenate<T1, T2, T3, T4, T5, T6>(Span<byte> buffer, in T1 value1, in T2 value2, in T3 value3, in T4 value4, in T5 value5, in T6 value6)
                where T1 : struct, IJsonValue<T1>
                where T2 : struct, IJsonValue<T2>
                where T3 : struct, IJsonValue<T3>
                where T4 : struct, IJsonValue<T4>
                where T5 : struct, IJsonValue<T5>
                where T6 : struct, IJsonValue<T6>
            {
                int written = LowAllocJsonUtils.ConcatenateAsUtf8JsonString(buffer, value1, value2, value3, value4, value5, value6);
                return ParseValue(buffer[..written]);
            }

            /// <summary>
            /// Concatenate 7 JSON values, producing an instance of the string type StatusEntity.
            /// </summary>
            /// <typeparam name="T1">The type of the 1st value.</typeparam>
            /// <typeparam name="T2">The type of the 2nd value.</typeparam>
            /// <typeparam name="T3">The type of the 3rd value.</typeparam>
            /// <typeparam name="T4">The type of the 4th value.</typeparam>
            /// <typeparam name="T5">The type of the 5th value.</typeparam>
            /// <typeparam name="T6">The type of the 6th value.</typeparam>
            /// <typeparam name="T7">The type of the 7th value.</typeparam>
            /// <param name="buffer">The buffer into which to concatenate the values.</param>
            /// <param name="value1">The 1st value.</param>
            /// <param name="value2">The 2nd value.</param>
            /// <param name="value3">The 3rd value.</param>
            /// <param name="value4">The 4th value.</param>
            /// <param name="value5">The 5th value.</param>
            /// <param name="value6">The 6th value.</param>
            /// <param name="value7">The 7th value.</param>
            /// <returns>An instance of this string type.</returns>
            public static StatusEntity Concatenate<T1, T2, T3, T4, T5, T6, T7>(Span<byte> buffer, in T1 value1, in T2 value2, in T3 value3, in T4 value4, in T5 value5, in T6 value6, in T7 value7)
                where T1 : struct, IJsonValue<T1>
                where T2 : struct, IJsonValue<T2>
                where T3 : struct, IJsonValue<T3>
                where T4 : struct, IJsonValue<T4>
                where T5 : struct, IJsonValue<T5>
                where T6 : struct, IJsonValue<T6>
                where T7 : struct, IJsonValue<T7>
            {
                int written = LowAllocJsonUtils.ConcatenateAsUtf8JsonString(buffer, value1, value2, value3, value4, value5, value6, value7);
                return ParseValue(buffer[..written]);
            }

            /// <summary>
            /// Concatenate 8 JSON values, producing an instance of the string type StatusEntity.
            /// </summary>
            /// <typeparam name="T1">The type of the 1st value.</typeparam>
            /// <typeparam name="T2">The type of the 2nd value.</typeparam>
            /// <typeparam name="T3">The type of the 3rd value.</typeparam>
            /// <typeparam name="T4">The type of the 4th value.</typeparam>
            /// <typeparam name="T5">The type of the 5th value.</typeparam>
            /// <typeparam name="T6">The type of the 6th value.</typeparam>
            /// <typeparam name="T7">The type of the 7th value.</typeparam>
            /// <typeparam name="T8">The type of the 8th value.</typeparam>
            /// <param name="buffer">The buffer into which to concatenate the values.</param>
            /// <param name="value1">The 1st value.</param>
            /// <param name="value2">The 2nd value.</param>
            /// <param name="value3">The 3rd value.</param>
            /// <param name="value4">The 4th value.</param>
            /// <param name="value5">The 5th value.</param>
            /// <param name="value6">The 6th value.</param>
            /// <param name="value7">The 7th value.</param>
            /// <param name="value8">The 8th value.</param>
            /// <returns>An instance of this string type.</returns>
            public static StatusEntity Concatenate<T1, T2, T3, T4, T5, T6, T7, T8>(Span<byte> buffer, in T1 value1, in T2 value2, in T3 value3, in T4 value4, in T5 value5, in T6 value6, in T7 value7, in T8 value8)
                where T1 : struct, IJsonValue<T1>
                where T2 : struct, IJsonValue<T2>
                where T3 : struct, IJsonValue<T3>
                where T4 : struct, IJsonValue<T4>
                where T5 : struct, IJsonValue<T5>
                where T6 : struct, IJsonValue<T6>
                where T7 : struct, IJsonValue<T7>
                where T8 : struct, IJsonValue<T8>
            {
                int written = LowAllocJsonUtils.ConcatenateAsUtf8JsonString(buffer, value1, value2, value3, value4, value5, value6, value7, value8);
                return ParseValue(buffer[..written]);
            }

            /// <inheritdoc/>
            public bool TryGetString([NotNullWhen(true)] out string? value)
            {
                if ((this.backing & Backing.String) != 0)
                {
                    value = this.stringBacking;
                    return true;
                }

                if ((this.backing & Backing.JsonElement) != 0 &&
                    this.jsonElementBacking.ValueKind == JsonValueKind.String)
                {
                    value = this.jsonElementBacking.GetString();
                    return value is not null;
                }

                value = null;
                return false;
            }

            /// <summary>
            /// Gets the string value.
            /// </summary>
            /// <returns><c>The string if this value represents a string</c>, otherwise <c>null</c>.</returns>
            public string? GetString()
            {
                if (this.TryGetString(out string? value))
                {
                    return value;
                }

                return null;
            }

            /// <summary>
            /// Compare to a sequence of characters.
            /// </summary>
            /// <param name="utf8Bytes">The UTF8-encoded character sequence to compare.</param>
            /// <returns><c>True</c> if the sequences match.</returns>
            public bool EqualsUtf8Bytes(ReadOnlySpan<byte> utf8Bytes)
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind == JsonValueKind.String)
                    {
                        return this.jsonElementBacking.ValueEquals(utf8Bytes);
                    }
                }

                if ((this.backing & Backing.String) != 0)
                {
                    int maxCharCount = System.Text.Encoding.UTF8.GetMaxCharCount(utf8Bytes.Length);
#if NET8_0_OR_GREATER
                    char[]? pooledChars = null;

                    Span<char> chars = maxCharCount <= JsonValueHelpers.MaxStackAlloc  ?
                        stackalloc char[maxCharCount] :
                        (pooledChars = ArrayPool<char>.Shared.Rent(maxCharCount));

                    try
                    {
                        int written = System.Text.Encoding.UTF8.GetChars(utf8Bytes, chars);
                        return chars[..written].SequenceEqual(this.stringBacking);
                    }
                    finally
                    {
                        if (pooledChars is char[] pc)
                        {
                            ArrayPool<char>.Shared.Return(pc);
                        }
                    }
#else
                    char[] chars = ArrayPool<char>.Shared.Rent(maxCharCount);
                    byte[] bytes = ArrayPool<byte>.Shared.Rent(utf8Bytes.Length);
                    utf8Bytes.CopyTo(bytes);

                    try
                    {
                        int written = System.Text.Encoding.UTF8.GetChars(bytes, 0, utf8Bytes.Length, chars, 0);
                        return chars.AsSpan()[..written].SequenceEqual(this.stringBacking.AsSpan());
                    }
                    finally
                    {
                        ArrayPool<char>.Shared.Return(chars);
                        ArrayPool<byte>.Shared.Return(bytes);
                    }
#endif
                }

                return false;
            }

            /// <summary>
            /// Compare to a sequence of characters.
            /// </summary>
            /// <param name="chars">The character sequence to compare.</param>
            /// <returns><c>True</c> if the sequences match.</returns>
            public bool EqualsString(string chars)
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind == JsonValueKind.String)
                    {
                        return this.jsonElementBacking.ValueEquals(chars);
                    }

                    return false;
                }

                if ((this.backing & Backing.String) != 0)
                {
                    return chars.Equals(this.stringBacking, StringComparison.Ordinal);
                }

                return false;
            }

            /// <summary>
            /// Compare to a sequence of characters.
            /// </summary>
            /// <param name="chars">The character sequence to compare.</param>
            /// <returns><c>True</c> if the sequences match.</returns>
            public bool EqualsString(ReadOnlySpan<char> chars)
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind == JsonValueKind.String)
                    {
                        return this.jsonElementBacking.ValueEquals(chars);
                    }

                    return false;
                }

                if ((this.backing & Backing.String) != 0)
                {
#if NET8_0_OR_GREATER
                    return chars.SequenceEqual(this.stringBacking);
#else
                    return chars.SequenceEqual(this.stringBacking.AsSpan());
#endif
                }

                return false;
            }

#if NET8_0_OR_GREATER
            /// <inheritdoc/>
            public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
            {
                if ((this.backing & Backing.String) != 0)
                {
                    int length = Math.Min(destination.Length, this.stringBacking.Length);
                    this.stringBacking.AsSpan(0, length).CopyTo(destination);
                    charsWritten = length;
                    return true;
                }

                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind == JsonValueKind.String)
                    {
                        char[] buffer = ArrayPool<char>.Shared.Rent(destination.Length);
                        try
                        {
                            bool result = this.jsonElementBacking.TryGetValue(FormatSpan, new CorvusOutput(buffer, destination.Length), out charsWritten);
                            if (result)
                            {
                                buffer.AsSpan(0, charsWritten).CopyTo(destination);
                            }

                            return result;
                        }
                        finally
                        {
                            ArrayPool<char>.Shared.Return(buffer);
                        }
                    }
                    else
                    {
                        string value = this.jsonElementBacking.GetRawText();
                        int length = Math.Min(destination.Length, this.stringBacking.Length);
                        this.stringBacking.AsSpan(0, length).CopyTo(destination);
                        charsWritten = length;
                        return true;
                    }
                }

                // We return true from here because we have done our best to format it, and written no characters.
                charsWritten = 0;
                return true;

                static bool FormatSpan(ReadOnlySpan<char> source, in CorvusOutput output, out int charsWritten)
                {
                    int length = Math.Min(output.Length, source.Length);
                    source[..length].CopyTo(output.Destination);
                    charsWritten = length;
                    return true;
                }
            }

            /// <inheritdoc/>
            public string ToString(string? format, IFormatProvider? formatProvider)
            {
                // There is no formatting for the string
                return this.ToString();
            }
#endif
        }
    }
}
