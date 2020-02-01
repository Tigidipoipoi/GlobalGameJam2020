using UnityEngine;

namespace GGJ2020.Variables
{
    [CreateAssetMenu(menuName = ASSET_MENU_ROOT + "Bool")]
    public class BoolVariable : ScriptableVariable<bool>
    {
        public BoolVariable() { }

        public BoolVariable(bool aValue)
            : base(aValue) { }
    }
}
