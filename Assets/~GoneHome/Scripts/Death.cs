using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{

    public class Death : MonoBehaviour
    {
        void Died()
        {
            //Play animation
            //Spawn particles
            //Perform toher events...
            print("The " + name + " has died.");
        }

        //Detects collision with other triggers
        void OnTriggerEnter(Collider other)
        {
            //Have we hit a 'DeathZone'? or 'Enemy'
            if (other.name == "DeathZone" || other.name == "Enemy")
            {
                //KILL IT!
                Died();
            }
        }
    }
}