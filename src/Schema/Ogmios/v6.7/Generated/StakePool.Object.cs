//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

using System.Collections.Immutable;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

namespace Generated;
/// <summary>
/// StakePool
/// </summary>
public readonly partial struct StakePool
    : IJsonObject<Generated.StakePool>
{
    /// <summary>
    /// Conversion from <see cref="ImmutableList{JsonObjectProperty}"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator StakePool(ImmutableList<JsonObjectProperty> value)
    {
        return new(value);
    }

    /// <summary>
    /// Conversion to <see cref="ImmutableList{JsonObjectProperty}"/>.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator ImmutableList<JsonObjectProperty>(StakePool value)
    {
        return
            __CorvusObjectHelpers.GetPropertyBacking(value);
    }

    /// <summary>
    /// Conversion from JsonObject.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator StakePool(JsonObject value)
    {
        if (value.HasDotnetBacking && value.ValueKind == JsonValueKind.Object)
        {
            return new(
                __CorvusObjectHelpers.GetPropertyBacking(value));
        }

        return new(value.AsJsonElement);
    }

    /// <summary>
    /// Conversion to JsonObject.
    /// </summary>
    /// <param name="value">The value from which to convert.</param>
    public static implicit operator JsonObject(StakePool value)
    {
        return
            value.AsObject;
    }

    /// <inheritdoc/>
    public Corvus.Json.JsonAny this[in JsonPropertyName name]
    {
        get
        {
            if (this.TryGetProperty(name, out Corvus.Json.JsonAny result))
            {
                return result;
            }

            throw new InvalidOperationException();
        }
    }

    /// <summary>
    /// Gets the number of properties in the object.
    /// </summary>
    public int Count
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return this.jsonElementBacking.GetPropertyCount();
            }

            if ((this.backing & Backing.Object) != 0)
            {
                return this.objectBacking.Count;
            }

            throw new InvalidOperationException();
        }
    }

    /// <summary>
    /// Gets the <c>cost</c> property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
    /// </para>
    /// </remarks>
    public Generated.ValueAdaOnly Cost
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                {
                    return default;
                }

                if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.CostUtf8, out JsonElement result))
                {
                    return new(result);
                }
            }

            if ((this.backing & Backing.Object) != 0)
            {
                if (this.objectBacking.TryGetValue(JsonPropertyNames.Cost, out JsonAny result))
                {
                    return result.As<Generated.ValueAdaOnly>();
                }
            }

            return default;
        }
    }

    /// <summary>
    /// Gets the <c>id</c> property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
    /// </para>
    /// <para>
    /// A Blake2b 32-byte hash digest of a pool's verification key.
    /// </para>
    /// </remarks>
    public Generated.StakePoolId Id
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                {
                    return default;
                }

                if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.IdUtf8, out JsonElement result))
                {
                    return new(result);
                }
            }

            if ((this.backing & Backing.Object) != 0)
            {
                if (this.objectBacking.TryGetValue(JsonPropertyNames.Id, out JsonAny result))
                {
                    return result.As<Generated.StakePoolId>();
                }
            }

            return default;
        }
    }

    /// <summary>
    /// Gets the <c>margin</c> property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
    /// </para>
    /// <para>
    /// A ratio of two integers, to express exact fractions.
    /// </para>
    /// </remarks>
    public Generated.Ratio Margin
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                {
                    return default;
                }

                if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.MarginUtf8, out JsonElement result))
                {
                    return new(result);
                }
            }

            if ((this.backing & Backing.Object) != 0)
            {
                if (this.objectBacking.TryGetValue(JsonPropertyNames.Margin, out JsonAny result))
                {
                    return result.As<Generated.Ratio>();
                }
            }

            return default;
        }
    }

    /// <summary>
    /// Gets the (optional) <c>metadata</c> property.
    /// </summary>
    public Generated.Anchor Metadata
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                {
                    return default;
                }

                if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.MetadataUtf8, out JsonElement result))
                {
                    return new(result);
                }
            }

            if ((this.backing & Backing.Object) != 0)
            {
                if (this.objectBacking.TryGetValue(JsonPropertyNames.Metadata, out JsonAny result))
                {
                    return result.As<Generated.Anchor>();
                }
            }

            return default;
        }
    }

    /// <summary>
    /// Gets the <c>owners</c> property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
    /// </para>
    /// </remarks>
    public Generated.StakePool.DigestBlake2b224Array Owners
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                {
                    return default;
                }

                if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.OwnersUtf8, out JsonElement result))
                {
                    return new(result);
                }
            }

            if ((this.backing & Backing.Object) != 0)
            {
                if (this.objectBacking.TryGetValue(JsonPropertyNames.Owners, out JsonAny result))
                {
                    return result.As<Generated.StakePool.DigestBlake2b224Array>();
                }
            }

            return default;
        }
    }

    /// <summary>
    /// Gets the <c>pledge</c> property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
    /// </para>
    /// </remarks>
    public Generated.ValueAdaOnly Pledge
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                {
                    return default;
                }

                if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.PledgeUtf8, out JsonElement result))
                {
                    return new(result);
                }
            }

            if ((this.backing & Backing.Object) != 0)
            {
                if (this.objectBacking.TryGetValue(JsonPropertyNames.Pledge, out JsonAny result))
                {
                    return result.As<Generated.ValueAdaOnly>();
                }
            }

            return default;
        }
    }

    /// <summary>
    /// Gets the <c>relays</c> property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
    /// </para>
    /// </remarks>
    public Generated.StakePool.RelayArray Relays
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                {
                    return default;
                }

                if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.RelaysUtf8, out JsonElement result))
                {
                    return new(result);
                }
            }

            if ((this.backing & Backing.Object) != 0)
            {
                if (this.objectBacking.TryGetValue(JsonPropertyNames.Relays, out JsonAny result))
                {
                    return result.As<Generated.StakePool.RelayArray>();
                }
            }

            return default;
        }
    }

    /// <summary>
    /// Gets the <c>rewardAccount</c> property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
    /// </para>
    /// <para>
    /// A reward account, also known as 'stake address'.
    /// </para>
    /// </remarks>
    public Generated.RewardAccount RewardAccount
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                {
                    return default;
                }

                if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.RewardAccountUtf8, out JsonElement result))
                {
                    return new(result);
                }
            }

            if ((this.backing & Backing.Object) != 0)
            {
                if (this.objectBacking.TryGetValue(JsonPropertyNames.RewardAccount, out JsonAny result))
                {
                    return result.As<Generated.RewardAccount>();
                }
            }

            return default;
        }
    }

    /// <summary>
    /// Gets the <c>vrfVerificationKeyHash</c> property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
    /// </para>
    /// <para>
    /// A Blake2b 32-byte hash digest, encoded in base16.
    /// </para>
    /// </remarks>
    public Generated.DigestBlake2b256 VrfVerificationKeyHash
    {
        get
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                {
                    return default;
                }

                if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.VrfVerificationKeyHashUtf8, out JsonElement result))
                {
                    return new(result);
                }
            }

            if ((this.backing & Backing.Object) != 0)
            {
                if (this.objectBacking.TryGetValue(JsonPropertyNames.VrfVerificationKeyHash, out JsonAny result))
                {
                    return result.As<Generated.DigestBlake2b256>();
                }
            }

            return default;
        }
    }

    /// <inheritdoc/>
    public static StakePool FromProperties(IDictionary<JsonPropertyName, JsonAny> source)
    {
        return new(source.Select(kvp => new JsonObjectProperty(kvp.Key, kvp.Value)).ToImmutableList());
    }

    /// <inheritdoc/>
    public static StakePool FromProperties(params (JsonPropertyName Name, JsonAny Value)[] source)
    {
        return new(source.Select(s => new JsonObjectProperty(s.Name, s.Value.AsAny)).ToImmutableList());
    }

    /// <summary>
    /// Creates an instance of the type from the given immutable list of properties.
    /// </summary>
    /// <param name="source">The list of properties.</param>
    /// <returns>An instance of the type initialized from the list of properties.</returns>
    public static StakePool FromProperties(ImmutableList<JsonObjectProperty> source)
    {
        return new(source);
    }

    /// <summary>
    /// Creates an instance of a <see cref="StakePool"/>.
    /// </summary>
    public static StakePool Create(
        in Generated.ValueAdaOnly cost,
        in Generated.StakePoolId id,
        in Generated.Ratio margin,
        in Generated.StakePool.DigestBlake2b224Array owners,
        in Generated.ValueAdaOnly pledge,
        in Generated.StakePool.RelayArray relays,
        in Generated.RewardAccount rewardAccount,
        in Generated.DigestBlake2b256 vrfVerificationKeyHash,
        in Generated.Anchor? metadata = null)
    {
        var builder = ImmutableList.CreateBuilder<JsonObjectProperty>();
        builder.Add(JsonPropertyNames.Cost, cost.AsAny);
        builder.Add(JsonPropertyNames.Id, id.AsAny);
        builder.Add(JsonPropertyNames.Margin, margin.AsAny);
        builder.Add(JsonPropertyNames.Owners, owners.AsAny);
        builder.Add(JsonPropertyNames.Pledge, pledge.AsAny);
        builder.Add(JsonPropertyNames.Relays, relays.AsAny);
        builder.Add(JsonPropertyNames.RewardAccount, rewardAccount.AsAny);
        builder.Add(JsonPropertyNames.VrfVerificationKeyHash, vrfVerificationKeyHash.AsAny);

        if (metadata is not null)
        {
            builder.Add(JsonPropertyNames.Metadata, metadata.Value.AsAny);
        }

        return new(builder.ToImmutable());
    }

    /// <inheritdoc/>
    public ImmutableList<JsonObjectProperty> AsPropertyBacking()
    {
        return __CorvusObjectHelpers.GetPropertyBacking(this);
    }
    /// <inheritdoc/>
    public ImmutableList<JsonObjectProperty>.Builder AsPropertyBackingBuilder()
    {
        return __CorvusObjectHelpers.GetPropertyBacking(this).ToBuilder();
    }

    /// <inheritdoc/>
    public JsonObjectEnumerator EnumerateObject()
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

    /// <inheritdoc/>
    public bool HasProperties()
    {
        if ((this.backing & Backing.Object) != 0)
        {
            return this.objectBacking.Count > 0;
        }

        if ((this.backing & Backing.JsonElement) != 0)
        {
            using JsonElement.ObjectEnumerator enumerator = this.jsonElementBacking.EnumerateObject();
            return enumerator.MoveNext();
        }

        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    public bool HasProperty(in JsonPropertyName name)
    {
        if ((this.backing & Backing.Object) != 0)
        {
            return this.objectBacking.ContainsKey(name);
        }

        if ((this.backing & Backing.JsonElement) != 0)
        {
            return name.TryGetProperty(this.jsonElementBacking, out JsonElement _);
        }

        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    public bool HasProperty(string name)
    {
        if ((this.backing & Backing.Object) != 0)
        {
            return this.objectBacking.ContainsKey(name);
        }

        if ((this.backing & Backing.JsonElement) != 0)
        {
            return this.jsonElementBacking.TryGetProperty(name, out _);
        }

        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    public bool HasProperty(ReadOnlySpan<char> name)
    {
        if ((this.backing & Backing.Object) != 0)
        {
            return this.objectBacking.ContainsKey(name);
        }

        if ((this.backing & Backing.JsonElement) != 0)
        {
            return this.jsonElementBacking.TryGetProperty(name, out _);
        }

        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    public bool HasProperty(ReadOnlySpan<byte> name)
    {
        if ((this.backing & Backing.Object) != 0)
        {
            return this.objectBacking.ContainsKey(name);
        }

        if ((this.backing & Backing.JsonElement) != 0)
        {
            return this.jsonElementBacking.TryGetProperty(name, out _);
        }

        throw new InvalidOperationException();
    }

    /// <summary>
    /// Get a property.
    /// </summary>
    /// <param name="name">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    /// <returns><c>True</c> if the property was present.</returns>
    /// <exception cref="InvalidOperationException">The value is not an object.</exception>
    public bool TryGetProperty(in JsonPropertyName name, out JsonAny value)
    {
        if ((this.backing & Backing.JsonElement) != 0)
        {
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
            {
                value = default;
                return false;
            }

            if (name.TryGetProperty(this.jsonElementBacking, out JsonElement element))
            {
                value = new(element);
                return true;
            }

            value = default;
            return false;
        }

        if ((this.backing & Backing.Object) != 0)
        {
            if (this.objectBacking.TryGetValue(name, out JsonAny result))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        throw new InvalidOperationException();
    }

    /// <summary>
    /// Get a property.
    /// </summary>
    /// <param name="name">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    /// <returns><c>True</c> if the property was present.</returns>
    /// <exception cref="InvalidOperationException">The value is not an object.</exception>
    public bool TryGetProperty(string name, out JsonAny value)
    {
        if ((this.backing & Backing.JsonElement) != 0)
        {
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
            {
                value = default;
                return false;
            }

            if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
            {
                value = new(element);
                return true;
            }

            value = default;
            return false;
        }

        if ((this.backing & Backing.Object) != 0)
        {
            if (this.objectBacking.TryGetValue(name, out JsonAny result))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        throw new InvalidOperationException();
    }

    /// <summary>
    /// Get a property.
    /// </summary>
    /// <param name="name">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    /// <returns><c>True</c> if the property was present.</returns>
    /// <exception cref="InvalidOperationException">The value is not an object.</exception>
    public bool TryGetProperty(ReadOnlySpan<char> name, out JsonAny value)
    {
        if ((this.backing & Backing.JsonElement) != 0)
        {
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
            {
                value = default;
                return false;
            }

            if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
            {
                value = new(element);
                return true;
            }

            value = default;
            return false;
        }

        if ((this.backing & Backing.Object) != 0)
        {
            if (this.objectBacking.TryGetValue(name, out JsonAny result))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        throw new InvalidOperationException();
    }

    /// <summary>
    /// Get a property.
    /// </summary>
    /// <param name="name">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    /// <returns><c>True</c> if the property was present.</returns>
    /// <exception cref="InvalidOperationException">The value is not an object.</exception>
    public bool TryGetProperty(ReadOnlySpan<byte> name, out JsonAny value)
    {
        if ((this.backing & Backing.JsonElement) != 0)
        {
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
            {
                value = default;
                return false;
            }

            if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
            {
                value = new(element);
                return true;
            }

            value = default;
            return false;
        }

        if ((this.backing & Backing.Object) != 0)
        {
            if (this.objectBacking.TryGetValue(name, out JsonAny result))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    public bool TryGetProperty<TValue>(in JsonPropertyName name, out TValue value)
        where TValue : struct, IJsonValue<TValue>
    {
        if ((this.backing & Backing.JsonElement) != 0)
        {
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
            {
                value = default;
                return false;
            }

            if (name.TryGetProperty(this.jsonElementBacking, out JsonElement element))
            {
#if NET8_0_OR_GREATER
                value = TValue.FromJson(element);
#else
                value = JsonValueNetStandard20Extensions.FromJsonElement<TValue>(element);
#endif

                return true;
            }

            value = default;
            return false;
        }

        if ((this.backing & Backing.Object) != 0)
        {
            if (this.objectBacking.TryGetValue(name, out JsonAny result))
            {
#if NET8_0_OR_GREATER
                value = TValue.FromAny(result);
#else
                value = result.As<TValue>();
#endif
                return true;
            }

            value = default;
            return false;
        }

        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    public bool TryGetProperty<TValue>(string name, out TValue value)
        where TValue : struct, IJsonValue<TValue>
    {
        if ((this.backing & Backing.JsonElement) != 0)
        {
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
            {
                value = default;
                return false;
            }

            if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
            {
#if NET8_0_OR_GREATER
                value = TValue.FromJson(element);
#else
                value = JsonValueNetStandard20Extensions.FromJsonElement<TValue>(element);
#endif

                return true;
            }

            value = default;
            return false;
        }

        if ((this.backing & Backing.Object) != 0)
        {
            if (this.objectBacking.TryGetValue(name, out JsonAny result))
            {
#if NET8_0_OR_GREATER
                value = TValue.FromAny(result);
#else
                value = result.As<TValue>();
#endif
                return true;
            }

            value = default;
            return false;
        }

        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    public bool TryGetProperty<TValue>(ReadOnlySpan<char> name, out TValue value)
        where TValue : struct, IJsonValue<TValue>
    {
        if ((this.backing & Backing.JsonElement) != 0)
        {
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
            {
                value = default;
                return false;
            }

            if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
            {
#if NET8_0_OR_GREATER
                value = TValue.FromJson(element);
#else
                value = JsonValueNetStandard20Extensions.FromJsonElement<TValue>(element);
#endif

                return true;
            }

            value = default;
            return false;
        }

        if ((this.backing & Backing.Object) != 0)
        {
            if (this.objectBacking.TryGetValue(name, out JsonAny result))
            {
#if NET8_0_OR_GREATER
                value = TValue.FromAny(result);
#else
                value = result.As<TValue>();
#endif
                return true;
            }

            value = default;
            return false;
        }

        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    public bool TryGetProperty<TValue>(ReadOnlySpan<byte> name, out TValue value)
        where TValue : struct, IJsonValue<TValue>
    {
        if ((this.backing & Backing.JsonElement) != 0)
        {
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
            {
                value = default;
                return false;
            }

            if (this.jsonElementBacking.TryGetProperty(name, out JsonElement element))
            {
#if NET8_0_OR_GREATER
                value = TValue.FromJson(element);
#else
                value = JsonValueNetStandard20Extensions.FromJsonElement<TValue>(element);
#endif

                return true;
            }

            value = default;
            return false;
        }

        if ((this.backing & Backing.Object) != 0)
        {
            if (this.objectBacking.TryGetValue(name, out JsonAny result))
            {
#if NET8_0_OR_GREATER
                value = TValue.FromAny(result);
#else
                value = result.As<TValue>();
#endif
                return true;
            }

            value = default;
            return false;
        }

        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    public StakePool SetProperty<TValue>(in JsonPropertyName name, TValue value)
        where TValue : struct, IJsonValue
    {
        return new(__CorvusObjectHelpers.GetPropertyBackingWith(this, name, value.AsAny));
    }

    /// <inheritdoc />
    public StakePool RemoveProperty(in JsonPropertyName name)
    {
        return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
    }

    /// <inheritdoc />
    public StakePool RemoveProperty(string name)
    {
        return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
    }

    /// <inheritdoc />
    public StakePool RemoveProperty(ReadOnlySpan<char> name)
    {
        return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
    }

    /// <inheritdoc />
    public StakePool RemoveProperty(ReadOnlySpan<byte> name)
    {
        return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
    }

    /// <summary>
    /// Provides UTF8 and string versions of the JSON property names on the object.
    /// </summary>
    public static class JsonPropertyNames
    {
        /// <summary>
        /// Gets the JSON property name for <see cref="Cost"/>.
        /// </summary>
        public const string Cost = "cost";

        /// <summary>
        /// Gets the JSON property name for <see cref="Id"/>.
        /// </summary>
        public const string Id = "id";

        /// <summary>
        /// Gets the JSON property name for <see cref="Margin"/>.
        /// </summary>
        public const string Margin = "margin";

        /// <summary>
        /// Gets the JSON property name for <see cref="Metadata"/>.
        /// </summary>
        public const string Metadata = "metadata";

        /// <summary>
        /// Gets the JSON property name for <see cref="Owners"/>.
        /// </summary>
        public const string Owners = "owners";

        /// <summary>
        /// Gets the JSON property name for <see cref="Pledge"/>.
        /// </summary>
        public const string Pledge = "pledge";

        /// <summary>
        /// Gets the JSON property name for <see cref="Relays"/>.
        /// </summary>
        public const string Relays = "relays";

        /// <summary>
        /// Gets the JSON property name for <see cref="RewardAccount"/>.
        /// </summary>
        public const string RewardAccount = "rewardAccount";

        /// <summary>
        /// Gets the JSON property name for <see cref="VrfVerificationKeyHash"/>.
        /// </summary>
        public const string VrfVerificationKeyHash = "vrfVerificationKeyHash";

        /// <summary>
        /// Gets the JSON property name for <see cref="Cost"/>.
        /// </summary>
        public static ReadOnlySpan<byte> CostUtf8 => "cost"u8;

        /// <summary>
        /// Gets the JSON property name for <see cref="Id"/>.
        /// </summary>
        public static ReadOnlySpan<byte> IdUtf8 => "id"u8;

        /// <summary>
        /// Gets the JSON property name for <see cref="Margin"/>.
        /// </summary>
        public static ReadOnlySpan<byte> MarginUtf8 => "margin"u8;

        /// <summary>
        /// Gets the JSON property name for <see cref="Metadata"/>.
        /// </summary>
        public static ReadOnlySpan<byte> MetadataUtf8 => "metadata"u8;

        /// <summary>
        /// Gets the JSON property name for <see cref="Owners"/>.
        /// </summary>
        public static ReadOnlySpan<byte> OwnersUtf8 => "owners"u8;

        /// <summary>
        /// Gets the JSON property name for <see cref="Pledge"/>.
        /// </summary>
        public static ReadOnlySpan<byte> PledgeUtf8 => "pledge"u8;

        /// <summary>
        /// Gets the JSON property name for <see cref="Relays"/>.
        /// </summary>
        public static ReadOnlySpan<byte> RelaysUtf8 => "relays"u8;

        /// <summary>
        /// Gets the JSON property name for <see cref="RewardAccount"/>.
        /// </summary>
        public static ReadOnlySpan<byte> RewardAccountUtf8 => "rewardAccount"u8;

        /// <summary>
        /// Gets the JSON property name for <see cref="VrfVerificationKeyHash"/>.
        /// </summary>
        public static ReadOnlySpan<byte> VrfVerificationKeyHashUtf8 => "vrfVerificationKeyHash"u8;
    }

    private static class __CorvusObjectHelpers
    {
        /// <summary>
        /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object.
        /// </summary>
        /// <returns>An immutable list of <see cref="JsonAny"/> built from the object.</returns>
        /// <exception cref="InvalidOperationException">The value is not an object.</exception>
        public static ImmutableList<JsonObjectProperty> GetPropertyBacking(in StakePool that)
        {
            if ((that.backing & Backing.Object) != 0)
            {
                return that.objectBacking;
            }

            if ((that.backing & Backing.JsonElement) != 0)
            {
                return PropertyBackingBuilders.GetPropertyBackingBuilder(that.jsonElementBacking).ToImmutable();
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object, without a specific property.
        /// </summary>
        /// <returns>An immutable list of <see cref="JsonObjectProperty"/>, built from the existing object, without the given property.</returns>
        /// <exception cref="InvalidOperationException">The value is not an object.</exception>
        public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in StakePool that, in JsonPropertyName name)
        {
            if ((that.backing & Backing.Object) != 0)
            {
                return that.objectBacking.Remove(name);
            }

            if ((that.backing & Backing.JsonElement) != 0)
            {
                return PropertyBackingBuilders.GetPropertyBackingBuilderWithout(that.jsonElementBacking, name).ToImmutable();
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object, without a specific property.
        /// </summary>
        /// <returns>An immutable list of <see cref="JsonObjectProperty"/>, built from the existing object, without the given property.</returns>
        /// <exception cref="InvalidOperationException">The value is not an object.</exception>
        public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in StakePool that, ReadOnlySpan<char> name)
        {
            if ((that.backing & Backing.Object) != 0)
            {
                return that.objectBacking.Remove(name);
            }

            if ((that.backing & Backing.JsonElement) != 0)
            {
                return PropertyBackingBuilders.GetPropertyBackingBuilderWithout(that.jsonElementBacking, name).ToImmutable();
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object, without a specific property.
        /// </summary>
        /// <returns>An immutable list of <see cref="JsonObjectProperty"/>, built from the existing object, without the given property.</returns>
        /// <exception cref="InvalidOperationException">The value is not an object.</exception>
        public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in StakePool that, ReadOnlySpan<byte> name)
        {
            if ((that.backing & Backing.Object) != 0)
            {
                return that.objectBacking.Remove(name);
            }

            if ((that.backing & Backing.JsonElement) != 0)
            {
                return PropertyBackingBuilders.GetPropertyBackingBuilderWithout(that.jsonElementBacking, name).ToImmutable();
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object, without a specific property.
        /// </summary>
        /// <returns>An immutable list of <see cref="JsonObjectProperty"/>, built from the existing object, without the given property.</returns>
        /// <exception cref="InvalidOperationException">The value is not an object.</exception>
        public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in StakePool that, string name)
        {
            if ((that.backing & Backing.Object) != 0)
            {
                return that.objectBacking.Remove(name);
            }

            if ((that.backing & Backing.JsonElement) != 0)
            {
                return PropertyBackingBuilders.GetPropertyBackingBuilderWithout(that.jsonElementBacking, name).ToImmutable();
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object, without a specific property.
        /// </summary>
        /// <returns>An immutable list of <see cref="JsonObjectProperty"/>, built from the existing object, with the given property.</returns>
        /// <exception cref="InvalidOperationException">The value is not an object.</exception>
        public static ImmutableList<JsonObjectProperty> GetPropertyBackingWith(in StakePool that, in JsonPropertyName name, in JsonAny value)
        {
            if ((that.backing & Backing.Object) != 0)
            {
                return that.objectBacking.SetItem(name, value);
            }

            if ((that.backing & Backing.JsonElement) != 0)
            {
                return PropertyBackingBuilders.GetPropertyBackingBuilderReplacing(that.jsonElementBacking, name, value).ToImmutable();
            }

            throw new InvalidOperationException();
        }
    }
}
