using UnityEngine;

public class MinimumCount : Condition
{
    public int minimumCount;
    private BuildingCount building;

    protected override void OnAwake()
    {
        building = GetComponentInParent<Building>().buildingCount;
    }

    public override int CanFire(int fireCount)
    {
        return Mathf.Min(fireCount, building.Count - minimumCount);
    }
}
