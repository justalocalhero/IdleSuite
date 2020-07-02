using UnityEngine;

public class Production : Effect
{
    private ProductionValues productionValues;

    protected override void OnAwake()
    {
        productionValues = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<ProductionValues>();
    }

    public override void FireEffect(int fireCount)
    {
        foreach(ResourceValue resourceValue in productionValues.GetValues())
        {            
            Resource resource = resourceValue.resource;
            resource.Value += (resourceValue.value * fireCount);
        }
    }
}
