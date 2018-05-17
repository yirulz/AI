using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace GoneHome
{
    public class GameManager : MonoBehaviour
    {
        // Switch to next level when this function runs
        public void NextLevel()
        {
            // Get active scene
            Scene currentScene = SceneManager.GetActiveScene();
            // Load the next scene up using buildIndex
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }

        public void ResetLevel()
        {
            // Grab all enemies
            FollowEnemy[] enemies = FindObjectsOfType<FollowEnemy>();
            // Loop through all enemies and reset them
            for (int i = 0; i < enemies.Length; i++)
            {
                // Reset
                enemies[i].Reset();
            }
            // Grab the player and reset it
            Player player = FindObjectOfType<Player>();
            player.Reset();
        }
    }
}