using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GGJ2020.Variables
{
    /// <remarks>
    /// Note that this object can't be generic for now because:
    /// - If the variable's type is an int there is a conflict in the [] operator.
    /// - "GetUniqueValue" becomes a real brain-teaser.
    /// </remarks>
    public class UIntVariableSet : ScriptableObject, IList<UIntVariable>
    {
        [SerializeField]
        List<UIntVariable> m_List = new List<UIntVariable>();

        public IEnumerable<string> Names
            => m_List.Select(item => item.name);

        public IEnumerable<uint> Values
            => m_List.Select(item => item.Value);

        public UIntVariable this[int index]
        {
            get => m_List[index];
            set => ModifyItemAt(index, value);
        }

        public UIntVariable this[uint aValue]
        {
            get { return m_List.FirstOrDefault(item => item.Value == aValue); }
            set
            {
                var indexToModify = IndexOf(aValue);

                if (indexToModify < 0)
                {
                    Debug.LogWarningFormat("{0} doesn't contain an item with the value {1}.", this, aValue);
                    return;
                }

                ModifyItemAt(indexToModify, value);
            }
        }

        public UIntVariable this[string aName]
        {
            get { return m_List.FirstOrDefault(item => item.name.ToLower() == aName.ToLower()); }
            set
            {
                var indexToModify = IndexOf(aName);

                if (indexToModify < 0)
                {
                    Debug.LogWarningFormat("{0} doesn't contain an item named {1}.", this, aName);
                    return;
                }

                ModifyItemAt(indexToModify, value);
            }
        }

        public void ModifyItemAt(int aIndex, UIntVariable aValue)
        {
            for (var i = 0; i < m_List.Count; ++i)
            {
                // The index to modify is ignored.
                if (aIndex == i)
                    continue;

                var currentItem = m_List[i];

                // Set only new items.
                if (currentItem == aValue)
                {
                    Debug.LogWarningFormat("Trying to set an already used item ({0}) in {1}", aValue, this);
                    return;
                }

                // Set only new value.
                else if (currentItem.Value == aValue.Value)
                {
                    Debug.LogWarningFormat("Trying to set an already used value ({0}) in {1}", aValue.name, this);
                    return;
                }

                // Set only new name.
                else if (currentItem.name.ToLower() == aValue.name.ToLower())
                {
                    Debug.LogWarningFormat("Trying to set an already used name ({0}) in {1}", aValue.Value, this);
                    return;
                }
            }

            m_List[aIndex] = aValue;
        }

        public int Count => m_List.Count;

        public bool IsReadOnly => ((IList<UIntVariable>)m_List).IsReadOnly;

        public virtual void Add(UIntVariable item)
        {
            // Add only new items.
            if (Contains(item))
            {
                Debug.LogWarningFormat("Trying to add an already used item ({0}) in {1}", item, this);
                return;
            }

            // Add only new value.
            if (item != null)
            {
                if (Contains(item.Value))
                {
                    Debug.LogWarningFormat("Trying to add an already used value ({0}) in {1}", item.name, this);
                    return;
                }

                // Add only new name.
                if (Contains(item.name))
                {
                    Debug.LogWarningFormat("Trying to add an already used name ({0}) in {1}", item.Value, this);
                    return;
                }
            }

            m_List.Add(item);
        }

        public void Add(uint aValue)
        {
            var newItem = CreateInstance<UIntVariable>();
            newItem.Value = aValue;

            // Assert name unicity.
            newItem.name = Names.GetUniqueName(newItem.name);

            Add(newItem);
        }

        public void Add(string aName)
        {
            var newItem = CreateInstance<UIntVariable>();
            newItem.name = aName;

            // Assert value unicity.
            newItem.Value = Values.GetUniqueValue(newItem.Value);

            Add(newItem);
        }

        public void AddRange(IEnumerable<UIntVariable> collection)
        {
            foreach (var item in collection) Add(item);
        }

        public void AddRange(IEnumerable<uint> collection)
        {
            foreach (var item in collection) Add(item);
        }

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var item in collection) Add(item);
        }

        public void Clear()
            => m_List.Clear();

        public bool Contains(UIntVariable item)
            => m_List.Contains(item);

        public bool Contains(uint aValue)
            => m_List.Any(item => item.Value == aValue);

        public bool Contains(string aName)
            => m_List.Any(item => item.name.ToLower() == aName.ToLower());

        public void CopyTo(UIntVariable[] array, int arrayIndex)
            => m_List.CopyTo(array, arrayIndex);

        public IEnumerator<UIntVariable> GetEnumerator()
            => m_List.GetEnumerator();

        public int IndexOf(UIntVariable item)
            => m_List.IndexOf(item);

        public int IndexOf(uint aValue)
        {
            var matchingItem = m_List.FirstOrDefault(item => item.Value == aValue);
            if (matchingItem == null)
                return -1;

            return m_List.IndexOf(matchingItem);
        }

        public int IndexOf(string aName)
        {
            var matchingItem = m_List.FirstOrDefault(item => item.name.ToLower() == aName.ToLower());
            if (matchingItem == null)
                return -1;

            return m_List.IndexOf(matchingItem);
        }

        public virtual void Insert(int index, UIntVariable item)
        {
            // Add only new items.
            if (m_List.Any(variable => variable == item))
            {
                Debug.LogWarningFormat("Trying to add an already used item ({0}) in {1}", item, this);
                return;
            }

            // Add only new value.
            if (m_List.Any(variable => variable.Value == item.Value))
            {
                Debug.LogWarningFormat("Trying to add an already used value ({0}) in {1}", item.name, this);
                return;
            }

            // Add only new name.
            if (m_List.Any(variable => variable.name.ToLower() == item.name.ToLower()))
            {
                Debug.LogWarningFormat("Trying to add an already used name ({0}) in {1}", item.Value, this);
                return;
            }

            m_List.Insert(index, item);
        }

        public void Insert(int index, uint aValue)
        {
            var newItem = CreateInstance<UIntVariable>();
            newItem.Value = aValue;

            // Assert name unicity.
            newItem.name = Names.GetUniqueName(newItem.name);

            m_List.Insert(index, newItem);
        }

        public void Insert(int index, string aName)
        {
            var newItem = CreateInstance<UIntVariable>();
            newItem.name = aName;

            // Assert value unicity.
            newItem.Value = Values.GetUniqueValue(newItem.Value);

            m_List.Insert(index, newItem);
        }

        public bool Remove(UIntVariable item)
            => m_List.Remove(item);

        public bool Remove(uint aValue)
            => m_List.Remove(this[aValue]);

        public bool Remove(string aName)
            => m_List.Remove(this[aName]);

        public void RemoveAt(int index)
            => m_List.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator()
            => m_List.GetEnumerator();

        /// <summary>
        /// Tries to get the value of an item with the given name.
        /// </summary>
        /// <param name="aValue">Is set to the matching value if any; otherwise is set to 0.</param>
        /// <returns>Returns true if an item with the given name is found; returns false otherwise.</returns>
        public bool TryGetValue(string aName, out uint aValue)
        {
            aValue = 0;
            var matchingItem = m_List.FirstOrDefault(item => item.name.ToLower() == aName.ToLower());
            if (matchingItem == null)
                return false;

            aValue = matchingItem.Value;

            return true;
        }

        /// <summary>
        /// Gets the name of an item with the given value.
        /// </summary>
        /// <returns>Returns null string if no match is found for the given value; otherwise return the item's name.</returns>
        /// <remarks>
        /// Not sure if this method will be used much.
        /// </remarks>
        public string GetName(uint aValue)
        {
            var matchingItem = m_List.FirstOrDefault(item => item.Value == aValue);
            if (matchingItem == null)
                return null;

            return matchingItem.name;
        }
    }
}
