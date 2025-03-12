using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class PauseScreen : Menu<PauseScreen>
    {

        public void OnPress_Resume()
        {
            Time.timeScale = 1;
            base.OnPress_Back();
        }

        public void OnPress_Restart()
        {
            Time.timeScale = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            base.OnPress_Back();
        }

        public void OnPress_Menu()
        {
            Time.timeScale = 1;
            LevelLoader.Load_MainMenu();

            MainMenu.Open_T();
        }

        public void OnPress_Quit()
        {
            Application.Quit();
        }


    } 
}
