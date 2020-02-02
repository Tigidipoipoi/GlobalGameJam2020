using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableBluePrintUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image Background;

    public Image Icon;

    public PotPart PotPart;

    public PotCreationState State;

    Transform m_CreationMenu;

    Transform m_BluePrint;

    List<SelectedSlotUI> SelectableSlots;

    void Start()
    {
        m_BluePrint = GetComponentInParent<BluePrintUI>().transform;
        m_CreationMenu = GetComponentInParent<CreationMenu>().transform;

        SelectableSlots.AddRange(FindObjectsOfType<SelectedSlotUI>());
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(m_CreationMenu, true);

        var color = Background.color;
        color = new Color(color.r, color.g, color.b, 0.5f);
        Background.color = color;

        color = Icon.color;
        color = new Color(color.r, color.g, color.b, 0.5f);
        Icon.color = color;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Check for slot position
        foreach (var slot in SelectableSlots)
        {
            if (PotPart.Slot.HasFlag(slot.HandledSlot))
            {
                State.selectPart(PotPart);

                break;
            }
        }

        var color = Background.color;
        color = new Color(color.r, color.g, color.b, 1.0f);
        Background.color = color;

        color = Icon.color;
        color = new Color(color.r, color.g, color.b, 1.0f);
        Icon.color = color;

        transform.SetParent(m_BluePrint, true);
        transform.localPosition = Vector3.zero;
    }
}
