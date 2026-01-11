using System;
using UnityEditor;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public StatsManager statsManager;
    
    public enum JobType
    {
        Cashier,
        LifeGuard,
        SwimmingInstructor,
        SwimCoach
    }

    public int money = 50;
    public int workCost = 50;
    public JobType currentJob = JobType.Cashier;
    //public event Action OnWorked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Work()
    {
        if (!statsManager.RemoveEnergy(workCost))
        {
            Debug.Log("Too tired to work!");
            return;
        }

        switch (currentJob)
        {
            case JobType.Cashier:
                money = money + 2;
                break;
            case JobType.LifeGuard:
                money = money + 4;
                break;
            case JobType.SwimmingInstructor:
                money = money + 7;
                break;
            case JobType.SwimCoach:
                money = money + 10;
                break;
            default:
                Debug.Log("Job not found");
                break;
        }
        //statsManager.RemoveEnergy(workCost);
    }
    
    public void UpgradeWork()
    {
        int numberOfJobs = Enum.GetNames(typeof(JobType)).Length; // Get enum size
        if ((int)currentJob + 1 <= numberOfJobs)
        {
            currentJob++;
        }
        else
        {
            Debug.Log("Already at the best job!");
        }
    }
}
