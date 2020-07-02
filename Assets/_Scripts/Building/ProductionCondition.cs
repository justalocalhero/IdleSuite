using UnityEngine;

public class ProductionCondition : Condition
{
    private ProductionValues productionValues;

    protected override void OnAwake()
    {
        productionValues = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<ProductionValues>();
    }

    public override int CanFire(int fireCount)
    {
        int toReturn = fireCount;

        foreach(ResourceValue resourceValue in productionValues.GetValues())
        {            
            Resource resource = resourceValue.resource;
            toReturn = Mathf.Min(resourceValue.resource.Space / resourceValue.value, fireCount);
        }

        return toReturn;
    }
}