using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Transform waypointGroup;
    public float movementSpeed = 5f;
    public float closeness = 1f; // how close before switching to new target

    private Transform[] waypoints;
    private int currentIndex = 0;

    // Use this for initialization
    void Start()
    {
        int length = waypointGroup.childCount;
        waypoints = new Transform[length];

        for (int i = 0; i < length; i++)
        {
            waypoints[i] = waypointGroup.GetChild(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Get current waypoint
        Transform current = waypoints[currentIndex];
        //Move enemy in direction of waypoint
        Vector3 position = transform.position;
        Vector3 direction = current.position - position;
        position += direction.normalized * movementSpeed * Time.deltaTime;
        //normalized shrinks the vector 3 down so you can move at consistant speed
        transform.position = position;

        //Check closeness of anemy to current waypoint
        float distance = Vector3.Distance(position, current.position);
        //Is the enemy close to the current waypoint?
        if(distance <= closeness)
        {
            // Switch to next waypoint
            currentIndex++;
        }
        // Is currentIndex greater than or equal to length?

        if(currentIndex >= waypoints.Length)
        {
            //Loop back to the start
            currentIndex = 0;
        }
    }
}
