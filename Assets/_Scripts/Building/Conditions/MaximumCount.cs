using UnityEngine;

public class MaximumCount : Condition
{
    public int maximumCount;
    private Building building;

    protected override void OnAwake()
    {
        building = GetComponentInParent<Building>();
    }

    public override int CanFire(int fireCount)
    {
        return Mathf.Min(maximumCount - building.Count, fireCount);
    }
}
