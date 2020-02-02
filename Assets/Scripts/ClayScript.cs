using TMPro;
using UnityEngine;

public class ClayScript : MonoBehaviour
{
    public Elements Element;

    public TextMeshProUGUI textMesh;

    public GameResource resource;

    void Update()
    {
        if (resource.Type == Element)
        {
            textMesh.text = resource.Amount.ToString();
        }
    }
}
