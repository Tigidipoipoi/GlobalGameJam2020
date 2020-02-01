using UnityEngine;

namespace GGJ2020.Variables
{
    [CreateAssetMenu(menuName = ASSET_MENU_ROOT + "Int")]
    public class IntVariable : ScriptableVariable<int>
    {
        public IntVariable() { }

        public IntVariable(int aValue)
            : base(aValue) { }
    }
}
