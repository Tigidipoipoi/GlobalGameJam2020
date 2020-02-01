using UnityEngine;

namespace GGJ2020.Variables
{
    [CreateAssetMenu(menuName = ASSET_MENU_ROOT + "Float")]
    public class FloatVariable : ScriptableVariable<float>
    {
        public FloatVariable() { }

        public FloatVariable(float aValue)
            : base(aValue) { }
    }
}
