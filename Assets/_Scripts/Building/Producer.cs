using UnityEngine;

public class Producer : MonoBehaviour
{
    public ResourceValue[] resourceValues;
    private IFirable firable;
    private Building building;
    
    private void Start() 
    {
        firable = GetComponentInParent<IFirable>();
        building = GetComponentInParent<Building>();
        firable.onFire += HandleFire;
    }

    private void HandleFire()
    {
        foreach(ResourceValue resourceValue in resourceValues)
        {            
            Resource resource = resourceValue.resource;
            resource.Value += (resourceValue.value * building.Count);
        }
    }
}
