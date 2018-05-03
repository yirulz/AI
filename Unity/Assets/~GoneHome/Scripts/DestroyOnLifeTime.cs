using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoneHome
{

    public class DestroyOnLifeTime : MonoBehaviour
    {
        public float lifeTime = 5f;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }
    }
}