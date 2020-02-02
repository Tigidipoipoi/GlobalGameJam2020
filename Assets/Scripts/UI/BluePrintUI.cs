using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BluePrintUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI Tooltip;

    public Image Background;

    public Image Icon;

    public DraggableBluePrintUI Draggable;

    public PotPart PotPart;

    public void Initialize(PotPart potPart)
    {
        PotPart = potPart;
        Draggable.PotPart = potPart;

        Background.sprite = PotPart.Quality.Icon;
        Draggable.Background.sprite = PotPart.Quality.Icon;

        Icon.sprite = PotPart.Icon;
        Draggable.Icon.sprite = PotPart.Icon;

        Tooltip.text = PotPart.Tooltip;

        Tooltip.transform.parent.gameObject.SetActive(false);

        gameObject.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.transform.parent.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.transform.parent.gameObject.SetActive(false);
    }
}
