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
/// ogmios
/// </summary>
public readonly partial struct Ogmios
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Distribution of stake across registered stake pools. Each key in the map corresponds to a pool id.
    /// </para>
    /// </remarks>
    public readonly partial struct LiveStakeDistribution
    {
        /// <summary>
        /// Generated from JSON Schema.
        /// </summary>
        public readonly partial struct RequiredStakeAndVrf
            : IJsonObject<Generated.Ogmios.LiveStakeDistribution.RequiredStakeAndVrf>
        {
            /// <summary>
            /// Conversion from <see cref="ImmutableList{JsonObjectProperty}"/>.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            public static implicit operator RequiredStakeAndVrf(ImmutableList<JsonObjectProperty> value)
            {
                return new(value);
            }

            /// <summary>
            /// Conversion to <see cref="ImmutableList{JsonObjectProperty}"/>.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            public static implicit operator ImmutableList<JsonObjectProperty>(RequiredStakeAndVrf value)
            {
                return
                    __CorvusObjectHelpers.GetPropertyBacking(value);
            }

            /// <summary>
            /// Conversion from JsonObject.
            /// </summary>
            /// <param name="value">The value from which to convert.</param>
            public static implicit operator RequiredStakeAndVrf(JsonObject value)
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
            public static implicit operator JsonObject(RequiredStakeAndVrf value)
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
            /// Gets the <c>stake</c> property.
            /// </summary>
            /// <remarks>
            /// <para>
            /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
            /// </para>
            /// <para>
            /// A ratio of two integers, to express exact fractions.
            /// </para>
            /// </remarks>
            public Generated.Ratio Stake
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.StakeUtf8, out JsonElement result))
                        {
                            return new(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(JsonPropertyNames.Stake, out JsonAny result))
                        {
                            return result.As<Generated.Ratio>();
                        }
                    }

                    return default;
                }
            }

            /// <summary>
            /// Gets the <c>vrf</c> property.
            /// </summary>
            /// <remarks>
            /// <para>
            /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
            /// </para>
            /// <para>
            /// A Blake2b 32-byte hash digest, encoded in base16.
            /// </para>
            /// </remarks>
            public Generated.DigestBlake2b256 Vrf
            {
                get
                {
                    if ((this.backing & Backing.JsonElement) != 0)
                    {
                        if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                        {
                            return default;
                        }

                        if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.VrfUtf8, out JsonElement result))
                        {
                            return new(result);
                        }
                    }

                    if ((this.backing & Backing.Object) != 0)
                    {
                        if (this.objectBacking.TryGetValue(JsonPropertyNames.Vrf, out JsonAny result))
                        {
                            return result.As<Generated.DigestBlake2b256>();
                        }
                    }

                    return default;
                }
            }

            /// <inheritdoc/>
            public static RequiredStakeAndVrf FromProperties(IDictionary<JsonPropertyName, JsonAny> source)
            {
                return new(source.Select(kvp => new JsonObjectProperty(kvp.Key, kvp.Value)).ToImmutableList());
            }

            /// <inheritdoc/>
            public static RequiredStakeAndVrf FromProperties(params (JsonPropertyName Name, JsonAny Value)[] source)
            {
                return new(source.Select(s => new JsonObjectProperty(s.Name, s.Value.AsAny)).ToImmutableList());
            }

            /// <summary>
            /// Creates an instance of the type from the given immutable list of properties.
            /// </summary>
            /// <param name="source">The list of properties.</param>
            /// <returns>An instance of the type initialized from the list of properties.</returns>
            public static RequiredStakeAndVrf FromProperties(ImmutableList<JsonObjectProperty> source)
            {
                return new(source);
            }

            /// <summary>
            /// Creates an instance of a <see cref="RequiredStakeAndVrf"/>.
            /// </summary>
            public static RequiredStakeAndVrf Create(in Generated.Ratio stake, in Generated.DigestBlake2b256 vrf)
            {
                var builder = ImmutableList.CreateBuilder<JsonObjectProperty>();
                builder.Add(JsonPropertyNames.Stake, stake.AsAny);
                builder.Add(JsonPropertyNames.Vrf, vrf.AsAny);

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
            public RequiredStakeAndVrf SetProperty<TValue>(in JsonPropertyName name, TValue value)
                where TValue : struct, IJsonValue
            {
                return new(__CorvusObjectHelpers.GetPropertyBackingWith(this, name, value.AsAny));
            }

            /// <inheritdoc />
            public RequiredStakeAndVrf RemoveProperty(in JsonPropertyName name)
            {
                return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
            }

            /// <inheritdoc />
            public RequiredStakeAndVrf RemoveProperty(string name)
            {
                return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
            }

            /// <inheritdoc />
            public RequiredStakeAndVrf RemoveProperty(ReadOnlySpan<char> name)
            {
                return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
            }

            /// <inheritdoc />
            public RequiredStakeAndVrf RemoveProperty(ReadOnlySpan<byte> name)
            {
                return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
            }

            /// <summary>
            /// Provides UTF8 and string versions of the JSON property names on the object.
            /// </summary>
            public static class JsonPropertyNames
            {
                /// <summary>
                /// Gets the JSON property name for <see cref="Stake"/>.
                /// </summary>
                public const string Stake = "stake";

                /// <summary>
                /// Gets the JSON property name for <see cref="Vrf"/>.
                /// </summary>
                public const string Vrf = "vrf";

                /// <summary>
                /// Gets the JSON property name for <see cref="Stake"/>.
                /// </summary>
                public static ReadOnlySpan<byte> StakeUtf8 => "stake"u8;

                /// <summary>
                /// Gets the JSON property name for <see cref="Vrf"/>.
                /// </summary>
                public static ReadOnlySpan<byte> VrfUtf8 => "vrf"u8;
            }

            private static class __CorvusObjectHelpers
            {
                /// <summary>
                /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object.
                /// </summary>
                /// <returns>An immutable list of <see cref="JsonAny"/> built from the object.</returns>
                /// <exception cref="InvalidOperationException">The value is not an object.</exception>
                public static ImmutableList<JsonObjectProperty> GetPropertyBacking(in RequiredStakeAndVrf that)
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
                public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredStakeAndVrf that, in JsonPropertyName name)
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
                public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredStakeAndVrf that, ReadOnlySpan<char> name)
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
                public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredStakeAndVrf that, ReadOnlySpan<byte> name)
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
                public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredStakeAndVrf that, string name)
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
                public static ImmutableList<JsonObjectProperty> GetPropertyBackingWith(in RequiredStakeAndVrf that, in JsonPropertyName name, in JsonAny value)
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
    }
}
