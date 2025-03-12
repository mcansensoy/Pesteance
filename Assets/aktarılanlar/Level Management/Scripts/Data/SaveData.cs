using System;
using System.Collections;
using System.Collections.Generic;


namespace LevelManagement.Data
{
    [Serializable]
    public class SaveData
    {
        public string playerName;
        private readonly string default_PlayerName = "Player";

        public float volume_master;
        public float volume_music;
        public float volume_sfx;

        public string hashValue;

        public SaveData()
        {
            playerName = default_PlayerName;
            volume_master = 0f;
            volume_music = 0f;
            volume_sfx = 0f;
            hashValue = String.Empty;
        }
    } 
}
