using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{

    public class Player : MonoBehaviour
    {

        private Rigidbody rigid;
        private Transform cam;
        //Records the starting point


        public float movementSpeed = 20f;
        public float maxVelocity = 20f;
        private Vector3 spawnPoint;
        public GameObject deathParticles;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
            cam = Camera.main.transform;
            spawnPoint = transform.position;



        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }

        void Movement()
        {
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");

            Vector3 inputDir = new Vector3(inputH, 0, inputV);
            inputDir = Quaternion.AngleAxis(cam.eulerAngles.y, Vector3.up) * inputDir;

            //Add force in the inputDir direction
            rigid.AddForce(inputDir * movementSpeed);

            Vector3 vel = rigid.velocity;

            // If velocity reaches max
            if (vel.magnitude > maxVelocity)
            {
                // Cap the velocity
                vel = vel.normalized * maxVelocity;
            }

            //Apply the velocity to rigidbody
            rigid.velocity = vel;

        }

        public void Reset()
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            transform.position = spawnPoint;

            //Sets velocity to 0 when you die
            rigid.velocity = Vector3.zero;
            

        }
    }
}