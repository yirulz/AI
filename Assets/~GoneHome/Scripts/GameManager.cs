using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace GoneHome

{
    public class GameManager : MonoBehaviour
    {
        public void NextLevel()
        {
            //Get current active scene
            Scene currentScene = SceneManager.GetActiveScene();

            // Load the next build index
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }


        public void RestartLevel()
        {

            // Grab all enemies in the scene into array
            FollowEnemy[] followEnemies = FindObjectsOfType<FollowEnemy>();
            PatrolEnemy[] patrolEnemies = FindObjectsOfType<PatrolEnemy>();

            // Loop through all enemies
            foreach (var enemy in followEnemies)
            {
                // Reset enemy
                enemy.Reset();
            }

            foreach (var enemy in patrolEnemies)
            {
                enemy.Reset();
            }


            // Grab the player in the scene
            Player player = FindObjectOfType<Player>();

            player.Reset();
            // Reset player


            /*//Get current active scene
            Scene currentScene = SceneManager.GetActiveScene();

            //Loads the next same scene
            SceneManager.LoadScene(currentScene.buildIndex);*/
        }



    }
}