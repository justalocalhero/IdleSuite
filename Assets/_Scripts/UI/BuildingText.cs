using UnityEngine;
using TMPro;

public class BuildingText : MonoBehaviour
{
    private BuildingCount building;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;

    private void Start() 
    {
        building = GetComponentInParent<Building>().buildingCount;

        building.onChanged += UpdateText;

        UpdateText();        
    }

    private void UpdateText()
    {
        string nameString = building.name;
        string valueString = building.Count.ToString();

        nameText.SetText(nameString);
        valueText.SetText(valueString);
    }
}
