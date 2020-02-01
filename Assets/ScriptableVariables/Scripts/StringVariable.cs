using UnityEngine;

namespace GGJ2020.Variables
{
    [CreateAssetMenu(menuName = ASSET_MENU_ROOT + "String")]
    public class StringVariable : ScriptableVariable<string>
    {
        public StringVariable() { }

        public StringVariable(string aValue)
            : base(aValue) { }
    }
}
