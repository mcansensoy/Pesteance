using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelLoader : MonoBehaviour
    {
        private static int mainMenu_index = 0;








        //------------------ loads a level by name-----------------
        public static void LoadLevel(string levelName)
        {
            // if the scene is in the BuildSettings, load the scene
            if (Application.CanStreamedLevelBeLoaded(levelName))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("GAMEMANAGER LoadLevel Error: invalid scene specified!");
            }
        }

        //--------------------------------------








        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
            {

                if (levelIndex == mainMenu_index)
                {
                    MainMenu.Open_T();
                }

                UnityEngine.SceneManagement.SceneManager.LoadScene(levelIndex);
            }
        }


        public static void Reload_Level()
        {
            LoadLevel(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }


        public static void Load_Next_Level()
        {

            int next_sceneIndex = (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1)
                % UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;

            next_sceneIndex = Mathf.Clamp(next_sceneIndex, mainMenu_index, next_sceneIndex);
            LoadLevel(next_sceneIndex);
        }



        public static void Load_MainMenu()
        {
            LoadLevel(mainMenu_index);
        }

    } 
}
