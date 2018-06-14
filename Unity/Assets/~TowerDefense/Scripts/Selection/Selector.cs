using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class Selector : MonoBehaviour
    {
        public GameObject[] prefabs;
        public LayerMask layerMask;

        private GameObject[] instances; // genertated instances of current selection
        private Transform tower, hologram; // reference to both currenttower and hologram
        private int currentTower;

        //Selects the current tower index
        public void SelectTower(int index)
        {
            //is the index greater than 0 or greater than amount of prefabs
            if(index < 0 || index > prefabs.Length)
            {
                return;
            }

            //set the new index
            currentTower = index;
        }

        void GenerateInstances()
        {
            GameObject instance = instances[currentTower];
            if(instance == null)
            {
                instance = Instantiate(prefabs[currentTower]); //Create new instance
                instance.transform.SetParent(transform); //Attach to paremt

                //Find both sub gameobects
                tower = instance.transform.Find("Tower");
                hologram = instance.transform.Find("Hologram");

                //Disable both gameobjects
                tower.gameObject.SetActive(false);
                hologram.gameObject.SetActive(false);

                //Store new instance in array
                instances[currentTower] = instance;



            }
        }

        void Start()
        {
            instances = new GameObject[prefabs.Length];
        }

        void Update()
        {
            GenerateInstances();

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(mouseRay, out hit, 1000f, layerMask, QueryTriggerInteraction.Ignore))
            {
                Placeable p = hit.transform.GetComponent<Placeable>();

                if(p && !p.isPlaced)
                {
                    GameObject gHolo = hologram.gameObject;
                    GameObject gTower = tower.gameObject;

                    if (!gHolo.activeSelf)
                    
                        gHolo.SetActive(true);

                    GameObject instance = instances[currentTower];
                    instance.transform.position = p.transform.position;
                    
                    //if mouse button is pressed
                    if(Input.GetMouseButtonDown(0))
                    {
                        p.isPlaced = true;
                        gHolo.SetActive(false);
                        gTower.SetActive(true);

                        instances[currentTower] = null;
                    }
                }
            }
        }

    }
}