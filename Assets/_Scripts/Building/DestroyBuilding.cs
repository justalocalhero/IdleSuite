using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    private BuildingCount building;
    private IFirable firable;

    void Start()
    {
        building = GetComponentInParent<Building>().buildingCount;
        firable = GetComponent<IFirable>();

        firable.onFire += Destroy;
    }

    private void Destroy(int destroyCount)
    {
        building.Pending -= destroyCount;
    }
}