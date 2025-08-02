using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA; // Start PointA
    [SerializeField] private Transform pointB; // End PointB
    [SerializeField] private float speed = 2f; // Movement speed of the platform

    private Vector3 targetPos;

    void Start()
    {
        // Platform starts at point A
        transform.position = pointA.position;
        // Set the initial target position to point B
        targetPos = pointB.position;
    }

    void Update()
    {
        // update the platform's position towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // check if the platform has reached the target position
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            //change the target position to the other point
            if (targetPos == pointB.position)
            {
                targetPos = pointA.position;
            }
            // if the target position is point A, change it to point B
            else
            {
                targetPos = pointB.position;
            }
        }
    }
}