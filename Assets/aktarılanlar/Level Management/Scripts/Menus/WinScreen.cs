using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class WinScreen : Menu<WinScreen>
    {

        public void OnPress_Next_Level()
        {
            base.OnPress_Back();
            LevelLoader.Load_Next_Level();
        }


        public void OnPress_Restart()
        {
            base.OnPress_Back();
            LevelLoader.Reload_Level();
        }


        public void OnPress_mainMenu()
        {
            LevelLoader.Load_MainMenu();
            MainMenu.Open_T();
        }
    }
}
