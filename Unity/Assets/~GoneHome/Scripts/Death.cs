using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

namespace GoneHome
{
    public class Death : MonoBehaviour
    {
        public UnityEvent onDeath;
        
        void OnTriggerEnter(Collider other)
        {
            // Check if the entity came into contact 
            // with a death object
            if(other.name.Contains("DeathZone") || 
               other.name.Contains("Enemy"))
            {
                // Fire off death event
                onDeath.Invoke();
            }
        }
    }
}