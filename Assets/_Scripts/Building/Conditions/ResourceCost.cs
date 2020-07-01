using System.Collections.Generic;
using UnityEngine;

public class ResourceCost : MonoBehaviour
{
    private IResourceCost[] resourceCosts;

    void Awake()
    {
        resourceCosts = GetComponentInParent<Building>().GetComponentsInChildren<IResourceCost>();
    }
    
    public List<ResourceValue> GetCost()
    {
        List<ResourceValue> consolidatedCosts = new List<ResourceValue>();

        foreach(IResourceCost resourceCost in resourceCosts)
        {
            List<ResourceValue> costs = resourceCost.GetCost();

            foreach(ResourceValue cost in costs)
            {
                bool found = false;

                for(int i = 0; i < consolidatedCosts.Count; i++)
                {
                    if(consolidatedCosts[i].resource == cost.resource)
                    {
                        consolidatedCosts[i] = new ResourceValue()
                        {
                            resource = cost.resource, 
                            value = consolidatedCosts[i].value + cost.value
                        };
                        found = true;
                        continue;
                    }
                }

                if(!found)
                {
                    consolidatedCosts.Add(cost);
                }
            }
        }

        return consolidatedCosts;
    }
}