using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI statText = null;

    public TimeManager timeManager;
    public MoneyManager moneyManager;
    public StatsManager statsManager;
    [SerializeField]
    private IntSO StatsSO;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeManager.OnDayEnded += HandleDayEnded;
    }


    // Update is called once per frame
    void Update()
    {
        statText.text =
            "Day: " + timeManager.day +
            "\nHour: " + timeManager.hour +
            "\nEndurance: " + StatsSO.Endurance +
            "\nEnergy: " + StatsSO.Energy +
            "\nMoney: " + moneyManager.money;
    }

    public void Train()
    {
        if (StatsSO.Energy >= 10)
        {
            statsManager.AddEndurance(1);
            statsManager.RemoveEnergy(50);
            timeManager.AdvanceTime(2);
            Debug.Log("Trained Endurence: " + StatsSO.Endurance);
            Debug.Log("Energy is now: " + StatsSO.Energy);
        }
        else
        {
            Debug.Log("Not enough energy");
        }
    }

    private void HandleDayEnded()
    {
        statsManager.AddEnergy(100);
        Debug.Log("Day: " + timeManager.day);
    }
}
