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
        SaveData LoadData();
        void Save(SaveData data);
        void DeleteData();
    }
}
