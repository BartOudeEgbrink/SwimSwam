using System;
using UnityEngine;

public class SwimManager : MonoBehaviour
{
    [SerializeField]
    private IntSO StatsSO;

    public float distance = 0f;
    public float laneLength = 25f;

    public float idealMinTime = 0.25f;
    public float idealMaxTime = 0.6f;

    private float lastStrokeTime;
    private bool firstStroke;

    public float strokeDistance = 1f;

    private bool expectA = true;
    private SwimState state = SwimState.SwimmingForward;
    
    public enum SwimState
    {
        SwimmingForward,
        Turning
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case SwimState.SwimmingForward:
                HandleSwimming();
                break;

            case SwimState.Turning:
                HandleTurn();
                break;
        }
    }

    private void HandleSwimming()
    {
        if (expectA && Input.GetKeyDown(KeyCode.A))
        {
            Stroke();
            expectA = false;
        }
        if (!expectA && Input.GetKeyDown(KeyCode.D))
        {
            Stroke();
            expectA = true;
        }
    }

    private void Stroke()
    {
        float efficiency = 1f;

        if (firstStroke)
        {
            float timeSinceLastStroke = Time.time - lastStrokeTime;
            efficiency = CalculateTimingEfficiency(timeSinceLastStroke);

            Debug.Log($"Timing: {timeSinceLastStroke:F2}s | Efficiency: {efficiency:F2}");
        }

        lastStrokeTime = Time.time;
        firstStroke = true;

        float statBonus = StatsSO.Strength * 0.05f;
        float totalDistance = (strokeDistance + statBonus) * efficiency;

        distance += totalDistance;

        if (distance >= laneLength)
        {
            state = SwimState.Turning;
            Debug.Log("Reached the Wall, Press Space to Turn");
            return;
        }

        Debug.Log("Distance: " + distance);
    }

    private float CalculateTimingEfficiency(float time)
    {
        if (time < idealMinTime)
        {
            return 0.6f; // Too Fast
        }
        if (time > idealMaxTime)
        {
            return 0.8f; // Too slow
        }

        return 1.2f;
    }

    private void HandleTurn()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            distance = 0f;
            state = SwimState.SwimmingForward;
            expectA = true;

            Debug.Log("Turn Sucessfull");
        }
    }
}
