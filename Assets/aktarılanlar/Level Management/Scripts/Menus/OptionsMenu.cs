using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement
{
    public class OptionsMenu : Menu<OptionsMenu>
    {
       
       // public static object Instance { get; internal set; }
        private DataManager _dataManager;

        [SerializeField] private Slider slider_Master, slider_Music, slider_Sfx;




        //protected override void Awake()
        //{
        //    base.Awake();
        //    _dataManager = Object.FindObjectOfType<DataManager>();
        //}



        private void Start()
        {
            //Load_Data();
            Load_Audio();
        }








        //public void On_Changed_MasterVolume(float volume_master)
        //{
        //    if (_dataManager != null)
        //    {
        //        _dataManager.MasterVolume = volume_master;
        //    }

        //   // PlayerPrefs.SetFloat("Master volume", volume_master);
        //}

        //public void On_Changed_MusicVolume(float volume_music)
        //{
        //    if (_dataManager != null)
        //    {
        //        _dataManager.MusicVolume = volume_music;
        //    }

        //    //PlayerPrefs.SetFloat("Music volume", volume_music);
        //}

        //public void On_Changed_SfxVolume(float volume_sfx)
        //{
        //    if (_dataManager != null)
        //    {
        //        _dataManager.SfxVolume = volume_sfx;
        //    }

        //    //PlayerPrefs.SetFloat("Sfx volume", volume_sfx);
        //}







        //public void Load_Data()
        //{
        //    if(_dataManager==null 
        //        || slider_Master == null || slider_Music == null || slider_Sfx == null)
        //    {
        //        return;
        //    }

        //    _dataManager.Load_dm();


        //    slider_Master.value = _dataManager.MasterVolume;
        //    slider_Music.value = _dataManager.MusicVolume;
        //    slider_Sfx.value = _dataManager.SfxVolume;

        //    //slider_Master.value = PlayerPrefs.GetFloat("Master volume");
        //    //slider_Music.value = PlayerPrefs.GetFloat("Music volume");
        //    //slider_Sfx.value = PlayerPrefs.GetFloat("Sfx volume");
        //}








        public void Set_audio(float sound_value)
        {
            AudioListener.volume = sound_value;
            Save_auido();
        }

        private void Save_auido()
        {
            PlayerPrefs.SetFloat("audio_Volume", AudioListener.volume);
        }

        private void Load_Audio()
        {
            if (PlayerPrefs.HasKey("audio_Volume"))
            {
                AudioListener.volume = PlayerPrefs.GetFloat("audio_Volume");
                slider_Music.value = PlayerPrefs.GetFloat("audio_Volume");
            }
            else
            {
                PlayerPrefs.SetFloat("audio_Volume", 0.5f);
                AudioListener.volume = PlayerPrefs.GetFloat("audio_Volume");
                slider_Music.value = PlayerPrefs.GetFloat("audio_Volume");
            }

        }

































        public override void OnPress_Back()
        {
            base.OnPress_Back();
            //PlayerPrefs.Save();

            if (_dataManager != null)
            {
                _dataManager.Save_dm();
            }
        }
    } 
}
