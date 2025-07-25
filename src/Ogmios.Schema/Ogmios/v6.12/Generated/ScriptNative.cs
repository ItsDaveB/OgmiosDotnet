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
/// Script&lt;Native&gt;
/// </summary>
/// <remarks>
/// <para>
/// A phase-1 monetary script. Timelocks constraints are only supported since Allegra.
/// </para>
/// </remarks>
[System.Text.Json.Serialization.JsonConverter(typeof(Corvus.Json.Internal.JsonValueConverter<ScriptNative>))]
public readonly partial struct ScriptNative
    : IJsonValue<Generated.ScriptNative>
{
    private readonly Backing backing;
    private readonly JsonElement jsonElementBacking;
    private readonly ImmutableList<JsonObjectProperty> objectBacking;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptNative"/> struct.
    /// </summary>
    public ScriptNative()
    {
        this.jsonElementBacking = default;
        this.backing = Backing.JsonElement;
        this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptNative"/> struct.
    /// </summary>
    /// <param name="value">The value from which to construct the instance.</param>
    public ScriptNative(in JsonElement value)
    {
        this.jsonElementBacking = value;
        this.backing = Backing.JsonElement;
        this.objectBacking = ImmutableList<JsonObjectProperty>.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptNative"/> struct.
    /// </summary>
    /// <param name="value">The value from which to construct the instance.</param>
    public ScriptNative(ImmutableList<JsonObjectProperty> value)
    {
        this.backing = Backing.Object;
        this.jsonElementBacking = default;
        this.objectBacking = value;
    }

    /// <summary>
    /// Gets the schema location from which this type was generated.
    /// </summary>
    public static string SchemaLocation { get; } = "OgmiosDotnet/src/Ogmios.Schema/Ogmios/v6.12/Source/cardano.json#/definitions/Script<Native>";

    /// <summary>
    /// Gets a Null instance.
    /// </summary>
    public static ScriptNative Null { get; } = new(JsonValueHelpers.NullElement);

    /// <summary>
    /// Gets an Undefined instance.
    /// </summary>
    public static ScriptNative Undefined { get; }

    /// <summary>
    /// Gets the default instance.
    /// </summary>
    public static ScriptNative DefaultInstance { get; }

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
    /// Gets the instance as a <see cref="Generated.ScriptNative.ClauseSignature" />.
    /// </summary>
    public Generated.ScriptNative.ClauseSignature AsClauseSignature
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseSignature>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.ScriptNative.ClauseSignature" />.
    /// </summary>
    public bool IsClauseSignature
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseSignature>().IsValid();
        }
    }

    /// <summary>
    /// Gets the instance as a <see cref="Generated.ScriptNative.ClauseAny" />.
    /// </summary>
    public Generated.ScriptNative.ClauseAny AsClauseAny
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseAny>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.ScriptNative.ClauseAny" />.
    /// </summary>
    public bool IsClauseAny
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseAny>().IsValid();
        }
    }

    /// <summary>
    /// Gets the instance as a <see cref="Generated.ScriptNative.ClauseAll" />.
    /// </summary>
    public Generated.ScriptNative.ClauseAll AsClauseAll
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseAll>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.ScriptNative.ClauseAll" />.
    /// </summary>
    public bool IsClauseAll
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseAll>().IsValid();
        }
    }

    /// <summary>
    /// Gets the instance as a <see cref="Generated.ScriptNative.ClauseSome" />.
    /// </summary>
    public Generated.ScriptNative.ClauseSome AsClauseSome
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseSome>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.ScriptNative.ClauseSome" />.
    /// </summary>
    public bool IsClauseSome
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseSome>().IsValid();
        }
    }

    /// <summary>
    /// Gets the instance as a <see cref="Generated.ScriptNative.ClauseBefore" />.
    /// </summary>
    public Generated.ScriptNative.ClauseBefore AsClauseBefore
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseBefore>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.ScriptNative.ClauseBefore" />.
    /// </summary>
    public bool IsClauseBefore
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseBefore>().IsValid();
        }
    }

    /// <summary>
    /// Gets the instance as a <see cref="Generated.ScriptNative.ClauseAfter" />.
    /// </summary>
    public Generated.ScriptNative.ClauseAfter AsClauseAfter
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseAfter>();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the instance is a <see cref="Generated.ScriptNative.ClauseAfter" />.
    /// </summary>
    public bool IsClauseAfter
    {
        get
        {
            return this.As<Generated.ScriptNative.ClauseAfter>().IsValid();
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

            return JsonValueKind.Undefined;
        }
    }

    /// <summary>
    /// Conversion from JsonAny.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator ScriptNative(JsonAny value)
    {
        return value.As<ScriptNative>();
    }

    /// <summary>
    /// Conversion to JsonAny.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator JsonAny(ScriptNative value)
    {
        return value.AsAny;
    }

    /// <summary>
    /// Conversion to <see cref="Generated.ScriptNative.ClauseSignature"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.ScriptNative.ClauseSignature(ScriptNative value)
    {
        return value.As<Generated.ScriptNative.ClauseSignature>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.ScriptNative.ClauseSignature"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator ScriptNative(Generated.ScriptNative.ClauseSignature value)
    {
        return value.As<ScriptNative>();
    }

    /// <summary>
    /// Conversion to <see cref="Generated.ScriptNative.ClauseAny"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.ScriptNative.ClauseAny(ScriptNative value)
    {
        return value.As<Generated.ScriptNative.ClauseAny>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.ScriptNative.ClauseAny"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator ScriptNative(Generated.ScriptNative.ClauseAny value)
    {
        return value.As<ScriptNative>();
    }

    /// <summary>
    /// Conversion to <see cref="Generated.ScriptNative.ClauseAll"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.ScriptNative.ClauseAll(ScriptNative value)
    {
        return value.As<Generated.ScriptNative.ClauseAll>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.ScriptNative.ClauseAll"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator ScriptNative(Generated.ScriptNative.ClauseAll value)
    {
        return value.As<ScriptNative>();
    }

    /// <summary>
    /// Conversion to <see cref="Generated.ScriptNative.ClauseSome"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.ScriptNative.ClauseSome(ScriptNative value)
    {
        return value.As<Generated.ScriptNative.ClauseSome>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.ScriptNative.ClauseSome"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator ScriptNative(Generated.ScriptNative.ClauseSome value)
    {
        return value.As<ScriptNative>();
    }

    /// <summary>
    /// Conversion to <see cref="Generated.ScriptNative.ClauseBefore"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.ScriptNative.ClauseBefore(ScriptNative value)
    {
        return value.As<Generated.ScriptNative.ClauseBefore>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.ScriptNative.ClauseBefore"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator ScriptNative(Generated.ScriptNative.ClauseBefore value)
    {
        return value.As<ScriptNative>();
    }

    /// <summary>
    /// Conversion to <see cref="Generated.ScriptNative.ClauseAfter"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static explicit operator Generated.ScriptNative.ClauseAfter(ScriptNative value)
    {
        return value.As<Generated.ScriptNative.ClauseAfter>();
    }

    /// <summary>
    /// Conversion from <see cref="Generated.ScriptNative.ClauseAfter"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator ScriptNative(Generated.ScriptNative.ClauseAfter value)
    {
        return value.As<ScriptNative>();
    }

    /// <summary>
    /// Operator ==.
    /// </summary>
    /// <param name="left">The lhs of the operator.</param>
    /// <param name="right">The rhs of the operator.</param>
    /// <returns>
    /// <c>True</c> if the values are equal.
    /// </returns>
    public static bool operator ==(in ScriptNative left, in ScriptNative right)
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
    public static bool operator !=(in ScriptNative left, in ScriptNative right)
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
    public static ScriptNative FromJson(in JsonElement value)
    {
        return new(value);
    }

    /// <summary>
    /// Gets an instance of the JSON value from a <see cref="JsonAny"/> value.
    /// </summary>
    /// <param name="value">The <see cref="JsonAny"/> value from which to instantiate the instance.</param>
    /// <returns>An instance of this type, initialized from the <see cref="JsonAny"/> value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ScriptNative FromAny(in JsonAny value)
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
    static ScriptNative IJsonValue<ScriptNative>.FromBoolean<TValue>(in TValue value)
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
    static ScriptNative IJsonValue<ScriptNative>.FromString<TValue>(in TValue value)
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
    static ScriptNative IJsonValue<ScriptNative>.FromNumber<TValue>(in TValue value)
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
    public static ScriptNative FromObject<TValue>(in TValue value)
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
    static ScriptNative IJsonValue<ScriptNative>.FromArray<TValue>(in TValue value)
    {
        if (value.HasJsonElementBacking)
        {
            return new(value.AsJsonElement);
        }

        return Undefined;
    }
#endif

    /// <summary>
    /// Parses the ScriptNative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static ScriptNative Parse(string source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the ScriptNative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static ScriptNative Parse(Stream source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the ScriptNative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static ScriptNative Parse(ReadOnlyMemory<byte> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the ScriptNative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static ScriptNative Parse(ReadOnlyMemory<char> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the ScriptNative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    /// <param name="options">The (optional) JsonDocumentOptions.</param>
    public static ScriptNative Parse(ReadOnlySequence<byte> source, JsonDocumentOptions options = default)
    {
        using var jsonDocument = JsonDocument.Parse(source, options);
        return new(jsonDocument.RootElement.Clone());
    }

    /// <summary>
    /// Parses the ScriptNative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static ScriptNative ParseValue(string source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<ScriptNative>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<ScriptNative>(source.AsSpan());
#endif
    }

    /// <summary>
    /// Parses the ScriptNative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static ScriptNative ParseValue(ReadOnlySpan<char> source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<ScriptNative>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<ScriptNative>(source);
#endif
    }

    /// <summary>
    /// Parses the ScriptNative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static ScriptNative ParseValue(ReadOnlySpan<byte> source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<ScriptNative>.ParseValue(source);
#else
        return JsonValueHelpers.ParseValue<ScriptNative>(source);
#endif
    }

    /// <summary>
    /// Parses the ScriptNative.
    /// </summary>
    /// <param name="source">The source of the JSON string to parse.</param>
    public static ScriptNative ParseValue(ref Utf8JsonReader source)
    {
#if NET8_0_OR_GREATER
        return IJsonValue<ScriptNative>.ParseValue(ref source);
#else
        return JsonValueHelpers.ParseValue<ScriptNative>(ref source);
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
        return this.As<ScriptNative, TTarget>();
#endif
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return
            (obj is IJsonValue jv && this.Equals(jv.As<ScriptNative>())) ||
            (obj is null && this.IsNull());
    }

    /// <inheritdoc/>
    public bool Equals<T>(in T other)
        where T : struct, IJsonValue<T>
    {
        return this.Equals(other.As<ScriptNative>());
    }

    /// <summary>
    /// Equality comparison.
    /// </summary>
    /// <param name="other">The other item with which to compare.</param>
    /// <returns><see langword="true"/> if the values were equal.</returns>
    public bool Equals(in ScriptNative other)
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
    /// <param name="matchClauseSignature">Match a <see cref="Generated.ScriptNative.ClauseSignature"/>.</param>
    /// <param name="matchClauseAny">Match a <see cref="Generated.ScriptNative.ClauseAny"/>.</param>
    /// <param name="matchClauseAll">Match a <see cref="Generated.ScriptNative.ClauseAll"/>.</param>
    /// <param name="matchClauseSome">Match a <see cref="Generated.ScriptNative.ClauseSome"/>.</param>
    /// <param name="matchClauseBefore">Match a <see cref="Generated.ScriptNative.ClauseBefore"/>.</param>
    /// <param name="matchClauseAfter">Match a <see cref="Generated.ScriptNative.ClauseAfter"/>.</param>
    /// <param name="defaultMatch">Match any other value.</param>
    /// <returns>An instance of the value returned by the match function.</returns>
    public TOut Match<TIn, TOut>(
        in TIn context,
        Matcher<Generated.ScriptNative.ClauseSignature, TIn, TOut> matchClauseSignature,
        Matcher<Generated.ScriptNative.ClauseAny, TIn, TOut> matchClauseAny,
        Matcher<Generated.ScriptNative.ClauseAll, TIn, TOut> matchClauseAll,
        Matcher<Generated.ScriptNative.ClauseSome, TIn, TOut> matchClauseSome,
        Matcher<Generated.ScriptNative.ClauseBefore, TIn, TOut> matchClauseBefore,
        Matcher<Generated.ScriptNative.ClauseAfter, TIn, TOut> matchClauseAfter,
        Matcher<Generated.ScriptNative, TIn, TOut> defaultMatch)
    {
        Generated.ScriptNative.ClauseSignature matchClauseSignatureValue = this.As<Generated.ScriptNative.ClauseSignature>();
        if (matchClauseSignatureValue.IsValid())
        {
            return matchClauseSignature(matchClauseSignatureValue, context);
        }

        Generated.ScriptNative.ClauseAny matchClauseAnyValue = this.As<Generated.ScriptNative.ClauseAny>();
        if (matchClauseAnyValue.IsValid())
        {
            return matchClauseAny(matchClauseAnyValue, context);
        }

        Generated.ScriptNative.ClauseAll matchClauseAllValue = this.As<Generated.ScriptNative.ClauseAll>();
        if (matchClauseAllValue.IsValid())
        {
            return matchClauseAll(matchClauseAllValue, context);
        }

        Generated.ScriptNative.ClauseSome matchClauseSomeValue = this.As<Generated.ScriptNative.ClauseSome>();
        if (matchClauseSomeValue.IsValid())
        {
            return matchClauseSome(matchClauseSomeValue, context);
        }

        Generated.ScriptNative.ClauseBefore matchClauseBeforeValue = this.As<Generated.ScriptNative.ClauseBefore>();
        if (matchClauseBeforeValue.IsValid())
        {
            return matchClauseBefore(matchClauseBeforeValue, context);
        }

        Generated.ScriptNative.ClauseAfter matchClauseAfterValue = this.As<Generated.ScriptNative.ClauseAfter>();
        if (matchClauseAfterValue.IsValid())
        {
            return matchClauseAfter(matchClauseAfterValue, context);
        }

        return defaultMatch(this, context);
    }

    /// <summary>
    /// Matches the value against the composed values, and returns the result of calling the provided match function for the first match found.
    /// </summary>
    /// <typeparam name="TOut">The result of calling the match function.</typeparam>
    /// <param name="matchClauseSignature">Match a <see cref="Generated.ScriptNative.ClauseSignature"/>.</param>
    /// <param name="matchClauseAny">Match a <see cref="Generated.ScriptNative.ClauseAny"/>.</param>
    /// <param name="matchClauseAll">Match a <see cref="Generated.ScriptNative.ClauseAll"/>.</param>
    /// <param name="matchClauseSome">Match a <see cref="Generated.ScriptNative.ClauseSome"/>.</param>
    /// <param name="matchClauseBefore">Match a <see cref="Generated.ScriptNative.ClauseBefore"/>.</param>
    /// <param name="matchClauseAfter">Match a <see cref="Generated.ScriptNative.ClauseAfter"/>.</param>
    /// <param name="defaultMatch">Match any other value.</param>
    /// <returns>An instance of the value returned by the match function.</returns>
    public TOut Match<TOut>(
        Matcher<Generated.ScriptNative.ClauseSignature, TOut> matchClauseSignature,
        Matcher<Generated.ScriptNative.ClauseAny, TOut> matchClauseAny,
        Matcher<Generated.ScriptNative.ClauseAll, TOut> matchClauseAll,
        Matcher<Generated.ScriptNative.ClauseSome, TOut> matchClauseSome,
        Matcher<Generated.ScriptNative.ClauseBefore, TOut> matchClauseBefore,
        Matcher<Generated.ScriptNative.ClauseAfter, TOut> matchClauseAfter,
        Matcher<Generated.ScriptNative, TOut> defaultMatch)
    {
        Generated.ScriptNative.ClauseSignature matchClauseSignatureValue = this.As<Generated.ScriptNative.ClauseSignature>();
        if (matchClauseSignatureValue.IsValid())
        {
            return matchClauseSignature(matchClauseSignatureValue);
        }

        Generated.ScriptNative.ClauseAny matchClauseAnyValue = this.As<Generated.ScriptNative.ClauseAny>();
        if (matchClauseAnyValue.IsValid())
        {
            return matchClauseAny(matchClauseAnyValue);
        }

        Generated.ScriptNative.ClauseAll matchClauseAllValue = this.As<Generated.ScriptNative.ClauseAll>();
        if (matchClauseAllValue.IsValid())
        {
            return matchClauseAll(matchClauseAllValue);
        }

        Generated.ScriptNative.ClauseSome matchClauseSomeValue = this.As<Generated.ScriptNative.ClauseSome>();
        if (matchClauseSomeValue.IsValid())
        {
            return matchClauseSome(matchClauseSomeValue);
        }

        Generated.ScriptNative.ClauseBefore matchClauseBeforeValue = this.As<Generated.ScriptNative.ClauseBefore>();
        if (matchClauseBeforeValue.IsValid())
        {
            return matchClauseBefore(matchClauseBeforeValue);
        }

        Generated.ScriptNative.ClauseAfter matchClauseAfterValue = this.As<Generated.ScriptNative.ClauseAfter>();
        if (matchClauseAfterValue.IsValid())
        {
            return matchClauseAfter(matchClauseAfterValue);
        }

        return defaultMatch(this);
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.ScriptNative.ClauseSignature" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsClauseSignature(out Generated.ScriptNative.ClauseSignature result)
    {
        result = this.As<Generated.ScriptNative.ClauseSignature>();
        return result.IsValid();
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.ScriptNative.ClauseAny" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsClauseAny(out Generated.ScriptNative.ClauseAny result)
    {
        result = this.As<Generated.ScriptNative.ClauseAny>();
        return result.IsValid();
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.ScriptNative.ClauseAll" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsClauseAll(out Generated.ScriptNative.ClauseAll result)
    {
        result = this.As<Generated.ScriptNative.ClauseAll>();
        return result.IsValid();
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.ScriptNative.ClauseSome" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsClauseSome(out Generated.ScriptNative.ClauseSome result)
    {
        result = this.As<Generated.ScriptNative.ClauseSome>();
        return result.IsValid();
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.ScriptNative.ClauseBefore" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsClauseBefore(out Generated.ScriptNative.ClauseBefore result)
    {
        result = this.As<Generated.ScriptNative.ClauseBefore>();
        return result.IsValid();
    }

    /// <summary>
    /// Gets the value as a <see cref="Generated.ScriptNative.ClauseAfter" />.
    /// </summary>
    /// <param name="result">The result of the conversions.</param>
    /// <returns><see langword="true" /> if the conversion was valid.</returns>
    public bool TryGetAsClauseAfter(out Generated.ScriptNative.ClauseAfter result)
    {
        result = this.As<Generated.ScriptNative.ClauseAfter>();
        return result.IsValid();
    }
}
