using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreationMenu : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        UpdateClayDisplays();
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
        foreach(PotPart part in PotCreation.Player.SelectedParts)
        {
            PotCreation.unselectPart(part);
        }
    }
}
