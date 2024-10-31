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
/// ogmios
/// </summary>
public readonly partial struct Ogmios
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    [System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<PointOrOrigin>))]
    public readonly partial struct PointOrOrigin
        : IJsonValue<Generated.Ogmios.PointOrOrigin>
    {
        private readonly Backing backing;
        private readonly JsonElement jsonElementBacking;
        private readonly string stringBacking;
        private readonly ImmutableList<JsonObjectProperty> objectBacking;

        /// <summary>
        /// Initializes a new instance of the <see cref="PointOrOrigin"/> struct.
        /// </summary>
        public PointOrOrigin()
        {
            this.jsonElementBacking = default;
            this.backing = Backing.JsonElement;
            this.stringBacking = string.Empty;
            this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointOrOrigin"/> struct.
        /// </summary>
        /// <param name="value">The value from which to construct the instance.</param>
        public PointOrOrigin(in JsonElement value)
        {
            this.jsonElementBacking = value;
            this.backing = Backing.JsonElement;
            this.stringBacking = string.Empty;
            this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointOrOrigin"/> struct.
        /// </summary>
        /// <param name="value">The value from which to construct the instance.</param>
        public PointOrOrigin(ImmutableList<JsonObjectProperty> value)
        {
            this.backing = Backing.Object;
            this.jsonElementBacking = default;
            this.stringBacking = string.Empty;
            this.objectBacking = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointOrOrigin"/> struct.
        /// </summary>
        /// <param name="value">The value from which to construct the instance.</param>
        public PointOrOrigin(string value)
        {
            this.backing = Backing.String;
            this.jsonElementBacking = default;
            this.stringBacking = value;
            this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
        }

        /// <summary>
        /// Gets the schema location from which this type was generated.
        /// </summary>
        public static string SchemaLocation { get; } = "https://endjin.com/Users/davebeaumont/source/cardano-public/OgmiosDotnet/src/Domain/Schemas/Ogmios/Generated/ogmios.json#/definitions/PointOrOrigin";

        /// <summary>
        /// Gets a Null instance.
        /// </summary>
        public static PointOrOrigin Null { get; } = new(JsonValueHelpers.NullElement);

        /// <summary>
        /// Gets an Undefined instance.
        /// </summary>
        public static PointOrOrigin Undefined { get; }

        /// <summary>
        /// Gets the default instance.
        /// </summary>
        public static PointOrOrigin DefaultInstance { get; }

        /// <inheritdoc/>
        public JsonAny AsAny
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return new(this.jsonElementBacking);
                }

                if ((this.backing & Backing.String) != 0)
                {
                    return new(this.stringBacking);
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    return new(this.objectBacking);
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

                if ((this.backing & Backing.String) != 0)
                {
                    return JsonValueHelpers.StringToJsonElement(this.stringBacking);
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    return JsonValueHelpers.ObjectToJsonElement(this.objectBacking);
                }

                if ((this.backing & Backing.Null) != 0)
                {
                    return JsonValueHelpers.NullElement;
                }

                return default;
            }
        }

        /// <inheritdoc/>
        public JsonString AsString
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return new(this.jsonElementBacking);
                }

                if ((this.backing & Backing.String) != 0)
                {
                    return new(this.stringBacking);
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
        public JsonObject AsObject
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    return new(this.jsonElementBacking);
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    return new(this.objectBacking);
                }

                throw new InvalidOperationException();
            }
        }

        /// <inheritdoc/>
        JsonArray IJsonValue.AsArray
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

        /// <summary>
        /// Gets the instance as a <see cref="Generated.Origin" />.
        /// </summary>
        public Generated.Origin AsOrigin
        {
            get
            {
                return this.As<Generated.Origin>();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the instance is a <see cref="Generated.Origin" />.
        /// </summary>
        public bool IsOrigin
        {
            get
            {
                return this.As<Generated.Origin>().IsValid();
            }
        }

        /// <summary>
        /// Gets the instance as a <see cref="Generated.Ogmios.PointOrOrigin.Point" />.
        /// </summary>
        public Generated.Ogmios.PointOrOrigin.Point AsPoint
        {
            get
            {
                return this.As<Generated.Ogmios.PointOrOrigin.Point>();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the instance is a <see cref="Generated.Ogmios.PointOrOrigin.Point" />.
        /// </summary>
        public bool IsPoint
        {
            get
            {
                return this.As<Generated.Ogmios.PointOrOrigin.Point>().IsValid();
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

                if ((this.backing & Backing.String) != 0)
                {
                    return JsonValueKind.String;
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    return JsonValueKind.Object;
                }

                return JsonValueKind.Undefined;
            }
        }

        /// <summary>
        /// Conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator PointOrOrigin(JsonAny value)
        {
            return value.As<PointOrOrigin>();
        }

        /// <summary>
        /// Conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(PointOrOrigin value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Conversion to <see cref="Generated.Ogmios.PointOrOrigin.Point"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static explicit operator Generated.Ogmios.PointOrOrigin.Point(PointOrOrigin value)
        {
            return value.As<Generated.Ogmios.PointOrOrigin.Point>();
        }

        /// <summary>
        /// Conversion from <see cref="Generated.Ogmios.PointOrOrigin.Point"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator PointOrOrigin(Generated.Ogmios.PointOrOrigin.Point value)
        {
            return value.As<PointOrOrigin>();
        }

        /// <summary>
        /// Conversion to <see cref="Generated.Origin"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static explicit operator Generated.Origin(PointOrOrigin value)
        {
            return value.As<Generated.Origin>();
        }

        /// <summary>
        /// Conversion from <see cref="Generated.Origin"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator PointOrOrigin(Generated.Origin value)
        {
            return value.As<PointOrOrigin>();
        }

        /// <summary>
        /// Operator ==.
        /// </summary>
        /// <param name="left">The lhs of the operator.</param>
        /// <param name="right">The rhs of the operator.</param>
        /// <returns>
        /// <c>True</c> if the values are equal.
        /// </returns>
        public static bool operator ==(in PointOrOrigin left, in PointOrOrigin right)
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
        public static bool operator !=(in PointOrOrigin left, in PointOrOrigin right)
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
        public static PointOrOrigin FromJson(in JsonElement value)
        {
            return new(value);
        }

        /// <summary>
        /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
        /// </summary>
        /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
        /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointOrOrigin FromAny(in JsonAny value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
                JsonValueKind.String => new(value.AsString.GetString()!),
                JsonValueKind.Object => new(value.AsObject.AsPropertyBacking()),
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
        static PointOrOrigin IJsonValue<PointOrOrigin>.FromBoolean<TValue>(in TValue value)
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
        public static PointOrOrigin FromString<TValue>(in TValue value)
            where TValue : struct, IJsonString<TValue>
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
                JsonValueKind.String => new(value.GetString()!),
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
        static PointOrOrigin IJsonValue<PointOrOrigin>.FromNumber<TValue>(in TValue value)
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
        public static PointOrOrigin FromObject<TValue>(in TValue value)
            where TValue : struct, IJsonObject<TValue>
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
                JsonValueKind.Object => new(value.AsPropertyBacking()),
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
        static PointOrOrigin IJsonValue<PointOrOrigin>.FromArray<TValue>(in TValue value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return Undefined;
        }
#endif

        /// <summary>
        /// Parses the PointOrOrigin.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static PointOrOrigin Parse(string source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the PointOrOrigin.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static PointOrOrigin Parse(Stream source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the PointOrOrigin.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static PointOrOrigin Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the PointOrOrigin.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static PointOrOrigin Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the PointOrOrigin.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static PointOrOrigin Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the PointOrOrigin.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static PointOrOrigin ParseValue(string source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<PointOrOrigin>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<PointOrOrigin>(source.AsSpan());
#endif
        }

        /// <summary>
        /// Parses the PointOrOrigin.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static PointOrOrigin ParseValue(ReadOnlySpan<char> source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<PointOrOrigin>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<PointOrOrigin>(source);
#endif
        }

        /// <summary>
        /// Parses the PointOrOrigin.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static PointOrOrigin ParseValue(ReadOnlySpan<byte> source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<PointOrOrigin>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<PointOrOrigin>(source);
#endif
        }

        /// <summary>
        /// Parses the PointOrOrigin.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static PointOrOrigin ParseValue(ref Utf8JsonReader source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<PointOrOrigin>.ParseValue(ref source);
#else
            return JsonValueHelpers.ParseValue<PointOrOrigin>(ref source);
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

            if ((this.backing & Backing.String) != 0)
            {
                return TTarget.FromString(this.AsString);
            }

            if ((this.backing & Backing.Object) != 0)
            {
                return TTarget.FromObject(this.AsObject);
            }

            if ((this.backing & Backing.Null) != 0)
            {
                return TTarget.Null;
            }

            return TTarget.Undefined;
#else
            return this.As<PointOrOrigin, TTarget>();
#endif
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return
                (obj is IJsonValue jv && this.Equals(jv.As<PointOrOrigin>())) ||
                (obj is null && this.IsNull());
        }

        /// <inheritdoc/>
        public bool Equals<T>(in T other)
            where T : struct, IJsonValue<T>
        {
            return this.Equals(other.As<PointOrOrigin>());
        }

        /// <summary>
        /// Equality comparison.
        /// </summary>
        /// <param name="other">The other item with which to compare.</param>
        /// <returns><see langword="true"/> if the values were equal.</returns>
        public bool Equals(in PointOrOrigin other)
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

            if (thisKind == JsonValueKind.Object)
            {
                JsonObject thisObject = this.AsObject;
                JsonObject otherObject = other.AsObject;
                int count = 0;
                foreach (JsonObjectProperty property in thisObject.EnumerateObject())
                {
                    if (!otherObject.TryGetProperty(property.Name, out JsonAny value) || !property.Value.Equals(value))
                    {
                        return false;
                    }

                    count++;
                }

                int otherCount = 0;
                foreach (JsonObjectProperty otherProperty in otherObject.EnumerateObject())
                {
                    otherCount++;
                    if (otherCount > count)
                    {
                        return false;
                    }
                }

                return count == otherCount;
            }

            if (thisKind == JsonValueKind.String)
            {
                if (this.backing == Backing.JsonElement)
                {
                    if (other.backing == Backing.String)
                    {
                        return this.jsonElementBacking.ValueEquals(other.stringBacking);
                    }
                    else
                    {
                        other.jsonElementBacking.TryGetValue(CompareValues, this.jsonElementBacking, out bool areEqual);
                        return areEqual;
                    }

                }

                if (other.backing == Backing.JsonElement)
                {
                    return other.jsonElementBacking.ValueEquals(this.stringBacking);
                }

                return this.stringBacking.Equals(other.stringBacking);

                static bool CompareValues(ReadOnlySpan<byte> span, in JsonElement firstItem, out bool value)
                {
                    value = firstItem.ValueEquals(span);
                    return true;
                }
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

            if ((this.backing & Backing.Object) != 0)
            {
                JsonValueHelpers.WriteProperties(this.objectBacking, writer);

                return;
            }

            if ((this.backing & Backing.String) != 0)
            {
                writer.WriteStringValue(this.stringBacking);

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
                JsonValueKind.Array => JsonValueHelpers.GetArrayHashCode(((IJsonValue)this).AsArray),
                JsonValueKind.Object => JsonValueHelpers.GetObjectHashCode(this),
                JsonValueKind.Number => JsonValueHelpers.GetHashCodeForNumber(((IJsonValue)this).AsNumber),
                JsonValueKind.String => JsonValueHelpers.GetHashCodeForString(this),
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

        /// <summary>
        /// Matches the value against the composed values, and returns the result of calling the provided match function for the first match found.
        /// </summary>
        /// <typeparam name="TIn">The immutable context to pass in to the match function.</typeparam>
        /// <typeparam name="TOut">The result of calling the match function.</typeparam>
        /// <param name="context">The context to pass to the match function.</param>
        /// <param name="matchPoint">Match a <see cref="Generated.Ogmios.PointOrOrigin.Point"/>.</param>
        /// <param name="matchOrigin">Match a <see cref="Generated.Origin"/>.</param>
        /// <param name="defaultMatch">Match any other value.</param>
        /// <returns>An instance of the value returned by the match function.</returns>
        public TOut Match<TIn, TOut>(
            in TIn context,
            Matcher<Generated.Ogmios.PointOrOrigin.Point, TIn, TOut> matchPoint,
            Matcher<Generated.Origin, TIn, TOut> matchOrigin,
            Matcher<Generated.Ogmios.PointOrOrigin, TIn, TOut> defaultMatch)
        {
            Generated.Ogmios.PointOrOrigin.Point matchPointValue = this.As<Generated.Ogmios.PointOrOrigin.Point>();
            if (matchPointValue.IsValid())
            {
                return matchPoint(matchPointValue, context);
            }

            Generated.Origin matchOriginValue = this.As<Generated.Origin>();
            if (matchOriginValue.IsValid())
            {
                return matchOrigin(matchOriginValue, context);
            }

            return defaultMatch(this, context);
        }

        /// <summary>
        /// Matches the value against the composed values, and returns the result of calling the provided match function for the first match found.
        /// </summary>
        /// <typeparam name="TOut">The result of calling the match function.</typeparam>
        /// <param name="matchPoint">Match a <see cref="Generated.Ogmios.PointOrOrigin.Point"/>.</param>
        /// <param name="matchOrigin">Match a <see cref="Generated.Origin"/>.</param>
        /// <param name="defaultMatch">Match any other value.</param>
        /// <returns>An instance of the value returned by the match function.</returns>
        public TOut Match<TOut>(
            Matcher<Generated.Ogmios.PointOrOrigin.Point, TOut> matchPoint,
            Matcher<Generated.Origin, TOut> matchOrigin,
            Matcher<Generated.Ogmios.PointOrOrigin, TOut> defaultMatch)
        {
            Generated.Ogmios.PointOrOrigin.Point matchPointValue = this.As<Generated.Ogmios.PointOrOrigin.Point>();
            if (matchPointValue.IsValid())
            {
                return matchPoint(matchPointValue);
            }

            Generated.Origin matchOriginValue = this.As<Generated.Origin>();
            if (matchOriginValue.IsValid())
            {
                return matchOrigin(matchOriginValue);
            }

            return defaultMatch(this);
        }

        /// <summary>
        /// Gets the value as a <see cref="Generated.Origin" />.
        /// </summary>
        /// <param name="result">The result of the conversions.</param>
        /// <returns><see langword="true" /> if the conversion was valid.</returns>
        public bool TryGetAsOrigin(out Generated.Origin result)
        {
            result = this.As<Generated.Origin>();
            return result.IsValid();
        }

        /// <summary>
        /// Gets the value as a <see cref="Generated.Ogmios.PointOrOrigin.Point" />.
        /// </summary>
        /// <param name="result">The result of the conversions.</param>
        /// <returns><see langword="true" /> if the conversion was valid.</returns>
        public bool TryGetAsPoint(out Generated.Ogmios.PointOrOrigin.Point result)
        {
            result = this.As<Generated.Ogmios.PointOrOrigin.Point>();
            return result.IsValid();
        }
    }
}
