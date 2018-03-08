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
            //Get current active scene
            Scene currentScene = SceneManager.GetActiveScene();

            //Loads the next same scene
            SceneManager.LoadScene(currentScene.buildIndex);
        }

    }
}