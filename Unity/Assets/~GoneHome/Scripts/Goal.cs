using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

namespace GoneHome
{
    public class Goal : MonoBehaviour
    {
        public UnityEvent onTriggered;
        
        // Fired off when another collider enters goal
        void OnTriggerEnter(Collider other)
        {
            // Detect if other collider is player
            if (other.name == "Player")
            {
                // Fire off our event (onTriggered)
                onTriggered.Invoke();
            }
        }
    }
}
