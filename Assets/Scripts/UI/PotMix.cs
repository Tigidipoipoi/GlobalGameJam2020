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
    }

    void OnDisable()
    {
        PotCreationState.PartSelected -= OnPartSelected;
    }

    void OnPartSelected(PotPart selectedPart)
    {
        Redraw();
    }

    public void Redraw()
    {
        var core = Player.SelectedParts.Find(part => part != null && part.Slot == Slots.CORE);
        if (core == null)
        {
            throw new Exception("TO FIX");
        }

        Destroy(CurrentPot);

        //Model
        CurrentPot = Instantiate(core.Model, Vector3.zero, Quaternion.identity, SpawnPoint);

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
            Instantiate(part.Model, Vector3.zero, Quaternion.identity, slotAnchor);
        }
    }

    Transform GetSlotAnchor(Slots slot)
    {
        foreach (var potAnchor in PotAnchors)
        {
            if (slot == potAnchor.HandledSlot)
            {
                return potAnchor.transform;
            }
        }

        return null;
    }
}
