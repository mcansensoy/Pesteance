using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using UnityEngine;

namespace LevelManagement.Data
{
    public class JSonSaver
    {
        private static readonly string _filename = "saveData1.sav";


        public static string Get_SaveFile_name()
        {
            return Application.persistentDataPath + "/" + _filename;
        }







        public void Save_(SaveData data_js_s)
        {

            data_js_s.hashValue = String.Empty;


            string json_s = JsonUtility.ToJson(data_js_s);

            data_js_s.hashValue = Get_SHA256(json_s);
            json_s = JsonUtility.ToJson(data_js_s);


            string save_Filename = Get_SaveFile_name();

            FileStream fileStream_ = new FileStream(save_Filename, FileMode.Create);


            using (StreamWriter writer_ =new StreamWriter(fileStream_))
            {
                writer_.Write(json_s);
            }
        }







        public bool Load_(SaveData data_js_load)
        {
            string load_Filename = Get_SaveFile_name();

            if (File.Exists(load_Filename))
            {
                using (StreamReader reader_ = new StreamReader(load_Filename))
                {
                    string json_load = reader_.ReadToEnd();

                    if (CheckData(json_load))
                    {
                        JsonUtility.FromJsonOverwrite(json_load, data_js_load);
                    }
                    else
                    {
                        Debug.LogWarning("you've been hacked.  Invalid Hash");
                    }

                }
                return true;
            }
            return false;
        }


        private bool CheckData(string json_check)
        {
            SaveData temp_SaveData = new SaveData();
            JsonUtility.FromJsonOverwrite(json_check, temp_SaveData);

            string old_Hash = temp_SaveData.hashValue;
            temp_SaveData.hashValue = String.Empty;

            string temp_Json = JsonUtility.ToJson(temp_SaveData);
            string new_Hash = Get_SHA256(temp_Json);

            return (old_Hash == new_Hash);
        }




        public void Delete_()
        {
            File.Delete(Get_SaveFile_name());
        }











//-----------------------------Hash Cryptography-----------------------------------------


        public string Get_HexString_fromHash(byte[] hash_js)
        {
            string hexString = String.Empty;

            foreach(byte b in hash_js)
            {
                hexString += b.ToString("x2");
            }
            return hexString;
        }



        private string Get_SHA256(string text_sha)
        {
            byte[] text_to_Bytes = Encoding.UTF8.GetBytes(text_sha);

            SHA256Managed my_SHA256 = new SHA256Managed();

            byte[] hash_Value = my_SHA256.ComputeHash(text_to_Bytes);


            return Get_HexString_fromHash(hash_Value);
        }



    } 
}
