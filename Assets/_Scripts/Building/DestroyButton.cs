using UnityEngine;

public class DestroyButton : MonoBehaviour
{
    private Building building;

    private void Start() 
    {
        building = GetComponentInParent<Building>();
        building.onCountChanged += (int change) => UpdateVisibility();
        UpdateVisibility();
    }

    public void UpdateVisibility()
    {
        gameObject.SetActive(building.count > 0);
    }
}
