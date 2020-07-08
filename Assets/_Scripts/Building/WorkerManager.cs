using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public Transform container;
    public WorkerText workerPrefab;
    public ResourceText reosurcePrefab;
    public Resource total;
    public WorkerCount forager;
    public WorkerCount builder;
    public MetaResource food;

    void Awake()
    {
        total.onChanged += Calculate;
        food.onChanged += Calculate;        
    }

    void Start()
    {
        total.ResetResource();
        BuildText(total);
        BuildText(forager);
        BuildText(builder);
    }

    private void BuildText(WorkerCount workerCount)
    {
        WorkerText workerText = Instantiate(workerPrefab, container.transform.position, Quaternion.identity, container);
        workerText.workerCount = workerCount;
    }

    private void BuildText(Resource resource)
    {
        ResourceText resourceText = Instantiate(reosurcePrefab, container.transform.position, Quaternion.identity, container);
        resourceText.resource = resource;
    }

    private void Calculate()
    {
        if(food.Value >= total.Free)
        {
            builder.Count = total.Free;
            forager.Count = 0;
        }
        else
        {
            builder.Count = 0;
            forager.Count = total.Free;
        }
    }
}
