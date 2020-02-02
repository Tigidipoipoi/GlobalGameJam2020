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

    GraphicRaycaster m_Raycaster;
    EventSystem m_EventSystem;

    void Start()
    {
        m_BluePrint = GetComponentInParent<BluePrintUI>().transform;
        m_CreationMenu = GetComponentInParent<CreationMenu>().transform;

        m_Raycaster = GetComponentInParent<GraphicRaycaster>();

        m_EventSystem = EventSystem.current;
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
        //Set up the new Pointer Event
        var pointerEventData = new PointerEventData(m_EventSystem);

        //Set the Pointer Event Position to that of the mouse position
        pointerEventData.position = eventData.position;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(pointerEventData, results);

        //Check for slot position
        foreach (var result in results)
        {
            var selectedSlot = result.gameObject.GetComponent<SelectedSlotUI>();
            if (selectedSlot != null
                && PotPart.Slot.HasFlag(selectedSlot.HandledSlot))
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
