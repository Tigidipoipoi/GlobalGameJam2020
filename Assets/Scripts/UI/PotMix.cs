using System;
using UnityEngine;

public class PotMix : MonoBehaviour
{
    public Player Player;

    public Transform SpawnPoint;

    public GameObject CurrentPot;

    public SelectedSlotUI[] PotAnchors;

    void OnEnable()
    {
        PotCreationState.PartSelected += OnPartSelected;
        PotCreationState.PotReset += Redraw;
    }

    void OnDisable()
    {
        PotCreationState.PartSelected -= OnPartSelected;
        PotCreationState.PotReset -= Redraw;
    }

    void OnPartSelected(PotPart selectedPart)
    {
        Redraw();
    }

    public void Redraw()
    {
        Destroy(CurrentPot);

        if (Player.SelectedParts.Count <= 0)
        {
            return;
        }

        var core = Player.SelectedParts.Find(part => part != null && part.Slot == Slots.CORE);
        if (core == null)
        {
            throw new Exception("TO FIX");
        }

        //Model
        CurrentPot = Instantiate(core.Model, SpawnPoint);
        CurrentPot.transform.localPosition = Vector3.zero;
        CurrentPot.transform.localRotation = Quaternion.identity;

        //Material
        var potRenderer = CurrentPot.GetComponentInChildren<MeshRenderer>();
        potRenderer.material = core.Quality.material;

        //Limbs attachment
        PotAnchors = CurrentPot.GetComponentsInChildren<SelectedSlotUI>();

        foreach (var part in Player.SelectedParts)
        {
            if (part == core
                || part == null)
            {
                continue;
            }

            var slotAnchor = GetSlotAnchor(part.Slot);
            var limb = Instantiate(part.Model, slotAnchor);
            limb.transform.localPosition = Vector3.zero;
            limb.transform.localRotation = Quaternion.identity;
        }
    }

    Transform GetSlotAnchor(Slots slot)
    {
        foreach (var potAnchor in PotAnchors)
        {
            if (slot.HasFlag(potAnchor.HandledSlot))
            {
                return potAnchor.transform;
            }
        }

        return null;
    }
}
