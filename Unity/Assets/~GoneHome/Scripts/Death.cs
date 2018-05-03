using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



namespace GoneHome
{

    public class Death : MonoBehaviour
    {
        public UnityEvent onDeath;


        //Detects collision with other triggers
        void OnTriggerEnter(Collider other)
        {
            //Have we hit a 'DeathZone'? or 'Enemy'
            if (other.name.Contains("DeathZone") || other.name.Contains("Enemy"))
            {
                //KILL IT!
                onDeath.Invoke();
            }
        }
    }
}