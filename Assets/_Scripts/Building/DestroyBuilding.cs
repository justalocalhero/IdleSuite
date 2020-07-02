using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    private Building building;
    private IFirable firable;

    void Start()
    {
        building = GetComponentInParent<Building>();
        firable = GetComponent<IFirable>();

        firable.onFire += Destroy;
    }

    private void Destroy(int destroyCount)
    {
        building.Count -= destroyCount;
    }
}