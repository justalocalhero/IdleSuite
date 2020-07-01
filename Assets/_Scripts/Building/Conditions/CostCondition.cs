using System.Collections.Generic;

public class CostCondition : Condition
{
    private ResourceCost resouceCost;

    protected override void OnAwake()
    {
        resouceCost = GetComponentInParent<Building>().GetComponentInChildren<ResourceCost>();
    }

    public override bool CanFire()
    {
        List<ResourceValue> costs = resouceCost.GetCost();


        foreach(ResourceValue cost in costs)
        {
            if(cost.value > cost.resource.Value) return false;
        }

        return true;
    }
}
