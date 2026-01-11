using System;
using Unity.VisualScripting;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int day = 1;
    public int hour = 12;

    private int maxHours = 24;

    public event Action OnDayEnded;

    public void AdvanceTime(int hours)
    {
        hour += hours;

        if (hour >= maxHours)
        {
            EndDay();
        }
    }

    public void EndDay()
    {
        day++;
        hour = 6;

        OnDayEnded?.Invoke();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
