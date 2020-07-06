using UnityEngine;

public class DestroyButtonVisibility : MonoBehaviour
{
    private BuildingCount building;

    private void Start() 
    {
        building = GetComponentInParent<Building>().buildingCount;
        building.onCountChanged += (int change) => UpdateVisibility();
        UpdateVisibility();
    }

    public void UpdateVisibility()
    {
        gameObject.SetActive(building.Count > 0);
    }
}
