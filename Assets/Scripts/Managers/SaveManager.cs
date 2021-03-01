using Assets.Data;
using Assets.Scripts.Interface;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
/// <summary>
/// Save Manager used for saving/loading and deleting data
/// </summary>
namespace Assets.Scripts.Managers
{
    public class SaveManager : ISavingManager
    {
        private readonly bool debug = false;
        public SaveManager(bool debug = false)
        {
            this.debug = debug;
        }

        public void SaveData(SavedData savedData, string path_name)
        {
            if (debug)
            {
                Debug.Log("Starting saving data...");
            }

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + path_name);

            bf.Serialize(file, savedData);
            file.Close();

            if (debug)
            {
                Debug.Log("Finished saving data.");
            }
        }

        public SavedData LoadData(string path_name)
        {
            if (debug)
            {
                Debug.Log("Starting loading data...");
            }

            if (File.Exists(Application.persistentDataPath + path_name))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + path_name, FileMode.Open);

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

        public void DeleteData(string path_name)
        {
            if (debug)
            {
                Debug.Log("Trying to delete the data");
            }
            if (File.Exists(Application.persistentDataPath + path_name))
            {
                File.Delete(Application.persistentDataPath + path_name);

                if (debug)
                {
                    Debug.Log("Data was deleted.");
                }

                if (File.Exists(Application.persistentDataPath + path_name))
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