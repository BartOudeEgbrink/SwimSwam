using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField]
    private IntSO StatsSO;

    private int maxEnergy = 100;

    public void AddEndurance(int amount)
    {
        StatsSO.Endurance += amount;
    }

    public void RemoveEndurance(int amount)
    {
        if (StatsSO.Endurance - amount < 0)
        {
            StatsSO.Endurance = 0;
        } else
        {
            StatsSO.Endurance -= amount;
        }
    }

    public void AddStrength(int amount)
    {
        StatsSO.Strength += amount;
    }

    public void RemoveStrength(int amount)
    {
        if (StatsSO.Strength - amount < 0)
        {
            StatsSO.Strength = 0;
        }
        else
        {
            StatsSO.Strength -= amount;
        }
    }

    public bool OutOfEnergy()
    {
        return StatsSO.Energy <= 0;
    }


    public bool RemoveEnergy(int amount)
    {
        if (StatsSO.Energy >= amount)
        {
            StatsSO.Energy -= amount;
            return true;
        }
        return false;
    }

    public void AddEnergy(int amount)
    {
        if (StatsSO.Energy + amount > maxEnergy)
        {
            StatsSO.Energy = StatsSO.Energy;
        }
        else
        {
            StatsSO.Energy += amount;
        }
    }
}
