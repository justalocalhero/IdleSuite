using UnityEngine;

public class InverseSquareProgress : MonoBehaviour
{
    public Resource resource;
    private IFirable firable;
    private Building building;
    public float progressPerCycle;
    private float progress = 0;
    
    private void Start() 
    {
        firable = GetComponentInParent<IFirable>();
        building = GetComponentInParent<Building>();
        firable.onFire += HandleFire;
    }

    private void HandleFire()
    {
        progress += building.Count * progressPerCycle;
        float lifetimeRoot = Mathf.Sqrt(resource.lifeTimeValue);

        while(progress >= lifetimeRoot)
        {
            progress -= lifetimeRoot;
            resource.Value++;
            lifetimeRoot = Mathf.Sqrt(resource.lifeTimeValue);
        }
    }
}