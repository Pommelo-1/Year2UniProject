﻿using Assets.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface
{
    public interface IBinManager
    {
        void DisplayPrefabListBin();
        void DisplayActiveListBin();

        void AddPrefabList(PrefabList prefabList);
        void AddActiveList(PrefabList prefabList);
    }
}
