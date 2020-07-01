using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    private Building building;
    private IFirable firable;

    void Start()
    {
        building = GetComponentInParent<Building>();
        firable = GetComponent<IFirable>();

        firable.onFire += Build;
    }

    private void Build()
    {
        building.Count--;
    }
}