using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefense
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIAgent : MonoBehaviour
    {
        [System.NonSerialized]
        public Transform target;

        private NavMeshAgent nav;

        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();

        }

        void Update()
        {
            if (target != null)
            {
                nav.SetDestination(target.position);
            }
        }



    }
}