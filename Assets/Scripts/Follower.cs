using PathCreation;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    public float speedByTime = 3;
    public float maxSpeed = 25;
    float distanceTraveled;


    private void FixedUpdate()
    {
        if (speed <= maxSpeed)
        {
            speed += Time.deltaTime * speedByTime;

        }
        distanceTraveled += Time.deltaTime * speed;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTraveled);
    }
}
