using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class Game_inMenu : Menu<Game_inMenu>
    {


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPress_Pause();
            }
        }



        public void OnPress_Pause()
        {
            Time.timeScale = 0;

            PauseScreen.Open_T();
        }
    } 
}
