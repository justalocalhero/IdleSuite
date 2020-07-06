using UnityEngine;

public class MaximumCount : Condition
{
    public int maximumCount;
    private BuildingCount building;

    protected override void OnAwake()
    {
        building = GetComponentInParent<Building>().buildingCount;
    }

    public override int CanFire(int fireCount)
    {
        return Mathf.Min(maximumCount - building.Count, fireCount);
    }
}
