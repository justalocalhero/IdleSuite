using UnityEngine;

public class Producer : MonoBehaviour
{
    public ResourceValue resourceValue;
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
        Resource resource = resourceValue.resource;
        resource.Value += (resourceValue.value * building.count);
    }
}
