using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Data
{
    public class DataManager : MonoBehaviour
    {
        private SaveData _saveData;
        private JSonSaver _jsonSaver;



        private void Awake()
        {
            _saveData = new SaveData();
            _jsonSaver = new JSonSaver();
        }






        public void Save_dm()
        {
            _jsonSaver.Save_(_saveData);
        }

        public void Load_dm()
        {
            _jsonSaver.Load_(_saveData);
        }






//-------------------Options Data-----------------------------------


        public float MasterVolume
        {
            get { return _saveData.volume_master; }
            set { _saveData.volume_master = value; }
        }

        public float MusicVolume
        {
            get { return _saveData.volume_music; }
            set { _saveData.volume_music = value; }
        }

        public float SfxVolume
        {
            get { return _saveData.volume_sfx; }
            set { _saveData.volume_sfx = value; }
        }

        public string PlayerName
        {
            get { return _saveData.playerName; }
            set { _saveData.playerName = value; }
        }


    }

}