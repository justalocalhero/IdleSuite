using UnityEngine;

public class BuildingCondition : Condition
{
    private BuildingCost buildingCost;

    protected override void OnAwake()
    {
        buildingCost = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<BuildingCost>();
    }

    public override int CanFire(int fireCount)
    {
        return Mathf.Min(fireCount, buildingCost.buildingCount.Count / buildingCost.value);
    }
}
