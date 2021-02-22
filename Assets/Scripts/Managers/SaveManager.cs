using Assets.Data;
using Assets.Scipts.Interfaces;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
/// <summary>
/// Save Manager used for saving/loading and deleting data
/// </summary>
namespace Assets.Scripts.Managers
{
    public class SaveManager : ISaveManager
    {
        private readonly bool debug = false;
        public SaveManager(bool debug = false)
        {
            this.debug = debug;
        }

        public void SaveData(SavedData savedData)
        {
            if (debug)
            {
                Debug.Log("Starting saving data...");
            }

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + Static.File_Save_Location);

            bf.Serialize(file, savedData);
            file.Close();

            if (debug)
            {
                Debug.Log("Finished saving data.");
            }
        }

        public SavedData LoadData()
        {
            if (debug)
            {
                Debug.Log("Starting loading data...");
            }

            if (File.Exists(Application.persistentDataPath + Static.File_Save_Location))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + Static.File_Save_Location, FileMode.Open);

                SavedData data = (SavedData)bf.Deserialize(file);
                file.Close();

                if (debug)
                {
                    Debug.Log("Data found and loaded.");
                }

                return data;
            }
            else
            {
                if (debug)
                {
                    Debug.Log("Data not found!");
                }
                return null;
            }
        }

        public void DeleteData()
        {
            if (debug)
            {
                Debug.Log("Trying to delete the data");
            }
            if (File.Exists(Application.persistentDataPath + Static.File_Save_Location))
            {
                File.Delete(Application.persistentDataPath + Static.File_Save_Location);

                if (debug)
                {
                    Debug.Log("Data was deleted.");
                }

                if (File.Exists(Application.persistentDataPath + Static.File_Save_Location))
                {
                    Debug.LogWarning("File still exists (¬_¬ )");
                }

            }
            else
            {
                if (debug)
                {
                    Debug.Log("No save data to delete found!");
                }
            }
        }
    }
}