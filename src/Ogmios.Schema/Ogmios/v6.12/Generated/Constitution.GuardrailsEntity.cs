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
/// Constitution
/// </summary>
public readonly partial struct Constitution
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    [System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<GuardrailsEntity>))]
    public readonly partial struct GuardrailsEntity
        : IJsonValue<Generated.Constitution.GuardrailsEntity>
    {
        private readonly Backing backing;
        private readonly JsonElement jsonElementBacking;
        private readonly ImmutableList<JsonObjectProperty> objectBacking;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardrailsEntity"/> struct.
        /// </summary>
        public GuardrailsEntity()
        {
            this.jsonElementBacking = default;
            this.backing = Backing.JsonElement;
            this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardrailsEntity"/> struct.
        /// </summary>
        /// <param name="value">The value from which to construct the instance.</param>
        public GuardrailsEntity(in JsonElement value)
        {
            this.jsonElementBacking = value;
            this.backing = Backing.JsonElement;
            this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardrailsEntity"/> struct.
        /// </summary>
        /// <param name="value">The value from which to construct the instance.</param>
        public GuardrailsEntity(ImmutableList<JsonObjectProperty> value)
        {
            this.backing = Backing.Object;
            this.jsonElementBacking = default;
            this.objectBacking = value;
        }

        /// <summary>
        /// Gets the schema location from which this type was generated.
        /// </summary>
        public static string SchemaLocation { get; } = "OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.12/Source/cardano.json#/definitions/Constitution/properties/guardrails";

        /// <summary>
        /// Gets a Null instance.
        /// </summary>
        public static GuardrailsEntity Null { get; } = new(JsonValueHelpers.NullElement);

        /// <summary>
        /// Gets an Undefined instance.
        /// </summary>
        public static GuardrailsEntity Undefined { get; }

        /// <summary>
        /// Gets the default instance.
        /// </summary>
        public static GuardrailsEntity DefaultInstance { get; }

        /// <inheritdoc/>
        public JsonAny AsAny
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
        /// Gets the instance as a <see cref="Generated.Constitution.GuardrailsEntity.RequiredHash" />.
        /// </summary>
        public Generated.Constitution.GuardrailsEntity.RequiredHash AsRequiredHash
        {
            get
            {
                return this.As<Generated.Constitution.GuardrailsEntity.RequiredHash>();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the instance is a <see cref="Generated.Constitution.GuardrailsEntity.RequiredHash" />.
        /// </summary>
        public bool IsRequiredHash
        {
            get
            {
                return this.As<Generated.Constitution.GuardrailsEntity.RequiredHash>().IsValid();
            }
        }

        /// <summary>
        /// Gets the instance as a <see cref="Corvus.Json.JsonNull" />.
        /// </summary>
        public Corvus.Json.JsonNull AsJsonNull
        {
            get
            {
                return this.As<Corvus.Json.JsonNull>();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the instance is a <see cref="Corvus.Json.JsonNull" />.
        /// </summary>
        public bool IsJsonNull
        {
            get
            {
                return this.As<Corvus.Json.JsonNull>().IsValid();
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

                if ((this.backing & Backing.Object) != 0)
                {
                    return JsonValueKind.Object;
                }

                if ((this.backing & Backing.Null) != 0)
                {
                    return JsonValueKind.Null;
                }

                return JsonValueKind.Undefined;
            }
        }

        /// <summary>
        /// Conversion from JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator GuardrailsEntity(JsonAny value)
        {
            return value.As<GuardrailsEntity>();
        }

        /// <summary>
        /// Conversion to JsonAny.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(GuardrailsEntity value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Conversion to <see cref="Generated.Constitution.GuardrailsEntity.RequiredHash"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static explicit operator Generated.Constitution.GuardrailsEntity.RequiredHash(GuardrailsEntity value)
        {
            return value.As<Generated.Constitution.GuardrailsEntity.RequiredHash>();
        }

        /// <summary>
        /// Conversion from <see cref="Generated.Constitution.GuardrailsEntity.RequiredHash"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator GuardrailsEntity(Generated.Constitution.GuardrailsEntity.RequiredHash value)
        {
            return value.As<GuardrailsEntity>();
        }

        /// <summary>
        /// Operator ==.
        /// </summary>
        /// <param name="left">The lhs of the operator.</param>
        /// <param name="right">The rhs of the operator.</param>
        /// <returns>
        /// <c>True</c> if the values are equal.
        /// </returns>
        public static bool operator ==(in GuardrailsEntity left, in GuardrailsEntity right)
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
        public static bool operator !=(in GuardrailsEntity left, in GuardrailsEntity right)
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
        public static GuardrailsEntity FromJson(in JsonElement value)
        {
            return new(value);
        }

        /// <summary>
        /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
        /// </summary>
        /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
        /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GuardrailsEntity FromAny(in JsonAny value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return value.ValueKind switch
            {
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
        static GuardrailsEntity IJsonValue<GuardrailsEntity>.FromBoolean<TValue>(in TValue value)
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
        static GuardrailsEntity IJsonValue<GuardrailsEntity>.FromString<TValue>(in TValue value)
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
        static GuardrailsEntity IJsonValue<GuardrailsEntity>.FromNumber<TValue>(in TValue value)
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
        public static GuardrailsEntity FromObject<TValue>(in TValue value)
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
        static GuardrailsEntity IJsonValue<GuardrailsEntity>.FromArray<TValue>(in TValue value)
        {
            if (value.HasJsonElementBacking)
            {
                return new(value.AsJsonElement);
            }

            return Undefined;
        }
#endif

        /// <summary>
        /// Parses the GuardrailsEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static GuardrailsEntity Parse(string source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the GuardrailsEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static GuardrailsEntity Parse(Stream source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the GuardrailsEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static GuardrailsEntity Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the GuardrailsEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static GuardrailsEntity Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the GuardrailsEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        /// <param name="options">The (optional) JsonDocumentOptions.</param>
        public static GuardrailsEntity Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
        {
            using var jsonDocument = JsonDocument.Parse(source, options);
            return new(jsonDocument.RootElement.Clone());
        }

        /// <summary>
        /// Parses the GuardrailsEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static GuardrailsEntity ParseValue(string source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<GuardrailsEntity>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<GuardrailsEntity>(source.AsSpan());
#endif
        }

        /// <summary>
        /// Parses the GuardrailsEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static GuardrailsEntity ParseValue(ReadOnlySpan<char> source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<GuardrailsEntity>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<GuardrailsEntity>(source);
#endif
        }

        /// <summary>
        /// Parses the GuardrailsEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static GuardrailsEntity ParseValue(ReadOnlySpan<byte> source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<GuardrailsEntity>.ParseValue(source);
#else
            return JsonValueHelpers.ParseValue<GuardrailsEntity>(source);
#endif
        }

        /// <summary>
        /// Parses the GuardrailsEntity.
        /// </summary>
        /// <param name="source">The source of the JSON string to parse.</param>
        public static GuardrailsEntity ParseValue(ref Utf8JsonReader source)
        {
#if NET8_0_OR_GREATER
            return IJsonValue<GuardrailsEntity>.ParseValue(ref source);
#else
            return JsonValueHelpers.ParseValue<GuardrailsEntity>(ref source);
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
            return this.As<GuardrailsEntity, TTarget>();
#endif
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return
                (obj is IJsonValue jv && this.Equals(jv.As<GuardrailsEntity>())) ||
                (obj is null && this.IsNull());
        }

        /// <inheritdoc/>
        public bool Equals<T>(in T other)
            where T : struct, IJsonValue<T>
        {
            return this.Equals(other.As<GuardrailsEntity>());
        }

        /// <summary>
        /// Equality comparison.
        /// </summary>
        /// <param name="other">The other item with which to compare.</param>
        /// <returns><see langword="true"/> if the values were equal.</returns>
        public bool Equals(in GuardrailsEntity other)
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

        /// <summary>
        /// Matches the value against the composed values, and returns the result of calling the provided match function for the first match found.
        /// </summary>
        /// <typeparam name="TIn">The immutable context to pass in to the match function.</typeparam>
        /// <typeparam name="TOut">The result of calling the match function.</typeparam>
        /// <param name="context">The context to pass to the match function.</param>
        /// <param name="matchJsonNull">Match a <see cref="Corvus.Json.JsonNull"/>.</param>
        /// <param name="matchRequiredHash">Match a <see cref="Generated.Constitution.GuardrailsEntity.RequiredHash"/>.</param>
        /// <param name="defaultMatch">Match any other value.</param>
        /// <returns>An instance of the value returned by the match function.</returns>
        public TOut Match<TIn, TOut>(
            in TIn context,
            Matcher<Corvus.Json.JsonNull, TIn, TOut> matchJsonNull,
            Matcher<Generated.Constitution.GuardrailsEntity.RequiredHash, TIn, TOut> matchRequiredHash,
            Matcher<Generated.Constitution.GuardrailsEntity, TIn, TOut> defaultMatch)
        {
            Corvus.Json.JsonNull matchJsonNullValue = this.As<Corvus.Json.JsonNull>();
            if (matchJsonNullValue.IsValid())
            {
                return matchJsonNull(matchJsonNullValue, context);
            }

            Generated.Constitution.GuardrailsEntity.RequiredHash matchRequiredHashValue = this.As<Generated.Constitution.GuardrailsEntity.RequiredHash>();
            if (matchRequiredHashValue.IsValid())
            {
                return matchRequiredHash(matchRequiredHashValue, context);
            }

            return defaultMatch(this, context);
        }

        /// <summary>
        /// Matches the value against the composed values, and returns the result of calling the provided match function for the first match found.
        /// </summary>
        /// <typeparam name="TOut">The result of calling the match function.</typeparam>
        /// <param name="matchJsonNull">Match a <see cref="Corvus.Json.JsonNull"/>.</param>
        /// <param name="matchRequiredHash">Match a <see cref="Generated.Constitution.GuardrailsEntity.RequiredHash"/>.</param>
        /// <param name="defaultMatch">Match any other value.</param>
        /// <returns>An instance of the value returned by the match function.</returns>
        public TOut Match<TOut>(
            Matcher<Corvus.Json.JsonNull, TOut> matchJsonNull,
            Matcher<Generated.Constitution.GuardrailsEntity.RequiredHash, TOut> matchRequiredHash,
            Matcher<Generated.Constitution.GuardrailsEntity, TOut> defaultMatch)
        {
            Corvus.Json.JsonNull matchJsonNullValue = this.As<Corvus.Json.JsonNull>();
            if (matchJsonNullValue.IsValid())
            {
                return matchJsonNull(matchJsonNullValue);
            }

            Generated.Constitution.GuardrailsEntity.RequiredHash matchRequiredHashValue = this.As<Generated.Constitution.GuardrailsEntity.RequiredHash>();
            if (matchRequiredHashValue.IsValid())
            {
                return matchRequiredHash(matchRequiredHashValue);
            }

            return defaultMatch(this);
        }

        /// <summary>
        /// Gets the value as a <see cref="Generated.Constitution.GuardrailsEntity.RequiredHash" />.
        /// </summary>
        /// <param name="result">The result of the conversions.</param>
        /// <returns><see langword="true" /> if the conversion was valid.</returns>
        public bool TryGetAsRequiredHash(out Generated.Constitution.GuardrailsEntity.RequiredHash result)
        {
            result = this.As<Generated.Constitution.GuardrailsEntity.RequiredHash>();
            return result.IsValid();
        }

        /// <summary>
        /// Gets the value as a <see cref="Corvus.Json.JsonNull" />.
        /// </summary>
        /// <param name="result">The result of the conversions.</param>
        /// <returns><see langword="true" /> if the conversion was valid.</returns>
        public bool TryGetAsJsonNull(out Corvus.Json.JsonNull result)
        {
            result = this.As<Corvus.Json.JsonNull>();
            return result.IsValid();
        }
    }
}
