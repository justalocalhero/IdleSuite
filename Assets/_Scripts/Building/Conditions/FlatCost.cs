using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatCost : MonoBehaviour, IResourceCost
{
    public List<ResourceValue> costs;

    public List<ResourceValue> GetCost()
    {
        return costs;
    }
}

public interface IResourceCost
{
    List<ResourceValue> GetCost();
}
