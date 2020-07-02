using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatValue : MonoBehaviour, IResourceValue
{
    public List<ResourceValue> values;

    public List<ResourceValue> GetValue()
    {
        return values;
    }
}

public interface IResourceValue
{
    List<ResourceValue> GetValue();
}
