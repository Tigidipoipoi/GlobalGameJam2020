﻿using System;
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

            RePopulateGrid(gameFlow.currentInventory.OwnedParts);
        }
    }

    void RePopulateGrid(List<PotPart> parts)
    {
        //Clear grid
        for (var i = RecipeGrid.childCount - 1 ; i >= 0; i--)
        {
            Destroy(RecipeGrid.GetChild(i).gameObject);
        }

        //Fill grid
        foreach (var ownedPart in parts)
        {
            var bluePrint = Instantiate(BluePrintPrefab, RecipeGrid.transform);
            bluePrint.Initialize(ownedPart);
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
        for (var i = 0; i < PotCreation.Player.SelectedParts.Count; i++)
        {
            PotPart part = PotCreation.Player.SelectedParts[i];
            PotCreation.unselectPart(part);
            break;
        }

        OnPartSelected(null);
    }

    public void UpdateRecipeList()
    {
        List<PotPart> filteredQualityParts = new List<PotPart>();
        switch (QualityDD.value)
        {
            case (int)Qualities.PORCELAIN + 1:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    if (part.Quality.quality == Qualities.PORCELAIN)
                    {
                        filteredQualityParts.Add(part);
                        Debug.Log("filter quality add " + part);

                    }
                }
                break;
            case (int)Qualities.TERRACOTTA + 1:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    if (part.Quality.quality == Qualities.TERRACOTTA)
                    {
                        filteredQualityParts.Add(part);
                        Debug.Log("filter quality add " + part);

                    }
                }
                break;
            case (int)Qualities.IRON + 1:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    if (part.Quality.quality == Qualities.IRON)
                    {
                        filteredQualityParts.Add(part);
                        Debug.Log("filter quality add " + part);

                    }
                }

                break;
            case (int)Qualities.GOLD + 1:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    if (part.Quality.quality == Qualities.GOLD)
                    {
                        filteredQualityParts.Add(part);
                        Debug.Log("filter quality add " + part);

                    }
                }
                break;
            default:
                foreach (PotPart part in gameFlow.currentInventory.OwnedParts)
                {
                    filteredQualityParts.Add(part);
                    Debug.Log("filter quality add " + part);

                }

                break;
        }

        List<PotPart> filteredElementParts = new List<PotPart>();

        switch (ElementDD.value)
        {
            case (int)Elements.FIRE + 1:
                foreach (PotPart part in filteredQualityParts)
                {
                    if (part.Element == Elements.FIRE)
                    {
                        filteredElementParts.Add(part);
                        Debug.Log("filter element add " + part);

                    }
                }

                break;
            case (int)Elements.PLANT + 1:
                foreach (PotPart part in filteredQualityParts)
                {
                    if (part.Element == Elements.PLANT)
                    {
                        filteredElementParts.Add(part);
                        Debug.Log("filter element add " + part);

                    }
                }

                break;
            case (int)Elements.AIR + 1:
                foreach (PotPart part in filteredQualityParts)
                {
                    if (part.Element == Elements.AIR)
                    {
                        filteredElementParts.Add(part);
                        Debug.Log("filter element add " + part);

                    }
                }

                break;
            case (int)Elements.THUNDER + 1:
                foreach (PotPart part in filteredQualityParts)
                {
                    if (part.Element == Elements.THUNDER)
                    {
                        filteredElementParts.Add(part);
                        Debug.Log("filter element add " + part);

                    }
                }

                break;
            case (int)Elements.WATER + 1:
                foreach (PotPart part in filteredQualityParts)
                {
                    if (part.Element == Elements.WATER)
                    {
                        filteredElementParts.Add(part);
                        Debug.Log("filter element add " + part);

                    }
                }

                break;
            default:
                foreach (PotPart part in filteredQualityParts)
                {
                    filteredElementParts.Add(part);
                    Debug.Log("filter element add " + part);

                }
                break;
        }

        List<PotPart> filteredParts = new List<PotPart>();

        if (SlotDD.value == 0)
        {
            RePopulateGrid(filteredElementParts);
        }
        else
        {
            foreach (PotPart part in filteredElementParts)
            {

                if (part.Slot.HasFlag(ConvertSlot(SlotDD.value)))
                {
                    filteredParts.Add(part);
                    Debug.Log("filter flag add " + part);

                }
            }
            RePopulateGrid(filteredParts);
        }
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
                slotUi.gameObject.SetActive(slotUi.HandledSlot == Slots.CORE);

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
