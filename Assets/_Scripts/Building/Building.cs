using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int spaceCost;
    public int workCost;
    public int count {get; private set;}
    public List<ResourceValue> costs;

    public delegate void OnCountChanged(int change);
    public OnCountChanged onCountChanged;


    private void Start()
    {

        foreach(ResourceValue cost in costs)
        {
            Resource resource = cost.resource;
            resource.onValueSet += ((int value) => UpdateVisibility());
        }

        UpdateVisibility();
    }
    
    public void UpdateVisibility()
    {
        foreach(ResourceValue cost in costs)
        {
            Resource resource = cost.resource;
            if(resource.lifeTimeValue * 3 < cost.value) 
            {
                gameObject.SetActive(false);
                
                return;
            }
        }

        gameObject.SetActive(true);
    }

    public void TryBuild()
    {
        if(CanBuild()) 
            Build();
    }

    private bool CanBuild()
    {
        foreach(ResourceValue cost in costs)
        {
            if(cost.resource.Value < cost.value) return false;
        }

        return true;
    }

    private void Build()
    {
        foreach(ResourceValue cost in costs)
        {
            cost.resource.Value = (cost.resource.Value - cost.value);
        }

        count++;

        if(onCountChanged != null) onCountChanged(1);
    }

    public void Destroy()
    {
        if(count > 0) count--;
        onCountChanged(-1);
    }

}
