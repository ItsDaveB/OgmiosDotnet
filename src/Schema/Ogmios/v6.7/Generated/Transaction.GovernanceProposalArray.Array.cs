//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

#if NET8_0_OR_GREATER
using System.Buffers;
#endif
using System.Collections;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Internal;

namespace Generated;

/// <summary>
/// Transaction
/// </summary>
public readonly partial struct Transaction
{
    /// <summary>
    /// Generated from JSON Schema.
    /// </summary>
#if NET8_0_OR_GREATER
    [CollectionBuilder(typeof(GovernanceProposalArray), "Create")]
#endif
    public readonly partial struct GovernanceProposalArray
        : IJsonArray<Generated.Transaction.GovernanceProposalArray>,
          IReadOnlyCollection<Generated.GovernanceProposal>
    {
        /// <summary>
        /// Gets an empty array.
        /// </summary>
        public static GovernanceProposalArray EmptyArray { get; } = From(ImmutableList<JsonAny>.Empty);

        /// <summary>
        /// Gets the rank of the array.
        /// </summary>
        public static int Rank => 1;

        /// <inheritdoc/>
        Corvus.Json.JsonAny IJsonArray<GovernanceProposalArray>.this[int index]
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (index < 0)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    JsonElement.ArrayEnumerator enumerator = this.jsonElementBacking.EnumerateArray();
                    while (index >= 0)
                    {
                        index--;
                        if (!enumerator.MoveNext())
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }

                    return new(enumerator.Current);
                }

                if ((this.backing & Backing.Array) != 0)
                {
                    try
                    {
                        return this.arrayBacking[index];
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        throw new IndexOutOfRangeException(ex.Message, ex);
                    }
                }

                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets the item at the given index.
        /// </summary>
        /// <param name="index">The index at which to retrieve the item.</param>
        /// <returns>The item at the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">The index was outside the bounds of the array.</exception>
        /// <exception cref="InvalidOperationException">The value is not an array.</exception>
        public Generated.GovernanceProposal this[int index]
        {
            get
            {
                if ((this.backing & Backing.JsonElement) != 0)
                {
                    if (index < 0)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    JsonElement.ArrayEnumerator enumerator = this.jsonElementBacking.EnumerateArray();
                    while (index >= 0)
                    {
                        index--;
                        if (!enumerator.MoveNext())
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }

                    return new(enumerator.Current);
                }

                if ((this.backing & Backing.Array) != 0)
                {
                    try
                    {
                        return this.arrayBacking[index].As<Generated.GovernanceProposal>();
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        throw new IndexOutOfRangeException(ex.Message, ex);
                    }
                }

                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Conversion from <see cref="ImmutableList{JsonAny}"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator GovernanceProposalArray(ImmutableList<JsonAny> value)
        {
            return new(value);
        }

        /// <summary>
        /// Conversion to <see cref="ImmutableList{JsonAny}"/>.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator ImmutableList<JsonAny>(GovernanceProposalArray value)
        {
            return
                __CorvusArrayHelpers.GetImmutableList(value);
        }

        /// <summary>
        /// Conversion from JsonArray.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator GovernanceProposalArray(JsonArray value)
        {
            if (value.HasDotnetBacking && value.ValueKind == JsonValueKind.Array)
            {
                return new(
                    value.AsImmutableList());
            }

            return new(value.AsJsonElement);
        }

        /// <summary>
        /// Conversion to JsonArray.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonArray(GovernanceProposalArray value)
        {
            return
                value.AsArray;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <param name="items">The list of items from which to construct the array.</param>
        /// <returns>An instance of the array constructed from the list.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GovernanceProposalArray From(ImmutableList<JsonAny> items)
        {
            return new(items);
        }

        /// <summary>
        /// Create an new instance of the <see cref="GovernanceProposalArray"/>" struct from a span of items.
        /// </summary>
        /// <param name="items">The span of items from which to construct the array.</param>
        /// <returns>An instance of the array constructed from the span.</returns>
        public static GovernanceProposalArray Create(ReadOnlySpan<Generated.GovernanceProposal> items)
        {
            return new([..items]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <param name="items">The value from which to construct the instance.</param>
        /// <returns>An instance of the array constructed from the value.</returns>
        public static GovernanceProposalArray FromItems(params Generated.GovernanceProposal[] items)
        {
            return new([..items]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <param name="item1">The 1st item in the array.</param>
        /// <returns>An instance of the array constructed from the values.</returns>
        public static GovernanceProposalArray FromItems(in Generated.GovernanceProposal item1)
        {
            return new([item1.AsAny]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <param name="item1">The 1st item in the array.</param>
        /// <param name="item2">The 2nd item in the array.</param>
        /// <returns>An instance of the array constructed from the values.</returns>
        public static GovernanceProposalArray FromItems(in Generated.GovernanceProposal item1, in Generated.GovernanceProposal item2)
        {
            return new([item1.AsAny, item2.AsAny]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <param name="item1">The 1st item in the array.</param>
        /// <param name="item2">The 2nd item in the array.</param>
        /// <param name="item3">The 3rd item in the array.</param>
        /// <returns>An instance of the array constructed from the values.</returns>
        public static GovernanceProposalArray FromItems(in Generated.GovernanceProposal item1, in Generated.GovernanceProposal item2, in Generated.GovernanceProposal item3)
        {
            return new([item1.AsAny, item2.AsAny, item3.AsAny]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <param name="item1">The 1st item in the array.</param>
        /// <param name="item2">The 2nd item in the array.</param>
        /// <param name="item3">The 3rd item in the array.</param>
        /// <param name="item4">The 4th item in the array.</param>
        /// <returns>An instance of the array constructed from the values.</returns>
        public static GovernanceProposalArray FromItems(in Generated.GovernanceProposal item1, in Generated.GovernanceProposal item2, in Generated.GovernanceProposal item3, in Generated.GovernanceProposal item4)
        {
            return new([item1.AsAny, item2.AsAny, item3.AsAny, item4.AsAny]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <param name="item1">The 1st item in the array.</param>
        /// <param name="item2">The 2nd item in the array.</param>
        /// <param name="item3">The 3rd item in the array.</param>
        /// <param name="item4">The 4th item in the array.</param>
        /// <param name="item5">The 5th item in the array.</param>
        /// <returns>An instance of the array constructed from the values.</returns>
        public static GovernanceProposalArray FromItems(in Generated.GovernanceProposal item1, in Generated.GovernanceProposal item2, in Generated.GovernanceProposal item3, in Generated.GovernanceProposal item4, in Generated.GovernanceProposal item5)
        {
            return new([item1.AsAny, item2.AsAny, item3.AsAny, item4.AsAny, item5.AsAny]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <param name="item1">The 1st item in the array.</param>
        /// <param name="item2">The 2nd item in the array.</param>
        /// <param name="item3">The 3rd item in the array.</param>
        /// <param name="item4">The 4th item in the array.</param>
        /// <param name="item5">The 5th item in the array.</param>
        /// <param name="item6">The 6th item in the array.</param>
        /// <returns>An instance of the array constructed from the values.</returns>
        public static GovernanceProposalArray FromItems(in Generated.GovernanceProposal item1, in Generated.GovernanceProposal item2, in Generated.GovernanceProposal item3, in Generated.GovernanceProposal item4, in Generated.GovernanceProposal item5, in Generated.GovernanceProposal item6)
        {
            return new([item1.AsAny, item2.AsAny, item3.AsAny, item4.AsAny, item5.AsAny, item6.AsAny]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <param name="item1">The 1st item in the array.</param>
        /// <param name="item2">The 2nd item in the array.</param>
        /// <param name="item3">The 3rd item in the array.</param>
        /// <param name="item4">The 4th item in the array.</param>
        /// <param name="item5">The 5th item in the array.</param>
        /// <param name="item6">The 6th item in the array.</param>
        /// <param name="item7">The 7th item in the array.</param>
        /// <returns>An instance of the array constructed from the values.</returns>
        public static GovernanceProposalArray FromItems(in Generated.GovernanceProposal item1, in Generated.GovernanceProposal item2, in Generated.GovernanceProposal item3, in Generated.GovernanceProposal item4, in Generated.GovernanceProposal item5, in Generated.GovernanceProposal item6, in Generated.GovernanceProposal item7)
        {
            return new([item1.AsAny, item2.AsAny, item3.AsAny, item4.AsAny, item5.AsAny, item6.AsAny, item7.AsAny]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <param name="items">The items from which to construct the instance.</param>
        /// <returns>An instance of the array constructed from the items.</returns>
        public static GovernanceProposalArray FromRange(IEnumerable<Generated.GovernanceProposal> items)
        {
            return new([..items]);
        }

#if NET8_0_OR_GREATER
        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <param name="items">The items from which to construct the instance.</param>
        /// <returns>An instance of the array constructed from the items .</returns>
        static GovernanceProposalArray IJsonArray<GovernanceProposalArray>.FromRange(IEnumerable<JsonAny> items)
        {
            return new([..items]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GovernanceProposalArray"/> struct.
        /// </summary>
        /// <typeparam name="T">The type of the items to add.</typeparam>
        /// <param name="items">The items from which to construct the instance.</param>
        /// <returns>An instance of the array constructed from the items.</returns>
        static GovernanceProposalArray IJsonArray<GovernanceProposalArray>.FromRange<T>(IEnumerable<T> items)
        {
            return new([..items.Select(item => item.AsAny)]);
        }
#endif

        /// <inheritdoc/>
        IEnumerator<Generated.GovernanceProposal> IEnumerable<Generated.GovernanceProposal>.GetEnumerator() => this.EnumerateArray();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.EnumerateArray();

        /// <inheritdoc/>
        int IReadOnlyCollection<Generated.GovernanceProposal>.Count => this.GetArrayLength();

        /// <inheritdoc/>
        public ImmutableList<JsonAny> AsImmutableList()
        {
            return __CorvusArrayHelpers.GetImmutableList(this);
        }

        /// <inheritdoc/>
        public ImmutableList<JsonAny>.Builder AsImmutableListBuilder()
        {
            return __CorvusArrayHelpers.GetImmutableListBuilder(this);
        }

        /// <inheritdoc/>
        public int GetArrayLength()
        {
            if ((this.backing & Backing.JsonElement) != 0)
            {
                return this.jsonElementBacking.GetArrayLength();
            }

            if ((this.backing & Backing.Array) != 0)
            {
                return this.arrayBacking.Count;
            }

            return 0;
        }

        /// <inheritdoc/>
        public JsonArrayEnumerator<Generated.GovernanceProposal> EnumerateArray()
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

        /// <inheritdoc/>
        JsonArrayEnumerator IJsonArray<GovernanceProposalArray>.EnumerateArray()
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

        /// <inheritdoc/>
        JsonArrayEnumerator<TItem> IJsonArray<GovernanceProposalArray>.EnumerateArray<TItem>()
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

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.Add(in JsonAny item1)
        {
            ImmutableList<JsonAny>.Builder builder = __CorvusArrayHelpers.GetImmutableListBuilder(this);
            builder.Add(item1);
            return new(builder.ToImmutable());
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.Add(params JsonAny[] items)
        {
            ImmutableList<JsonAny>.Builder builder = __CorvusArrayHelpers.GetImmutableListBuilder(this);
            foreach (JsonAny item in items)
            {
                builder.Add(item.AsAny);
            }

            return new(builder.ToImmutable());
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.AddRange<TArray>(in TArray items)
        {
            ImmutableList<JsonAny>.Builder builder = __CorvusArrayHelpers.GetImmutableListBuilder(this);
            foreach (JsonAny item in items.EnumerateArray())
            {
                builder.Add(item.AsAny);
            }

            return new(builder.ToImmutable());
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.AddRange<TItem>(IEnumerable<TItem> items)
        {
            ImmutableList<JsonAny>.Builder builder = __CorvusArrayHelpers.GetImmutableListBuilder(this);
            foreach (TItem item in items)
            {
                builder.Add(item.AsAny);
            }

            return new(builder.ToImmutable());
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.AddRange(IEnumerable<JsonAny> items)
        {
            ImmutableList<JsonAny>.Builder builder = __CorvusArrayHelpers.GetImmutableListBuilder(this);
            builder.AddRange(items);
            return new(builder.ToImmutable());
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.Insert(int index, in JsonAny item1)
        {
            return new(__CorvusArrayHelpers.GetImmutableListWith(this, index, item1));
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.InsertRange<TArray>(int index, in TArray items)
        {
            return new(__CorvusArrayHelpers.GetImmutableListWith(this, index, items.EnumerateArray()));
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.InsertRange<TItem>(int index, IEnumerable<TItem> items)
        {
            return new(__CorvusArrayHelpers.GetImmutableListWith(this, index, items.Select(item => item.AsAny)));
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.InsertRange(int index, IEnumerable<JsonAny> items)
        {
            return new(__CorvusArrayHelpers.GetImmutableListWith(this, index, items));
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.Replace(in JsonAny oldValue, in JsonAny newValue)
        {
            return new(__CorvusArrayHelpers.GetImmutableListReplacing(this, oldValue, newValue));
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.SetItem(int index, in JsonAny value)
        {
            return new(__CorvusArrayHelpers.GetImmutableListSetting(this, index, value));
        }

        /// <inheritdoc/>
        public GovernanceProposalArray Add(in Generated.GovernanceProposal item1)
        {
            ImmutableList<JsonAny>.Builder builder = __CorvusArrayHelpers.GetImmutableListBuilder(this);
            builder.Add(item1.AsAny);
            return new(builder.ToImmutable());
        }

        /// <inheritdoc/>
        public GovernanceProposalArray Add(params Generated.GovernanceProposal[] items)
        {
            ImmutableList<JsonAny>.Builder builder = __CorvusArrayHelpers.GetImmutableListBuilder(this);
            foreach (Generated.GovernanceProposal item in items)
            {
                builder.Add(item.AsAny);
            }

            return new(builder.ToImmutable());
        }

        /// <inheritdoc/>
        public GovernanceProposalArray AddRange(IEnumerable<Generated.GovernanceProposal> items)
        {
            ImmutableList<JsonAny>.Builder builder = __CorvusArrayHelpers.GetImmutableListBuilder(this);
            foreach (Generated.GovernanceProposal item in items)
            {
                builder.Add(item.AsAny);
            }

            return new(builder.ToImmutable());
        }

        /// <inheritdoc/>
        public GovernanceProposalArray Insert(int index, in Generated.GovernanceProposal item1)
        {
            return new(__CorvusArrayHelpers.GetImmutableListWith(this, index, item1));
        }

        /// <inheritdoc/>
        public GovernanceProposalArray InsertRange(int index, IEnumerable<Generated.GovernanceProposal> items)
        {
            return new(__CorvusArrayHelpers.GetImmutableListWith(this, index, items.Select(item => item.AsAny)));
        }

        /// <inheritdoc/>
        public GovernanceProposalArray Replace(in Generated.GovernanceProposal oldValue, in Generated.GovernanceProposal newValue)
        {
            return new(__CorvusArrayHelpers.GetImmutableListReplacing(this, oldValue, newValue));
        }

        /// <inheritdoc/>
        public GovernanceProposalArray SetItem(int index, in Generated.GovernanceProposal value)
        {
            return new(__CorvusArrayHelpers.GetImmutableListSetting(this, index, value));
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.Remove(in JsonAny oldValue)
        {
            return new(__CorvusArrayHelpers.GetImmutableListWithout(this, oldValue));
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.RemoveAt(int index)
        {
            return new(__CorvusArrayHelpers.GetImmutableListWithoutRange(this, index, 1));
        }

        /// <inheritdoc/>
        GovernanceProposalArray IJsonArray<GovernanceProposalArray>.RemoveRange(int index, int count)
        {
            return new(__CorvusArrayHelpers.GetImmutableListWithoutRange(this, index, count));
        }

        /// <inheritdoc/>
        public GovernanceProposalArray Remove(in Generated.GovernanceProposal oldValue)
        {
            return new(__CorvusArrayHelpers.GetImmutableListWithout(this, oldValue));
        }

        private static class __CorvusArrayHelpers
        {
            /// <summary>
            /// Builds an <see cref = "ImmutableList{JsonAny}"/> from the array.
            /// </summary>
            /// <param name="arrayInstance">The array instance.</param>
            /// <returns>An immutable list of <see cref = "JsonAny"/> built from the array.</returns>
            /// <exception cref = "InvalidOperationException">The value is not an array.</exception>
            public static ImmutableList<JsonAny> GetImmutableList(in GovernanceProposalArray arrayInstance)
            {
                if ((arrayInstance.backing & Backing.Array) != 0)
                {
                    return arrayInstance.arrayBacking;
                }

                return GetImmutableListBuilder(arrayInstance).ToImmutable();
            }

            /// <summary>
            /// Builds an <see cref = "ImmutableList{JsonAny}.Builder"/> from the array.
            /// </summary>
            /// <param name="arrayInstance">The array instance.</param>
            /// <returns>An immutable list builder of <see cref = "JsonAny"/>, built from the existing array.</returns>
            /// <exception cref = "InvalidOperationException">The value is not an array.</exception>
            public static ImmutableList<JsonAny>.Builder GetImmutableListBuilder(in GovernanceProposalArray arrayInstance)
            {
                if ((arrayInstance.backing & Backing.JsonElement) != 0)
                {
                    if (arrayInstance.jsonElementBacking.ValueKind == JsonValueKind.Array)
                    {
                        ImmutableList<JsonAny>.Builder builder = ImmutableList.CreateBuilder<JsonAny>();
                        foreach (JsonElement item in arrayInstance.jsonElementBacking.EnumerateArray())
                        {
                            builder.Add(new(item));
                        }

                        return builder;
                    }
                }

                if ((arrayInstance.backing & Backing.Array) != 0)
                {
                    return arrayInstance.arrayBacking.ToBuilder();
                }

                throw new InvalidOperationException();
            }

            /// <summary>
            /// Builds an <see cref = "ImmutableList{JsonAny}"/> from the array, replacing the item at the specified index with the given item.
            /// </summary>
            /// <param name="arrayInstance">The array instance.</param>
            /// <param name="index">The index at which to add the element.</param>
            /// <param name="value">The value to add.</param>
            /// <returns>An immutable list containing the contents of the list, with the specified item at the index.</returns>
            /// <exception cref = "InvalidOperationException">The value is not an array.</exception>
            /// <exception cref = "IndexOutOfRangeException">Thrown if the range is beyond the bounds of the array.</exception>
            public static ImmutableList<JsonAny> GetImmutableListSetting(in GovernanceProposalArray arrayInstance, int index, in JsonAny value)
            {
                if ((arrayInstance.backing & Backing.JsonElement) != 0)
                {
                    if (arrayInstance.jsonElementBacking.ValueKind == JsonValueKind.Array)
                    {
                        return JsonValueHelpers.GetImmutableListFromJsonElementSetting(arrayInstance.jsonElementBacking, index, value);
                    }
                }

                if ((arrayInstance.backing & Backing.Array) != 0)
                {
                    try
                    {
                        return arrayInstance.arrayBacking.SetItem(index, value);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        throw new IndexOutOfRangeException(ex.Message, ex);
                    }
                }

                throw new InvalidOperationException();
            }

            /// <summary>
            /// Builds an <see cref = "ImmutableList{JsonAny}"/> from the array, removing the first item that equals the given value, and replacing it with the specified item.
            /// </summary>
            /// <param name="arrayInstance">The array instance.</param>
            /// <param name="oldItem">The item to remove.</param>
            /// <param name="newItem">The item to insert.</param>
            /// <returns>An immutable list containing the contents of the list, without the first instance that matches the old item, replacing it with the new item.</returns>
            /// <exception cref = "InvalidOperationException">The value is not an array.</exception>
            public static ImmutableList<JsonAny> GetImmutableListReplacing(in GovernanceProposalArray arrayInstance, in JsonAny oldItem, in JsonAny newItem)
            {
                if ((arrayInstance.backing & Backing.JsonElement) != 0)
                {
                    if (arrayInstance.jsonElementBacking.ValueKind == JsonValueKind.Array)
                    {
                        return JsonValueHelpers.GetImmutableListFromJsonElementReplacing(arrayInstance.jsonElementBacking, oldItem, newItem);
                    }
                }

                if ((arrayInstance.backing & Backing.Array) != 0)
                {
                    return  arrayInstance.arrayBacking.Replace(oldItem, newItem);
                }

                throw new InvalidOperationException();
            }

            /// <summary>
            /// Builds an <see cref = "ImmutableList{JsonAny}"/> from the array, removing the first item arrayInstance equals the given value.
            /// </summary>
            /// <param name="arrayInstance">The array instance.</param>
            /// <param name="item">The item to remove.</param>
            /// <returns>An immutable list containing the contents of the list, without the first instance arrayInstance matches the given item.</returns>
            /// <exception cref = "InvalidOperationException">The value is not an array.</exception>
            public static ImmutableList<JsonAny> GetImmutableListWithout(in GovernanceProposalArray arrayInstance, in JsonAny item)
            {
                if ((arrayInstance.backing & Backing.JsonElement) != 0)
                {
                    if (arrayInstance.jsonElementBacking.ValueKind == JsonValueKind.Array)
                    {
                        return JsonValueHelpers.GetImmutableListFromJsonElementWithout(arrayInstance.jsonElementBacking, item);
                    }
                }

                if ((arrayInstance.backing & Backing.Array) != 0)
                {
                    return  arrayInstance.arrayBacking.Remove(item);
                }

                throw new InvalidOperationException();
            }

            /// <summary>
            /// Builds an <see cref = "ImmutableList{JsonAny}"/> from the array, removing the given range.
            /// </summary>
            /// <param name="arrayInstance">The array instance.</param>
            /// <param name="index">The start index of the range to remove.</param>
            /// <param name="count">The length of the range to remove.</param>
            /// <returns>An immutable list containing the contents of the list, without the given range of items.</returns>
            /// <exception cref = "InvalidOperationException">The value is not an array.</exception>
            /// <exception cref = "IndexOutOfRangeException">Thrown if the range is beyond the bounds of the array.</exception>
            public static ImmutableList<JsonAny> GetImmutableListWithoutRange(in GovernanceProposalArray arrayInstance, int index, int count)
            {
                if ((arrayInstance.backing & Backing.JsonElement) != 0)
                {
                    if (arrayInstance.jsonElementBacking.ValueKind == JsonValueKind.Array)
                    {
                        return JsonValueHelpers.GetImmutableListFromJsonElementWithoutRange(arrayInstance.jsonElementBacking, index, count);
                    }
                }

                if ((arrayInstance.backing & Backing.Array) != 0)
                {
                    try
                    {
                        return arrayInstance.arrayBacking.RemoveRange(index, count);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        throw new IndexOutOfRangeException(ex.Message, ex);
                    }
                }

                throw new InvalidOperationException();
            }

            // <summary>
            // Builds an <see cref = "ImmutableList{JsonAny}"/> from the array, inserting the given item at the index.
            // </summary>
            // <param name="arrayInstance">The array instance.</param>
            // <param name="index">The index at which to add the element.</param>
            // <param name="value">The value to add.</param>
            // <returns>An immutable list containing the contents of the list, without the array.</returns>
            // <exception cref = "InvalidOperationException">The value is not an array.</exception>
            // <exception cref = "IndexOutOfRangeException">Thrown if the range is beyond the bounds of the array.</exception>
            public static ImmutableList<JsonAny> GetImmutableListWith(in GovernanceProposalArray arrayInstance, int index, in JsonAny value)
            {
                if ((arrayInstance.backing & Backing.JsonElement) != 0)
                {
                    if (arrayInstance.jsonElementBacking.ValueKind == JsonValueKind.Array)
                    {
                        return JsonValueHelpers.GetImmutableListFromJsonElementWith(arrayInstance.jsonElementBacking, index, value);
                    }
                }

                if ((arrayInstance.backing & Backing.Array) != 0)
                {
                    try
                    {
                        return arrayInstance.arrayBacking.Insert(index, value);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        throw new IndexOutOfRangeException(ex.Message, ex);
                    }
                }

                throw new InvalidOperationException();
            }

            /// <summary>
            /// Builds an <see cref = "ImmutableList{JsonAny}"/> from the array, inserting the items at the
            /// given index.
            /// </summary>
            /// <param name="arrayInstance">The array instance.</param>
            /// <param name="index">The index at which to add the element.</param>
            /// <param name="values">The values to add.</param>
            /// <returns>An immutable list containing the contents of the list, without the array.</returns>
            /// <exception cref = "InvalidOperationException">The value is not an array.</exception>
            /// <exception cref = "IndexOutOfRangeException">Thrown if the range is beyond the bounds of the array.</exception>
            public static ImmutableList<JsonAny> GetImmutableListWith<TEnumerable>(in GovernanceProposalArray arrayInstance, int index, TEnumerable values)
                where TEnumerable : IEnumerable<JsonAny>
            {
                if ((arrayInstance.backing & Backing.JsonElement) != 0)
                {
                    if (arrayInstance.jsonElementBacking.ValueKind == JsonValueKind.Array)
                    {
                        return JsonValueHelpers.GetImmutableListFromJsonElementWith(arrayInstance.jsonElementBacking, index, values);
                    }
                }

                if ((arrayInstance.backing & Backing.Array) != 0)
                {
                    try
                    {
                        return arrayInstance.arrayBacking.InsertRange(index, values);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        throw new IndexOutOfRangeException(ex.Message, ex);
                    }
                }

                throw new InvalidOperationException();
            }
        }
    }
}