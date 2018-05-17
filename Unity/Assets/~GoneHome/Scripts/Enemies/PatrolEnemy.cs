using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{
    public class PatrolEnemy : MonoBehaviour
    {
        public Transform waypointGroup;
        public float movementSpeed = 5f;
        public float closeness = 1f;

        private Transform[] waypoints;
        private int currentIndex = 0;

        // Use this for initialization
        void Start()
        {
            int length = waypointGroup.childCount;
            waypoints = new Transform[length];

        //  for (initialization; condition ; iteration)
            for (int i = 0; i < length; i++)
            {
                // statements
                waypoints[i] = waypointGroup.GetChild(i); 
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Get current waypoint
            Transform current = waypoints[currentIndex];
            // Move enemy towards current waypoint
            Vector3 position = transform.position; // my position

            Vector3 direction = current.position - position;
            position += direction.normalized * movementSpeed * Time.deltaTime;

            transform.position = position; // Applying the modified position to Enemy

            // Check closeness of enemy to current waypoint
            float distance = Vector3.Distance(current.position, position);
            // Is the enemy close to current waypoint?
            if (distance <= closeness)
            {
                // Move to next waypoint
                currentIndex++;
            }

            // Check if index goes out of range
            if (currentIndex >= waypoints.Length)
            {
                // Reset index to zero
                currentIndex = 0;
            }
        }
    }
}