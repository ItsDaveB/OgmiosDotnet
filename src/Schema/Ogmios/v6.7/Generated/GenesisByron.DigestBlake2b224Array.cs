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
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

namespace Generated;

/// <summary>
/// Genesis<Byron>
/// </summary>
/// <remarks>
/// <para>
/// A Byron genesis configuration, with information used to bootstrap the era. Some parameters are also updatable across the era.
/// </para>
/// </remarks>
public readonly partial struct GenesisByron
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    [System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<DigestBlake2b224Array>))]
    public readonly partial struct DigestBlake2b224Array

    {
        private readonly Backing backing;
        private readonly JsonElement jsonElementBacking;
        private readonly ImmutableList<JsonAny> arrayBacking;

        /// <summary>
        /// Initializes a new instance of the <see cref="DigestBlake2b224Array"/> struct.
        /// </summary>
        public DigestBlake2b224Array()
        {
            this.jsonElementBacking = default;
            this.backing = Backing.JsonElement;
            this.arrayBacking = ImmutableList<JsonAny>.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DigestBlake2b224Array"/> struct.
        /// </summary>
        /// <param name="value">The value from which to construct the instance.</param>
        public DigestBlake2b224Array(in JsonElement value)
        {
            this.jsonElementBacking = value;
            this.backing = Backing.JsonElement;
            this.arrayBacking = ImmutableList<JsonAny>.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DigestBlake2b224Array"/> struct.
        /// </summary>
        /// <param name="value">The value from which to construct the instance.</param>
        public DigestBlake2b224Array(ImmutableList<JsonAny> value)
        {
            this.backing = Backing.Array;
            this.jsonElementBacking = default;
            this.arrayBacking = value;
        }

        /// <summary>
        /// Gets the schema location from which this type was generated.
        /// </summary>
        public static string SchemaLocation { get; } = "https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Domain/Schemas/Ogmios/Generated/cardano.json#/definitions/Genesis<Byron>/properties/genesisKeyHashes";

        /// <summary>
        /// Gets a Null instance.
        /// </summary>
        public static DigestBlake2b224Array Null { get; } = new(JsonValueHelpers.NullElement);

        /// <summary>
        /// Gets an Undefined instance.
        /// </summary>
        public static DigestBlake2b224Array Undefined { get; }

        /// <summary>
        /// Gets the default instance.
        /// </summary>
        public static DigestBlake2b224Array DefaultInstance { get; }

        /// <inheritdoc/>
        public JsonAny AsAny
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return new(this.jsonElementBacking);
                }

                if ((this.backing & Backing.Array) != 0)
                {
                    return new(this.arrayBacking);
                }

                if ((this.backing & Backing.Null) != 0)
                {
                    return JsonAny.Null;
                }

                return JsonAny.Undefined;
            }
        }

        /// <inheritdoc/>
        public JsonElement AsJsonElement
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return this.jsonElementBacking;
                }

                if ((this.backing & Backing.Array) != 0)
                {
                    return JsonValueHelpers.ArrayToJsonElement(this.arrayBacking);
                }

                if ((this.backing & Backing.Null) != 0)
                {
                    return JsonValueHelpers.NullElement;
                }

                return default;
            }
        }

        /// <inheritdoc/>
        JsonString IJsonValue.AsString
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return new(this.jsonElementBacking);
                }

                throw new InvalidOperationException();
            }
        }

        /// <inheritdoc/>
        JsonBoolean IJsonValue.AsBoolean
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return new(this.jsonElementBacking);
                }

                throw new InvalidOperationException();
            }
        }

        /// <inheritdoc/>
        JsonNumber IJsonValue.AsNumber
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return new(this.jsonElementBacking);
                }

                throw new InvalidOperationException();
            }
        }

        /// <inheritdoc/>
        JsonObject IJsonValue.AsObject
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return new(this.jsonElementBacking);
                }

                throw new InvalidOperationException();
            }
        }

        /// <inheritdoc/>
        public JsonArray AsArray
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return new(this.jsonElementBacking);
                }

                if ((this.backing & Backing.Array) != 0)
                {
                    return new(this.arrayBacking);
                }

                throw new InvalidOperationException();
            }
        }

        /// <inheritdoc/>
        public bool HasJsonElementBacking
        {
            get
            {
                return (this.backing & Backing.JsonElement) != 0;
            }
        }

        /// <inheritdoc/>
        public bool HasDotnetBacking
        {
            get
            {
                return (this.backing & Backing.Dotnet) != 0;
            }
        }

        /// <inheritdoc/>
        public JsonValueKind ValueKind
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return this.jsonElementBacking.ValueKind;
                }

                if ((this.backing & Backing.Array) != 0)
                {
                    return JsonValueKind.Array;
                }

                return JsonValueKind.Undefined;
            }
        }

        /// <summary>
        /// Conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator DigestBlake2b224Array(JsonAny value)
        {
            return value.As<DigestBlake2b224Array>();
        }

        /// <summary>
        /// Conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(DigestBlake2b224Array value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Operator ==.
        /// </summary>
        /// <param name="left">The lhs of the operator.</param>
        /// <param name="right">The rhs of the operator.</param>
        /// <returns>
        /// <c>True</c> if the values are equal.
        /// </returns>
        public static bool operator ==(in DigestBlake2b224Array left, in DigestBlake2b224Array right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Operator !=.
        /// </summary>
        /// <param name="left">The lhs of the operator.</param>
        /// <param name="right">The rhs of the operator.</param>
        /// <returns>
        /// <c>True</c> if the values are not equal.
        /// </returns>
        public static bool operator !=(in DigestBlake2b224Array left, in DigestBlake2b224Array right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Gets an instance of the JSON value from a <see cref="JsonElement"/> value.
        /// </summary>
        /// <param name="value">The <see cref="JsonElement"/> value from which to instantiate the instance.</param>
        /// <returns>An instance of this type, initialized from the <see cref="JsonElement"/>.</returns>
        /// <remarks>The returned value will have a <see cref = "IJsonValue.ValueKind"/> of <see cref = "JsonValueKind.Undefined"/> if the
        /// value cannot be constructed from the given instance (e.g. because they have an incompatible .NET backing type).
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DigestBlake2b224Array FromJson(in JsonElement value)
        {
            return new(value);
        }

        /// <summary>
        /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
        /// </summary>
        /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
        /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DigestBlake2b224Array FromAny(in JsonAny value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
                JsonValueKind.Array => new(value.AsArray.AsImmutableList()),
                JsonValueKind.Null => Null,
                _ => Undefined,
            };
        }

#if NET8_0_OR_GREATER
        /// <summary>
        /// Gets an instance of the JSON value from the provided value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value from which to instantiate the instance.</param>
        /// <returns>An instance of this type, initialized from the provided value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DigestBlake2b224Array IJsonValue<DigestBlake2b224Array>.FromBoolean<TValue>(in TValue value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return Undefined;
        }
#endif

#if NET8_0_OR_GREATER
        /// <summary>
        /// Gets an instance of the JSON value from the provided value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value from which to instantiate the instance.</param>
        /// <returns>An instance of this type, initialized from the provided value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DigestBlake2b224Array IJsonValue<DigestBlake2b224Array>.FromString<TValue>(in TValue value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return Undefined;
        }
#endif

#if NET8_0_OR_GREATER
        /// <summary>
        /// Gets an instance of the JSON value from the provided value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value from which to instantiate the instance.</param>
        /// <returns>An instance of this type, initialized from the provided value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DigestBlake2b224Array IJsonValue<DigestBlake2b224Array>.FromNumber<TValue>(in TValue value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return Undefined;
        }
#endif

#if NET8_0_OR_GREATER
        /// <summary>
        /// Gets an instance of the JSON value from the provided value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value from which to instantiate the instance.</param>
        /// <returns>An instance of this type, initialized from the provided value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static DigestBlake2b224Array IJsonValue<DigestBlake2b224Array>.FromObject<TValue>(in TValue value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return Undefined;
        }
#endif

        /// <summary>
        /// Gets an instance of the JSON value from the provided value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value from which to instantiate the instance.</param>
        /// <returns>An instance of this type, initialized from the provided value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DigestBlake2b224Array FromArray<TValue>(in TValue value)
            where TValue : struct, IJsonArray<TValue>
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
                JsonValueKind.Array => new(value.AsImmutableList()),
                JsonValueKind.Null => Null,
                _ => Undefined,
            };
        }

        /// <summary>
        /// Parses the DigestBlake2b224Array.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static DigestBlake2b224Array Parse(string source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the DigestBlake2b224Array.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static DigestBlake2b224Array Parse(Stream source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the DigestBlake2b224Array.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static DigestBlake2b224Array Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the DigestBlake2b224Array.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static DigestBlake2b224Array Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the DigestBlake2b224Array.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static DigestBlake2b224Array Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the DigestBlake2b224Array.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static DigestBlake2b224Array ParseValue(string source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<DigestBlake2b224Array>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<DigestBlake2b224Array>(source.AsSpan());
#endif
        }

        /// <summary>
        /// Parses the DigestBlake2b224Array.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static DigestBlake2b224Array ParseValue(ReadOnlySpan<char> source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<DigestBlake2b224Array>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<DigestBlake2b224Array>(source);
#endif
        }

        /// <summary>
        /// Parses the DigestBlake2b224Array.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static DigestBlake2b224Array ParseValue(ReadOnlySpan<byte> source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<DigestBlake2b224Array>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<DigestBlake2b224Array>(source);
#endif
        }

        /// <summary>
        /// Parses the DigestBlake2b224Array.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static DigestBlake2b224Array ParseValue(ref Utf8JsonReader source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<DigestBlake2b224Array>.ParseValue(ref source);
#else
            return JsonValueHelpers.ParseValue<DigestBlake2b224Array>(ref source);
#endif
        }

        /// <summary>
        /// Gets the value as an instance of the target value.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <returns>An instance of the target type.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TTarget As<TTarget>()
            where TTarget : struct, IJsonValue<TTarget>
        {
#if NET8_0_OR_GREATER
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return TTarget.FromJson(this.jsonElementBacking);
            }

            if ((this.backing & Backing.Array) != 0)
            {
                return TTarget.FromArray(this);
            }

            if ((this.backing & Backing.Null) != 0)
            {
                return TTarget.Null;
            }

            return TTarget.Undefined;
#else
            return this.As<DigestBlake2b224Array, TTarget>();
#endif
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return
                (obj is IJsonValue jv && this.Equals(jv.As<DigestBlake2b224Array>())) ||
                (obj is null && this.IsNull());
        }

        /// <inheritdoc/>
        public bool Equals<T>(in T other)
            where T : struct, IJsonValue<T>
        {
            return this.Equals(other.As<DigestBlake2b224Array>());
        }

        /// <summary>
        /// Equality comparison.
        /// </summary>
        /// <param name="other">The other item with which to compare.</param>
        /// <returns><see langword="true"/> if the values were equal.</returns>
        public bool Equals(in DigestBlake2b224Array other)
        {
            JsonValueKind thisKind = this.ValueKind;
            JsonValueKind otherKind = other.ValueKind;
            if (thisKind != otherKind)
            {
                return false;
            }

            if (thisKind == JsonValueKind.Null || thisKind == JsonValueKind.Undefined)
            {
                return true;
            }

            if (thisKind == JsonValueKind.Array)
            {
                JsonArrayEnumerator<Generated.DigestBlake2b224> lhs = this.EnumerateArray();
                JsonArrayEnumerator<Generated.DigestBlake2b224> rhs = other.EnumerateArray();
                while (lhs.MoveNext())
                {
                    if (!rhs.MoveNext())
                    {
                        return false;
                    }

                    if (!lhs.Current.Equals(rhs.Current))
                    {
                        return false;
                    }
                }

                return !rhs.MoveNext();
            }

            return false;
        }

        /// <inheritdoc/>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                if (this.jsonElementBacking.ValueKind != JsonValueKind.Undefined)
                {
                    this.jsonElementBacking.WriteTo(writer);
                }

                return;
            }

            if ((this.backing & Backing.Array) != 0)
            {
                JsonValueHelpers.WriteItems(this.arrayBacking, writer);

                return;
            }

            if ((this.backing & Backing.Null) != 0)
            {
                writer.WriteNullValue();

                return;
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.ValueKind switch
            {
                JsonValueKind.Array => JsonValueHelpers.GetArrayHashCode(this),
                JsonValueKind.Object => JsonValueHelpers.GetObjectHashCode(((IJsonValue)this).AsObject),
                JsonValueKind.Number => JsonValueHelpers.GetHashCodeForNumber(((IJsonValue)this).AsNumber),
                JsonValueKind.String => JsonValueHelpers.GetHashCodeForString(((IJsonValue)this).AsString),
                JsonValueKind.True => true.GetHashCode(),
                JsonValueKind.False => false.GetHashCode(),
                JsonValueKind.Null => JsonValueHelpers.NullHashCode,
                _ => JsonValueHelpers.UndefinedHashCode,
            };
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Serialize();
        }
    }
}
