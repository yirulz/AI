using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Droid : MonoBehaviour
    {
        public float health = 100;
        
        public void DealDamage(float damage)
        {
            health -= damage;
            

            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}