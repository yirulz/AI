using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class Tower : MonoBehaviour
    {
        public float damage = 10f;

        public float attackDelay = 1f;

        protected Enemy currentEnemy;

        private float attackTimer = 0f;

        public virtual void Aim(Enemy e) { }
        public virtual void Attack(Enemy e) { }

        protected virtual void Update()
        {
            attackTimer += Time.deltaTime;
            //If there is a current enemy the tower is targetting
            if (currentEnemy)
            {
                //Aim at current enemy
                Aim(currentEnemy);
                if (attackTimer > attackDelay)
                {
                    //Attack the current enemy
                    Attack(currentEnemy);
                    attackTimer = 0f;
                }
            }


        }

        void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null && currentEnemy == null)
            {
                currentEnemy = enemy;
            }
        }

        void OnTriggerExit(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null && currentEnemy == enemy)
            {
                currentEnemy = null;
            }
        }

    }
}