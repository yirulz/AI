using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GoneHome
{
  

    public class FollowEnemy : MonoBehaviour
    {
        private NavMeshAgent agent;

        public Transform target;

        private Vector3 spawnPoint;

        // Use this for initialization
        void Start()
        {
            spawnPoint = transform.position;

            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(target.position);
        }

        public void Reset()
        {
            transform.position = spawnPoint;

        }
    }
}
