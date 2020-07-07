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

    public int Consume
    {
        set
        {
            int remaining = value;

            for(int i = 0; i < resources.Count; i++)
            {
                if(remaining <= 0) return;

                MetaResourceData data = resources[i];
                
                if(!data.consume) continue;

                int count = remaining / data.value;

                if(count <= 0) continue;

                count = Mathf.Clamp(count, 0, data.resource.Value);
                data.resource.Value -= count;
                remaining -= (count * data.value);
                resources[i] = data;
            }

            for(int i = 0; i < resources.Count; i++)
            {
                if(remaining <= 0) return;       

                MetaResourceData data = resources[i];

                if(!data.consume) continue;
                if(data.resource.Value <= 0) continue;

                data.resource.Value--;
                remaining -= (data.value * data.resource.Value);

                resources[i] = data;
            }            
        }
    }

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