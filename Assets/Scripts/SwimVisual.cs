using UnityEngine;

public class SwimVisual : MonoBehaviour
{
    public Transform topWall;
    public Transform bottomWall;
    public SwimManager swimManager;

    // Update is called once per frame
    void Update()
    {
        float t = swimManager.distance / swimManager.laneLength;

        t = Mathf.Clamp01(t); // Make sure to not go past walls (0 - 1)

        transform.position = Vector3.Lerp(
            topWall.position,
            bottomWall.position,
            t
        );
    }
}
