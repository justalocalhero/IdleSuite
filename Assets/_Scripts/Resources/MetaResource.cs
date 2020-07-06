using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "IdleSuite/MetaResource", order = 0)]
public class MetaResource : ScriptableObject 
{
    public delegate void OnValueChanged(int value);
    public OnValueChanged onValueChanged;

    public delegate void OnChanged();
    public OnChanged onChanged;

    public void RaiseOnValueChanged(int dud)
    {
        if(onValueChanged != null) onValueChanged(Value);
        if(onChanged != null) onChanged();
    }

    public struct MetaResourceData
    {
        public Resource resource;
        public int value;
        public bool consume;
    }

    public List<MetaResourceData> resources = new List<MetaResourceData>();

    public int Value 
    {
        get
        {
            int toReturn = 0;

            foreach(MetaResourceData resourceData in resources)
            {
                if(resourceData.consume) toReturn += resourceData.resource.Free;
            }

            return toReturn;
        }
    }

    public void ResetResource()
    {
        foreach(MetaResourceData data in resources)
        {
            data.resource.onValueChanged -= RaiseOnValueChanged;
            data.resource.onReservedChanged -= RaiseOnValueChanged;
        }

        resources = new List<MetaResourceData>();
    }

    public void AddResource(Resource resource, int value, bool consume)
    {
        resources.Add(new MetaResourceData()
        {
            resource = resource,
            value = value,
            consume = consume
        });

        resource.onValueChanged += RaiseOnValueChanged;
        resource.onReservedChanged += RaiseOnValueChanged;
    }
}

[System.Serializable]
public struct MetaResourceValue
{
    public MetaResource metaResource;
    public int value;
}