using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public ResourceText resourcePrefab;
    public MetaResourceText metaResourcePrefab;
    public Transform container;
    public List<Resource> resources;
    public List<MetaResource> metaResources;

    void Awake()
    {
        foreach(MetaResource metaResource in metaResources)
        {
            metaResource.ResetResource();
        }

        foreach(Resource resource in resources)
        {
            resource.ResetResource();
        }

        foreach(MetaResource metaResource in metaResources)
        {
            MetaResourceText text = Instantiate(metaResourcePrefab, container.position, Quaternion.identity, container);
            text.metaResource = metaResource;
        }

        foreach(Resource resource in resources)
        {
            if(resource.metaResources.Length != 0) continue;
            ResourceText text = Instantiate(resourcePrefab, container.position, Quaternion.identity, container);
            text.resource = resource;
        }
    }
}