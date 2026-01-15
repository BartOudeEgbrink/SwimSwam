using System;
using UnityEngine;

public class SwimManager : MonoBehaviour
{
    public TimingRingController timingRing;
    [SerializeField]
    private IntSO StatsSO;

    public float distance = 0f;
    public float laneLength = 25f;

    public float baseSpeed = 2f;
    public float currentSpeed = 2f;
    public float maxSpeed = 4f;
    public float minSpeed = 0f;

    public float speedRecoveryRate = 0.5f; // how fast it returns to base

    public float strokeDistance = 1f;

    private bool expectA = true;
    private bool evenLane = true;
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
                MoveSwimmer();
                HandleSwimming();
                break;

            case SwimState.Turning:
                HandleTurn();
                break;
        }
    }

    private void MoveSwimmer()
    {
        currentSpeed = Mathf.MoveTowards(
            currentSpeed,
            baseSpeed,
            speedRecoveryRate * Time.deltaTime
        );

        float direction = evenLane ? 1f : -1f;
        distance += currentSpeed * direction * Time.deltaTime;

        if (distance >= laneLength)
        {
            distance = laneLength;
            state = SwimState.Turning;
        }
        else if (distance <= 0f)
        {
            distance = 0f;
            state = SwimState.Turning;
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
        float efficiency = timingRing.GetTimingMultiplier();

        if (efficiency <= 0f)
        {
            // Missed stroke → maybe slow down or stall
            currentSpeed = 0;
            Debug.Log($"Stroke efficiency: {efficiency}, Speed: {currentSpeed}");
            return;
        }

        currentSpeed += efficiency;
        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);

        Debug.Log($"Stroke efficiency: {efficiency}, Speed: {currentSpeed}");
    }

    private void HandleTurn()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // distance = 0f;
            state = SwimState.SwimmingForward;
            expectA = true;
            evenLane = !evenLane;

            Debug.Log("Turn Sucessfull");
        }
    }
}
