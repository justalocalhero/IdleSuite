public class PayCost : Effect
{
    private ResourceCost resourceCost;

    protected override void OnAwake()
    {
        resourceCost = GetComponentInParent<Building>().GetComponentInChildren<ResourceCost>();
    }
    
    public override void FireEffect()
    {
        foreach(ResourceValue cost in resourceCost.GetCost())
        {
            cost.resource.Value -= cost.value;
        }
    }
}