using UnityEngine;

public class TimingRingController : MonoBehaviour
{
    public Animator animator;

    public int failEndStart = 64 - 59;      // red
    public int weakEndStart = 70 - 59;     // orange
    public int goodEnd = 78 - 59;            // green
    public int weakEnd = 84 - 59;     // orange
    public int failEnd = 89 - 59;      // red
    public int totalFrames = 30;

    public float GetTimingMultiplier()
    {
        int frame = GetCurrentFrame();

        if (frame <= failEndStart)
            return 0f;       // miss
        if (frame <= weakEndStart)
            return 0.7f;     // weak
        if (frame <= goodEnd)
            return 1.2f;     // good
        if (frame <= weakEnd)
            return 0.7f;       // weak
        if (frame <= failEnd)
            return 0f;     // miss

        return 0f;           // late miss
    }
    int GetCurrentFrame()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        float normalizedTime = state.normalizedTime % 1f;

        return Mathf.FloorToInt(normalizedTime * totalFrames);
    }
}
