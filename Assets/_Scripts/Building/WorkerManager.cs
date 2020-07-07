using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public Transform container;
    public WorkerText prefab;
    public WorkerCount total;
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
        BuildWorkerText(total);
        BuildWorkerText(forager);
        BuildWorkerText(builder);
        total.Count = 1;
    }

    private void BuildWorkerText(WorkerCount workerCount)
    {
        WorkerText workerText = Instantiate(prefab, container.transform.position, Quaternion.identity, container);
        workerText.workerCount = workerCount;
    }

    private void Calculate()
    {
        if(food.Value >= total.Count)
        {
            builder.Count = total.Count;
            forager.Count = 0;
        }
        else
        {
            builder.Count = 0;
            forager.Count = total.Count;
        }
    }
}
