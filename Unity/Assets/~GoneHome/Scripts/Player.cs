using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{
    public class Player : MonoBehaviour
    {
        public float acceleration = 10f;
        public float maxVelocity = 20f;
        public GameObject deathParticles; // Explosion prefab

        private Rigidbody rigid;
        private Vector3 spawnPoint; // ADDED THIS

        #region Unity Functions
        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();

            spawnPoint = transform.position; // Store starting pos
        }

        // Update is called once per frame
        void Update()
        {
            // Get input axis
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");

            // Create a directional vector with input
            Vector3 inputDir = new Vector3(inputH, 0, inputV);

            // Depending on rotation of camera, change the direction of input
            Transform cam = Camera.main.transform;
            inputDir = Quaternion.AngleAxis(cam.eulerAngles.y, Vector3.up) * inputDir;

            // Acceleration logic
            rigid.AddForce(inputDir * acceleration);

            // Check if our velocity goes over maxVelocity
            if (rigid.velocity.magnitude > maxVelocity)
            {
                // Cap the velocity down to max
                rigid.velocity = rigid.velocity.normalized * maxVelocity;
            }
        }
        #endregion

        #region Custom Functions
        public void Reset()
        {
            // Spawn death particles here
            GameObject clone = Instantiate(deathParticles);
            // Set position of particles to player position
            clone.transform.position = transform.position; 
            // Reset position back to spawn point
            transform.position = spawnPoint;
            // Reset the player's velocity
            rigid.velocity = Vector3.zero;
        }
        #endregion
    }
}
