using UnityEngine;

public class Builder : MonoBehaviour
{
    private BuildingCount building;
    private IFirable firable;

    void Start()
    {
        building = GetComponentInParent<Building>().buildingCount;
        firable = GetComponent<IFirable>();

        firable.onFire += Build;
    }

    private void Build(int count)
    {
        building.Pending += count;
    }
}

public abstract class HeirarchyNode : MonoBehaviour
{

}
