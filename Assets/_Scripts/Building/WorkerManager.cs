using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    private List<Workers> workers = new List<Workers>();
    public Transform container;
    public WorkerText workerPrefab;
    public ResourceText reosurcePrefab;
    public Resource total;
    public WorkerCount forager;
    public WorkerCount builder;
    public MetaResource food;
    public int reserveBuilder;

    public static WorkerManager instance;

    void Awake()
    {
        if(instance != null) Destroy(this);
        else instance = this;

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
        int remaining = total.Free;

        if(food.Value < remaining)
        {
            forager.Count = remaining;
            remaining = 0;
        }
        else
        {
            forager.Count = 0;
        }

        int builders = Mathf.Min(reserveBuilder, remaining);
        remaining -= builders;        

        foreach(Workers worker in workers)
        {
            int workerCount = Mathf.Min(worker.Prefer, remaining);
            remaining -= workerCount;
            worker.Value = workerCount;

            Debug.Log(workerCount + " : " + remaining);
        }

        builders += remaining;

        builder.Count = builders;
    }

    public void Register(Workers worker)
    {
        worker.onChanged += Calculate;
        workers.Add(worker);

    }
}
