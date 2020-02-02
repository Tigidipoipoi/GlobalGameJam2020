using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BluePrintUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI Tooltip;

    public Image Background;

    public Image Icon;

    PotPart m_PotPart;

    public void Initialize(PotPart potPart)
    {
        m_PotPart = potPart;

        Background.sprite = m_PotPart.Quality.Icon;

        Icon.sprite = m_PotPart.Icon;

        Tooltip.text = m_PotPart.Tooltip;

        Tooltip.gameObject.SetActive(false);

        gameObject.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.gameObject.SetActive(false);
    }
}
