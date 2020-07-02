public class PayCost : Effect
{
    private CostValues resourceCost;

    protected override void OnAwake()
    {
        resourceCost = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<CostValues>();
    }
    
    public override void FireEffect(int fireCount)
    {
        foreach(ResourceValue cost in resourceCost.GetValues())
        {
            cost.resource.Value -= cost.value * fireCount;
        }
    }
}
