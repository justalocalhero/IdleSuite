using UnityEngine;

public class MinimumCount : Condition
{
    public int minimumCount;
    private Building building;

    protected override void OnAwake()
    {
        building = GetComponentInParent<Building>();
    }

    public override int CanFire(int fireCount)
    {
        return Mathf.Min(fireCount, building.Count - minimumCount);
    }
}