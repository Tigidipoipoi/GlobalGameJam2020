using UnityEngine;

namespace GGJ2020.Variables
{
    [CreateAssetMenu(menuName = ASSET_MENU_ROOT + "UInt")]
    public class UIntVariable : ScriptableVariable<uint>
    {
        public UIntVariable() { }

        public UIntVariable(uint aValue)
            : base(aValue) { }
    }
}
