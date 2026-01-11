using UnityEngine;

[CreateAssetMenu(fileName = "IntSO", menuName = "Scriptable Objects/IntSO")]

public class IntSO : ScriptableObject
{
    private int _strength = 1;
    private int _endurance = 1;
    private int _energy = 100;

    public int Strength
    {
        get { return _strength; }
        set { _strength = value; }
    }

    public int Endurance
    {
        get { return _endurance; }
        set { _endurance = value; }
    }

    public int Energy
    {
        get { return _energy; }
        set { _energy = value; }
    }
}
