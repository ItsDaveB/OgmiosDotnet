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
/// Utxo
/// </summary>
public readonly partial struct Utxo
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
    public readonly partial struct RequiredAddressAndIndexAndTransactionAndValue
        : IJsonObject<Generated.Utxo.RequiredAddressAndIndexAndTransactionAndValue>
    {
        /// <summary>
        /// Conversion from <see cref="ImmutableList{JsonObjectProperty}"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator RequiredAddressAndIndexAndTransactionAndValue(ImmutableList<JsonObjectProperty> value)
        {
            return new(value);
        }

        /// <summary>
        /// Conversion to <see cref="ImmutableList{JsonObjectProperty}"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator ImmutableList<JsonObjectProperty>(RequiredAddressAndIndexAndTransactionAndValue value)
        {
            return
                __CorvusObjectHelpers.GetPropertyBacking(value);
        }

        /// <summary>
        /// Conversion from JsonObject.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator RequiredAddressAndIndexAndTransactionAndValue(JsonObject value)
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
        public static implicit operator JsonObject(RequiredAddressAndIndexAndTransactionAndValue value)
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
        /// Gets the <c>address</c> property.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
        /// </para>
        /// <para>
        /// A Cardano address (either legacy format or new format).
        /// </para>
        /// </remarks>
        public Generated.Address Address
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        return default;
                    }

                    if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.AddressUtf8, out JsonElement result))
                    {
                        return new(result);
                    }
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(JsonPropertyNames.Address, out JsonAny result))
                    {
                        return result.As<Generated.Address>();
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets the (optional) <c>datum</c> property.
        /// </summary>
        public Corvus.Json.JsonString Datum
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        return default;
                    }

                    if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.DatumUtf8, out JsonElement result))
                    {
                        return new(result);
                    }
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(JsonPropertyNames.Datum, out JsonAny result))
                    {
                        return result.As<Corvus.Json.JsonString>();
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets the (optional) <c>datumHash</c> property.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A Blake2b 32-byte hash digest, encoded in base16.
        /// </para>
        /// </remarks>
        public Generated.DigestBlake2b256 DatumHash
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        return default;
                    }

                    if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.DatumHashUtf8, out JsonElement result))
                    {
                        return new(result);
                    }
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(JsonPropertyNames.DatumHash, out JsonAny result))
                    {
                        return result.As<Generated.DigestBlake2b256>();
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets the <c>index</c> property.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
        /// </para>
        /// </remarks>
        public Generated.UInt32 Index
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        return default;
                    }

                    if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.IndexUtf8, out JsonElement result))
                    {
                        return new(result);
                    }
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(JsonPropertyNames.Index, out JsonAny result))
                    {
                        return result.As<Generated.UInt32>();
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets the (optional) <c>script</c> property.
        /// </summary>
        public Generated.Script Script
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        return default;
                    }

                    if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.ScriptUtf8, out JsonElement result))
                    {
                        return new(result);
                    }
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(JsonPropertyNames.Script, out JsonAny result))
                    {
                        return result.As<Generated.Script>();
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets the <c>transaction</c> property.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
        /// </para>
        /// </remarks>
        public Generated.Utxo.RequiredAddressAndIndexAndTransactionAndValue.RequiredId Transaction
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        return default;
                    }

                    if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.TransactionUtf8, out JsonElement result))
                    {
                        return new(result);
                    }
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(JsonPropertyNames.Transaction, out JsonAny result))
                    {
                        return result.As<Generated.Utxo.RequiredAddressAndIndexAndTransactionAndValue.RequiredId>();
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets the <c>value</c> property.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the instance is valid, this property will not be <see cref="JsonValueKind.Undefined"/>.
        /// </para>
        /// </remarks>
        public Generated.Value Value
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (this.jsonElementBacking.ValueKind != JsonValueKind.Object)
                    {
                        return default;
                    }

                    if (this.jsonElementBacking.TryGetProperty(JsonPropertyNames.ValueUtf8, out JsonElement result))
                    {
                        return new(result);
                    }
                }

                if ((this.backing & Backing.Object) != 0)
                {
                    if (this.objectBacking.TryGetValue(JsonPropertyNames.Value, out JsonAny result))
                    {
                        return result.As<Generated.Value>();
                    }
                }

                return default;
            }
        }

        /// <inheritdoc/>
        public static RequiredAddressAndIndexAndTransactionAndValue FromProperties(IDictionary<JsonPropertyName, JsonAny> source)
        {
            return new(source.Select(kvp => new JsonObjectProperty(kvp.Key, kvp.Value)).ToImmutableList());
        }

        /// <inheritdoc/>
        public static RequiredAddressAndIndexAndTransactionAndValue FromProperties(params (JsonPropertyName Name, JsonAny Value)[] source)
        {
            return new(source.Select(s => new JsonObjectProperty(s.Name, s.Value.AsAny)).ToImmutableList());
        }

        /// <summary>
        /// Creates an instance of the type from the given immutable list of properties.
        /// </summary>
        /// <param name="source">The list of properties.</param>
        /// <returns>An instance of the type initialized from the list of properties.</returns>
        public static RequiredAddressAndIndexAndTransactionAndValue FromProperties(ImmutableList<JsonObjectProperty> source)
        {
            return new(source);
        }

        /// <summary>
        /// Creates an instance of a <see cref="RequiredAddressAndIndexAndTransactionAndValue"/>.
        /// </summary>
        public static RequiredAddressAndIndexAndTransactionAndValue Create(
            in Generated.Address address,
            in Generated.UInt32 index,
            in Generated.Utxo.RequiredAddressAndIndexAndTransactionAndValue.RequiredId transaction,
            in Generated.Value value,
            in Corvus.Json.JsonString? datum = null,
            in Generated.DigestBlake2b256? datumHash = null,
            in Generated.Script? script = null)
        {
            var builder = ImmutableList.CreateBuilder<JsonObjectProperty>();
            builder.Add(JsonPropertyNames.Address, address.AsAny);
            builder.Add(JsonPropertyNames.Index, index.AsAny);
            builder.Add(JsonPropertyNames.Transaction, transaction.AsAny);
            builder.Add(JsonPropertyNames.Value, value.AsAny);

            if (datum is not null)
            {
                builder.Add(JsonPropertyNames.Datum, datum.Value.AsAny);
            }

            if (datumHash is not null)
            {
                builder.Add(JsonPropertyNames.DatumHash, datumHash.Value.AsAny);
            }

            if (script is not null)
            {
                builder.Add(JsonPropertyNames.Script, script.Value.AsAny);
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
        public RequiredAddressAndIndexAndTransactionAndValue SetProperty<TValue>(in JsonPropertyName name, TValue value)
            where TValue : struct, IJsonValue
        {
            return new(__CorvusObjectHelpers.GetPropertyBackingWith(this, name, value.AsAny));
        }

        /// <inheritdoc />
        public RequiredAddressAndIndexAndTransactionAndValue RemoveProperty(in JsonPropertyName name)
        {
            return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
        }

        /// <inheritdoc />
        public RequiredAddressAndIndexAndTransactionAndValue RemoveProperty(string name)
        {
            return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
        }

        /// <inheritdoc />
        public RequiredAddressAndIndexAndTransactionAndValue RemoveProperty(ReadOnlySpan<char> name)
        {
            return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
        }

        /// <inheritdoc />
        public RequiredAddressAndIndexAndTransactionAndValue RemoveProperty(ReadOnlySpan<byte> name)
        {
            return new(__CorvusObjectHelpers.GetPropertyBackingWithout(this, name));
        }

        /// <summary>
        /// Provides UTF8 and string versions of the JSON property names on the object.
        /// </summary>
        public static class JsonPropertyNames
        {
            /// <summary>
            /// Gets the JSON property name for <see cref="Address"/>.
            /// </summary>
            public const string Address = "address";

            /// <summary>
            /// Gets the JSON property name for <see cref="Datum"/>.
            /// </summary>
            public const string Datum = "datum";

            /// <summary>
            /// Gets the JSON property name for <see cref="DatumHash"/>.
            /// </summary>
            public const string DatumHash = "datumHash";

            /// <summary>
            /// Gets the JSON property name for <see cref="Index"/>.
            /// </summary>
            public const string Index = "index";

            /// <summary>
            /// Gets the JSON property name for <see cref="Script"/>.
            /// </summary>
            public const string Script = "script";

            /// <summary>
            /// Gets the JSON property name for <see cref="Transaction"/>.
            /// </summary>
            public const string Transaction = "transaction";

            /// <summary>
            /// Gets the JSON property name for <see cref="Value"/>.
            /// </summary>
            public const string Value = "value";

            /// <summary>
            /// Gets the JSON property name for <see cref="Address"/>.
            /// </summary>
            public static ReadOnlySpan<byte> AddressUtf8 => "address"u8;

            /// <summary>
            /// Gets the JSON property name for <see cref="Datum"/>.
            /// </summary>
            public static ReadOnlySpan<byte> DatumUtf8 => "datum"u8;

            /// <summary>
            /// Gets the JSON property name for <see cref="DatumHash"/>.
            /// </summary>
            public static ReadOnlySpan<byte> DatumHashUtf8 => "datumHash"u8;

            /// <summary>
            /// Gets the JSON property name for <see cref="Index"/>.
            /// </summary>
            public static ReadOnlySpan<byte> IndexUtf8 => "index"u8;

            /// <summary>
            /// Gets the JSON property name for <see cref="Script"/>.
            /// </summary>
            public static ReadOnlySpan<byte> ScriptUtf8 => "script"u8;

            /// <summary>
            /// Gets the JSON property name for <see cref="Transaction"/>.
            /// </summary>
            public static ReadOnlySpan<byte> TransactionUtf8 => "transaction"u8;

            /// <summary>
            /// Gets the JSON property name for <see cref="Value"/>.
            /// </summary>
            public static ReadOnlySpan<byte> ValueUtf8 => "value"u8;
        }

        private static class __CorvusObjectHelpers
        {
            /// <summary>
            /// Builds an <see cref="ImmutableList{JsonObjectProperty}"/> from the object.
            /// </summary>
            /// <returns>An immutable list of <see cref="JsonAny"/> built from the object.</returns>
            /// <exception cref="InvalidOperationException">The value is not an object.</exception>
            public static ImmutableList<JsonObjectProperty> GetPropertyBacking(in RequiredAddressAndIndexAndTransactionAndValue that)
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
            public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredAddressAndIndexAndTransactionAndValue that, in JsonPropertyName name)
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
            public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredAddressAndIndexAndTransactionAndValue that, ReadOnlySpan<char> name)
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
            public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredAddressAndIndexAndTransactionAndValue that, ReadOnlySpan<byte> name)
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
            public static ImmutableList<JsonObjectProperty> GetPropertyBackingWithout(in RequiredAddressAndIndexAndTransactionAndValue that, string name)
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
            public static ImmutableList<JsonObjectProperty> GetPropertyBackingWith(in RequiredAddressAndIndexAndTransactionAndValue that, in JsonPropertyName name, in JsonAny value)
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