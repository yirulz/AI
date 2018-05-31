using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class EnemySpawner : Spawner
    {
        public float spawnRadius = 1f;
        public Transform path;
        [Header("UI")]
        public Transform healthBarParent;

        private Transform start;  //Spawn enemy
        private Transform end;  //where enemy travels to
        
        void GetPath()
        {
            if(path != null)
            {
                start = path.FindChild("Start");
                end = path.FindChild("End");
                
            }
        }

        // Use this for initialization
        void Start()
        {
            GetPath();
        }
        
        void OnDrawGizmos()
        {
            GetPath();
            if(start != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(start.position, spawnRadius);
            }
        }

        public override void Spawn()
        {
            GameObject clone = Instantiate(prefab, start.position, start.rotation);

            clone.transform.SetParent(transform);

            AIAgent agent = clone.GetComponent<AIAgent>();
            agent.target = end;
            //Spawn a health bar
            Enemy enemy = clone.GetComponent<Enemy>();
            enemy.SpawnHealthBar(healthBarParent);
        }
    }
}