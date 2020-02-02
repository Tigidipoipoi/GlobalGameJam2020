using UnityEngine;
using UnityEngine.UI;

public class SelectedSlotUI : MonoBehaviour
{
    public Slots HandledSlot;

    public Image Image;

    public void Show()
    {
        var color = Image.color;
        color = new Color(color.r, color.g, color.b, 1.0f);
        Image.color = color;
    }

    public void Hide()
    {
        var color = Image.color;
        color = new Color(color.r, color.g, color.b, 0.0f);
        Image.color = color;
    }
}
