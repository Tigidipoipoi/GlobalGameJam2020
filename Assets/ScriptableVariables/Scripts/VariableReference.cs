using System;
using UnityEngine;

namespace GGJ2020.Variables
{
    /// <summary>
    /// A wrapper class that allows to use base types (int, bool, string, float ...)
    /// as constant or scriptable object.
    /// </summary>
    /// <typeparam name="TConstantType">The base type used.</typeparam>
    /// <typeparam name="TVariableType">The scriptable object type used.</typeparam>
    [Serializable]
    public class VariableReference<TConstantType, TVariableType>
        where TConstantType : IConvertible, IComparable
        where TVariableType : ScriptableVariable<TConstantType>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        public bool UseConstant = true;
        public TConstantType ConstantValue;
        public TVariableType Variable;

        public VariableReference() { }

        public VariableReference(TConstantType value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public TConstantType Value
            => UseConstant ? ConstantValue : Variable.Value;

        public static implicit operator TConstantType(VariableReference<TConstantType, TVariableType> reference)
            => reference.Value;
    }
}
