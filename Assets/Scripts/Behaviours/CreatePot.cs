using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePot : MonoBehaviour
{
    [Header("Input data")]
    public Player Player;

    public void selectPart(PotPart part)
    {
        PotPart currentPart = whatsInThisSpot(part);
        if (!playerHaveEnoughClay(currentPart, part))
        {
            return;
        }
        if (currentPart != null)
        {
            addClay(currentPart.Element, currentPart.Value);
            unselectPart(currentPart);
        }
        Player.SelectedParts.Add(part);
        removeClay(part.Element, part.Value);
    }

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

    public bool playerHaveEnoughClay(PotPart currentPart, PotPart newPart)
    {
        int totalClay = 0;
        foreach (GameMaterial gameMaterial in Player.Resources)
        {
            if (gameMaterial.Type == newPart.Element)
            {
                totalClay += gameMaterial.Value;
            }
        }
        if (currentPart != null)
        {
            totalClay += currentPart.Value;
        }
        if (totalClay >= newPart.Value)
        {
            return true;
        }
        return false;
    }
}