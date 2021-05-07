using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LitJson;

namespace AssemblyCSharp.Pk9rGetData
{
    public class Pk9rController
    {
        public static bool IsSaveDataMap;
        public static bool IsSaveDataItem;
        public static bool IsSaveDataSkill;

        public static void UpdateData()
        {
            Service.gI().updateMap();
            Service.gI().updateItem();
            Service.gI().updateSkill();
        }

        public static void SaveDataMap()
        {
            Dictionary<int, string> d = new();
            for (int i = 0; i < TileMap.mapNames.Length; i++)
                d.Add(i, TileMap.mapNames[i]);
            File.WriteAllText("DataMap.json", JsonMapper.ToJson(d));
            File.WriteAllText("DataNpc.json", JsonMapper.ToJson(Npc.arrNpcTemplate));
            File.WriteAllText("DataMob.json", JsonMapper.ToJson(Mob.arrMobTemplate));
            IsSaveDataMap = true;
        }

        public static void SaveDataItem()
        {
            File.WriteAllText("DataItem.json", JsonMapper.ToJson(ItemTemplates.itemTemplates.h));
            IsSaveDataItem = true;
        }

        public static void SaveDataSkill()
        {
            File.WriteAllText("DataSkill.json", JsonMapper.ToJson(GameScr.nClasss));
            IsSaveDataSkill = true;
        }

        public static void CheckQuitGame()
        {
            if (IsSaveDataMap && IsSaveDataItem && IsSaveDataSkill)
            {
                Main.exit();
            }    
        }
    }
}
