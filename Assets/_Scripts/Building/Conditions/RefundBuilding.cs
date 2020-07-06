public class RefundBuilding : Effect
{
    private BuildingCost buildingCost;

    protected override void OnAwake()
    {
        buildingCost = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<BuildingCost>();

    }

    public override void FireEffect(int fireCount)
    {
        buildingCost.buildingCount.Count += fireCount * buildingCost.value;
    }
}