using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpartaDungeon.Scene;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpartaDungeon.Manager
{
    internal class FileManager
    {
        public static string path = "C:\\UnityProjects\\SpartaDungeon\\SpartaDungeon\\SpartaDungeon\\Json";
        public static void SaveData()
        { 
            string userData = JsonConvert.SerializeObject(GameManager.user);
            File.WriteAllText(path + "\\UserData.json", userData);

            string inventoryData = JsonConvert.SerializeObject(Inventory.GetInventory());
            File.WriteAllText(path + "\\UserInventoryData.json", inventoryData);

            string storeData = JsonConvert.SerializeObject(GameManager.items);
            File.WriteAllText(path + "\\StoreItemData.json", storeData);
        }

        public static void LoadData()
        {
            // 유저 데이터가 없을 때 -> 세이브 데이터가 없을 때
            if (!File.Exists(path + "\\UserData.json"))
            {
                GameManager.Init();
                SaveData();
                return;
            }
            else
            {
                string userLData = File.ReadAllText(path + "\\UserData.json");
                User userLoadData = JsonConvert.DeserializeObject<User>(userLData);

                string inventoryLData = File.ReadAllText(path + "\\UserInventoryData.json");
                List<Item> inventoryLoadData = JsonConvert.DeserializeObject<List<Item>>(inventoryLData);

                string storeLData = File.ReadAllText(path + "\\StoreItemData.json");
                Item[] storeLoadData = JsonConvert.DeserializeObject<Item[]>(storeLData);

                Console.WriteLine(userLoadData);
            }
        }
    }
}
