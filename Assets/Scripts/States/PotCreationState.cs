﻿using System;
using UnityEngine;

[CreateAssetMenu(menuName = "GameState/PotCreation")]
public class PotCreationState : GameState
{
    public static event Action<PotPart> PartSelected;

    public static event Action PotReset;

    public static void RaisePotReset()
    {
        PotReset?.Invoke();
    }

    /// <inheritdoc />
    public override void Apply() { }

    public override void Enter()
    {
        base.Enter();
        AkSoundEngine.PostEvent("Play_Pot_Creation_Process", Flow.gameObject);
    }

    public override void Exit()
    {
        AkSoundEngine.PostEvent("Play_Pot_Creation_Finished", Flow.gameObject);
    }

    public override bool CanApply()
    {
        return playerHaveEnoughClay();
    }

    /// <summary>
    /// Add the part to the list of selected parts
    /// </summary>
    /// <param name="part"></param>
    public void selectPart(PotPart part)
    {
        PotPart currentPart = whatsInThisSpot(part);
        if (currentPart != null)
        {
            addClay(currentPart.Element, currentPart.Cost);
            unselectPart(currentPart);
        }
        else
        {
            Player.SelectedParts.Remove(null);
        }

        if (Flow.CurrentLevel < 6)
        {
            if (Player.SelectedParts.Count == Flow.CurrentLevel)
            {
                return;
            }
        }

        Player.SelectedParts.Add(part);
        removeClay(part.Element, part.Cost);

        PartSelected?.Invoke(part);
    }

    /// <summary>
    /// Remove the part from the list of selected parts
    /// </summary>
    /// <param name="part"></param>
    public void unselectPart(PotPart part)
    {
        Player.SelectedParts.Remove(part);
    }

    public void removeClay(Elements element, int number)
    {
        Player[element].Amount -= number;
    }

    /// <summary>
    /// Gives back the clay to the player
    /// </summary>
    /// <param name="element"></param>
    /// <param name="number"></param>
    public void addClay(Elements element, int number)
    {
        Player[element].Amount += number;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="part"></param>
    /// <returns>The PotPart already in the slot, null if the slot is empty</returns>
    public PotPart whatsInThisSpot(PotPart part)
    {
        foreach (PotPart selectedPart in Player.SelectedParts)
        {
            if (selectedPart != null
                && selectedPart.Slot == part.Slot)
            {
                return selectedPart;
            }
        }

        return null;
    }

    /// <summary>
    /// Check if the player still have a positive amount of clay when all parts are selected
    /// </summary>
    /// <returns></returns>
    public bool playerHaveEnoughClay()
    {
        foreach (GameResource gameMaterial in Player.Resources)
        {
            if (gameMaterial.Amount < 0)
            {
                return false;
            }
        }

        return true;
    }
    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AkSoundEngine.PostEvent("Play_click", Flow.gameObject);
        }
    }
}
