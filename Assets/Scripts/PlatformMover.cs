using UnityEngine;
public class PlatformMover : MonoBehaviour
{
    // 
    public Transform pointA;
    public Transform pointB;

    // platform Move Speed
    public float speed = 2.0f;

    // Platform's current target point
    private Transform currentTarget;

    void Start()
    {
        // when the game starts, set the current target to pointB
        currentTarget = pointB;
    }

    void Update()
    {
        // use Vector2.MoveTowards to move the platform towards the current target point
        // transform.position is the current position of the platform
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        // check if the platform has reached the current target point
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            // if the platform has reached the target point, switch the target point
            if (currentTarget == pointB)
            {
                currentTarget = pointA;
            }
            // if the current target is pointA, switch it to pointB
            else
            {
                currentTarget = pointB;
            }
        }
    }
}