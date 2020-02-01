using System;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace GGJ2020.Variables
{
    /// <summary>
    /// A class used to have base class as scriptable objects.
    /// </summary>
    /// <typeparam name="TVariableType">The base class type.</typeparam>
    public class ScriptableVariable<TVariableType> : ScriptableObject
        where TVariableType : IComparable, IConvertible
    {
        public const string ASSET_MENU_ROOT = "ScriptableVariable/";

        public TVariableType Value;

        public ScriptableVariable() { }

        public ScriptableVariable(TVariableType aValue)
        {
            Value = aValue;
        }
    }
}
