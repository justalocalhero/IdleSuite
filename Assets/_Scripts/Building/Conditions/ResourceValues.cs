using System.Collections.Generic;
using UnityEngine;

public class ResourceValues : MonoBehaviour
{
    private IResourceValue[] resourceValues;

    void Awake()
    {
        resourceValues = GetComponentsInChildren<IResourceValue>();
    }
    
    public List<ResourceValue> GetValues()
    {
        List<ResourceValue> consolidatedCosts = new List<ResourceValue>();

        foreach(IResourceValue resourceCost in resourceValues)
        {
            List<ResourceValue> costs = resourceCost.GetValue();

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