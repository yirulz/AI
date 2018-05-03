using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{
    [RequireComponent(typeof(ParticleSystem))]
    public class DestroyOnFinish : MonoBehaviour
    {

        private ParticleSystem ps;

        void Start()
        {

            ps = GetComponent<ParticleSystem>();
        }

        // Update is called once per frame
        void Update()
        {
            if (ps != null && !ps.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}