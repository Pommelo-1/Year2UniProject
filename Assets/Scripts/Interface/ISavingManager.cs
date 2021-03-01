using Assets.Data;
using Assets.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface
{
    public interface ISavingManager
    {
        SavedData LoadData(string path_name);
        void SaveData(SavedData data, string path_name);
        void DeleteData(string path_name);
    }
}
