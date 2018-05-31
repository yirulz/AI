using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public float maxHealth = 100;
        [Header("UI")]
        public GameObject healthBarUI;
        public Vector2 healthBarOffset = new Vector2(0, 5f);

        private Slider healthSlider;
        private float health = 100f;

        void Start()
        {
            health = maxHealth;
        }


        void Update()
        {
            //If health slider exists
            if (healthSlider)
            {
                //Update health slider's position
                healthSlider.transform.position = GetHealthBarPos();
            }
        }

        Vector3 GetHealthBarPos()
        {
            Camera cam = Camera.main;
            //Converts world position to screen
            Vector3 position = cam.WorldToScreenPoint(transform.position);
            //Returns screen position + offset (in pixels)
            return position + (Vector3)healthBarOffset;
        }

        public void SpawnHealthBar(Transform parent)
        {
            GameObject clone = Instantiate(healthBarUI, GetHealthBarPos(), Quaternion.identity, parent);

            //Store the slider component for later use
            healthSlider = clone.GetComponent<Slider>();
        }


        public void DealDamage(float damage)
        {
            maxHealth -= damage;
            

            if(maxHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}