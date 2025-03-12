using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LevelManagement.Data;


namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        [SerializeField] private float _playDelay = 0.5f;
        [SerializeField] private TransitionFader start_Transition_prefab;

        private DataManager _dataManager;
        [SerializeField] private TMP_InputField _inputField;




        protected override void Awake()
        {
            base.Awake();
            _dataManager = Object.FindObjectOfType<DataManager>();
        }


        private void Start()
        {
            Load_Data_mm();
        }




        private void Load_Data_mm()
        {
            if (_dataManager != null && _inputField != null)
            {
                _dataManager.Load_dm();
                _inputField.text = _dataManager.PlayerName;
            } 
        }


        public void On_Changed_PlayerName(string player_name)
        {
            if (_dataManager != null)
            {
                _dataManager.PlayerName = player_name;
            }
        }

        public void On_Edit_PlayerName()
        {
            if (_dataManager != null)
            {
                _dataManager.Save_dm();
            }
        }







//----------------Buttons Menus--------------------------------------


        public void OnPress_Options()
        {
            OptionsMenu.Open_T();
        }

        public void OnPress_Credits()
        {
            CreditsMenu.Open_T();
        }

        public override void OnPress_Back()
        {
            Application.Quit();
        }






        public void OnPress_Play()
        {
            StartCoroutine(OnPress_Play_Routine());
           // LevelSelectMenu.Open_T();
        }

        private IEnumerator OnPress_Play_Routine()
        {
            TransitionFader.Play_transition(start_Transition_prefab);
            LevelLoader.Load_Next_Level();
            yield return new WaitForSeconds(_playDelay);
            Game_inMenu.Open_T();
        }


    } 
}
