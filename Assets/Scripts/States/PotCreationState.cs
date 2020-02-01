using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameState/PotCreation")]
public class PotCreationState : GameState
{
    /// <inheritdoc />
    public override void Apply()
    {

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
            addClay(currentPart.Element, currentPart.Value);
            unselectPart(currentPart);
        }
        Player.SelectedParts.Add(part);
        removeClay(part.Element, part.Value);
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
        foreach (GameMaterial gameMaterial in Player.Resources)
        {
            if (gameMaterial.Type == element)
            {
                gameMaterial.Value -= number;
            }
        }
    }

    /// <summary>
    /// Gives back the clay to the player
    /// </summary>
    /// <param name="element"></param>
    /// <param name="number"></param>
    public void addClay(Elements element, int number)
    {
        foreach (GameMaterial gameMaterial in Player.Resources)
        {
            if (gameMaterial.Type == element)
            {
                gameMaterial.Value += number;
            }
        }
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
            if (selectedPart.Slot == part.Slot)
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
        int totalClay = 0;
        foreach (GameMaterial gameMaterial in Player.Resources)
        {
            if (gameMaterial.Value < 0)
            {
                return false;
            }
        }
        return true;
    }
}
