using System.Collections.Generic;

public class RemoveStorage : Effect
{
     private StorageValues storageValues;

    protected override void OnAwake()
    {
        storageValues = GetComponentInParent<HeirarchyNode>().GetComponentInChildren<StorageValues>();
    }
    
    public override void FireEffect(int fireCount)
    {
        foreach(ResourceValue resourceValue in storageValues.GetValues())
        {
            resourceValue.resource.Maximum -= resourceValue.value * fireCount;
        }
    }
}