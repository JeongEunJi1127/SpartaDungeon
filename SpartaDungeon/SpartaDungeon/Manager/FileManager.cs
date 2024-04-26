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
        //public static string path = 사용자의 SpartaDungeun > SpartaDungeun > SpartaDungeun > bin > Debug  > net 8.0 위치에 생성됨

        public static string path = AppDomain.CurrentDomain.BaseDirectory;
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
                GameManager.user = userLoadData;
                
                string inventoryLData = File.ReadAllText(path + "\\UserInventoryData.json");
                List<Item> inventoryLoadData = JsonConvert.DeserializeObject<List<Item>>(inventoryLData);
                if (Inventory.InventoryItems == null)
                {
                    Inventory.InventoryItems = new List<Item>(); // 리스트를 초기화
                }
                foreach (Item data in inventoryLoadData)
                {
                    Inventory.InventoryItems.Add(data);
                }

                string storeLData = File.ReadAllText(path + "\\StoreItemData.json");
                Item[] storeLoadData = JsonConvert.DeserializeObject<Item[]>(storeLData);
                if (GameManager.items == null)
                {
                    GameManager.items = new List<Item>(); // 리스트를 초기화
                }
                foreach (Item data in storeLoadData)
                {
                    GameManager.items.Add(data);
                }
            }
        }

        // Game Over 시 데이터 리셋 & LoadData()
        public static void ResetData()
        {
            File.Delete(path + "\\UserData.json");
            File.Delete(path + "\\UserInventoryData.json");
            File.Delete(path + "\\StoreItemData.json");
            LoadData();
        }
    }
}
