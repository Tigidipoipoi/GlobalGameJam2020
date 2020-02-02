using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreationMenu : MonoBehaviour
{
    public GameFlow gameFlow;

    public PotCreationState PotCreation;

    public TextMeshProUGUI FireAmount;
    public TextMeshProUGUI PlantAmount;
    public TextMeshProUGUI AirAmount;
    public TextMeshProUGUI ThunderAmount;
    public TextMeshProUGUI WaterAmount;

    public GameResource Fire;
    public GameResource Plant;
    public GameResource Air;
    public GameResource Thunder;
    public GameResource Water;

    public TMP_Dropdown QualityDD;
    public TMP_Dropdown ElementDD;
    public TMP_Dropdown SlotDD;

    public Transform RecipeGrid;

    public BluePrintUI BluePrintPrefab;

    SelectedSlotUI[] m_SlotUis;

    void Start()
    {
        GameFlow.StateStarted += OnStateStarted;
        GameFlow.StateEnded += OnStateEnded;

        if (gameFlow.CurrentState != PotCreation)
        {
            gameObject.SetActive(false);
        }

        m_SlotUis = GetComponentsInChildren<SelectedSlotUI>();

        UpdateClayDisplays();
    }

    void OnDestroy()
    {
        GameFlow.StateEnded -= OnStateEnded;
        GameFlow.StateStarted -= OnStateStarted;
    }

    void OnEnable()
    {
        PotCreationState.PartSelected += OnPartSelected;

        OnPartSelected(null);
    }

    void OnDisable()
    {
        PotCreationState.PartSelected -= OnPartSelected;
    }

    void OnStateStarted(GameState state)
    {
        if (state == PotCreation)
        {
            gameObject.SetActive(true);

            //Clear grid
            for (var i = RecipeGrid.childCount; i > 0; i--)
            {
                Destroy(RecipeGrid.GetChild(0).gameObject);
            }

            //Fill grid
            foreach (var ownedPart in gameFlow.currentInventory.OwnedParts)
            {
                var bluePrint = Instantiate(BluePrintPrefab, RecipeGrid.transform);
                bluePrint.Initialize(ownedPart);
            }
        }
    }

    void OnStateEnded(GameState state)
    {
        if (state == PotCreation)
        {
            gameObject.SetActive(false);
        }
    }

    private void UpdateClayDisplays()
    {
        FireAmount.text = Fire.Amount.ToString();
        PlantAmount.text = Plant.Amount.ToString();
        AirAmount.text = Air.Amount.ToString();
        ThunderAmount.text = Thunder.Amount.ToString();
        WaterAmount.text = Water.Amount.ToString();
    }

    public void ResetPot()
    {
        for (var i = PotCreation.Player.SelectedParts.Count - 1; i >= 0; i--)
        {
            PotPart part = PotCreation.Player.SelectedParts[i];
            PotCreation.unselectPart(part);
        }

        OnPartSelected(null);

        PotCreationState.RaisePotReset();
    }

    public void UpdateRecipeList()
    {
        List<PotPart> filteredParts = new List<PotPart>();
        switch (QualityDD.value)
        {
            case (int)Qualities.EARTHENWARE + 1:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    if (part.Quality.quality == Qualities.EARTHENWARE)
                    {
                        filteredParts.Add(part);
                    }
                }

                break;
            case (int)Qualities.PORCELAIN + 1:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    if (part.Quality.quality == Qualities.PORCELAIN)
                    {
                        filteredParts.Add(part);
                    }
                }

                break;
            case (int)Qualities.TERRACOTTA + 1:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    if (part.Quality.quality == Qualities.TERRACOTTA)
                    {
                        filteredParts.Add(part);
                    }
                }

                break;
            case (int)Qualities.SANDSTONE + 1:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    if (part.Quality.quality == Qualities.SANDSTONE)
                    {
                        filteredParts.Add(part);
                    }
                }

                break;
            case (int)Qualities.IRON + 1:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    if (part.Quality.quality == Qualities.IRON)
                    {
                        filteredParts.Add(part);
                    }
                }

                break;
            case (int)Qualities.DIAMOND + 1:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    if (part.Quality.quality == Qualities.DIAMOND)
                    {
                        filteredParts.Add(part);
                    }
                }

                break;
            default:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    filteredParts.Add(part);
                }

                break;
        }

        switch (ElementDD.value)
        {
            case (int)Elements.FIRE + 1:
                foreach (PotPart part in filteredParts)
                {
                    if (part.Element != Elements.FIRE)
                    {
                        filteredParts.Remove(part);
                    }
                }

                break;
            case (int)Elements.PLANT + 1:
                foreach (PotPart part in filteredParts)
                {
                    if (part.Element != Elements.PLANT)
                    {
                        filteredParts.Remove(part);
                    }
                }

                break;
            case (int)Elements.AIR + 1:
                foreach (PotPart part in filteredParts)
                {
                    if (part.Element != Elements.AIR)
                    {
                        filteredParts.Remove(part);
                    }
                }

                break;
            case (int)Elements.THUNDER + 1:
                foreach (PotPart part in filteredParts)
                {
                    if (part.Element != Elements.THUNDER)
                    {
                        filteredParts.Remove(part);
                    }
                }

                break;
            case (int)Elements.WATER + 1:
                foreach (PotPart part in filteredParts)
                {
                    if (part.Element != Elements.WATER)
                    {
                        filteredParts.Remove(part);
                    }
                }

                break;
            default:
                break;
        }

        foreach (PotPart part in filteredParts)
        {
            if (SlotDD.value == 0)
            {
                break;
            }

            if (!part.Slot.HasFlag(ConvertSlot(SlotDD.value)))
            {
                filteredParts.Remove(part);
            }
        }

        //TODO generate content from that list
    }

    private Slots ConvertSlot(int slotIndex)
    {
        Slots slot = Slots.CORE;
        switch (slotIndex)
        {
            case 2:
                slot = Slots.ARM_L;
                break;
            case 3:
                slot = Slots.LEG_L;
                break;
            case 4:
                slot = Slots.EYE;
                break;
        }

        return slot;
    }

    void OnPartSelected(PotPart _)
    {
        if (m_SlotUis == null)
        {
            return;
        }

        Slots occupiedMask = 0;
        bool areAllSelected = true;
        foreach (var part in PotCreation.Player.SelectedParts)
        {
            if (part == null)
            {
                areAllSelected = false;

                continue;
            }

            occupiedMask |= part.Slot;
        }

        foreach (var slotUi in m_SlotUis)
        {
            if (occupiedMask == 0)
            {
                var doShow = slotUi.HandledSlot == Slots.CORE;
                slotUi.gameObject.SetActive(doShow);

                if (doShow)
                {
                    slotUi.Show();
                }
                else
                {
                    slotUi.Hide();
                }

                continue;
            }

            slotUi.gameObject.SetActive(true);

            if (areAllSelected
                || occupiedMask.HasFlag(slotUi.HandledSlot))
            {
                slotUi.Hide();
            }
            else
            {
                slotUi.Show();
            }
        }
    }
}
