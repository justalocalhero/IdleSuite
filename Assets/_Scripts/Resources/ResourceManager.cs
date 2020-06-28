using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public ResourceText prefab;
    public Transform container;
    public List<Resource> resources;

    void Start()
    {
        foreach(Resource resource in resources)
        {
            resource.ResetResource();
            ResourceText text = Instantiate(prefab, container.position, Quaternion.identity, container);
            text.resource = resource;
        }
    }
}
