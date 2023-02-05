using System;
using System.Collections.Generic;
using System.Linq;
using InventorySystem;
using UnityEngine;

namespace SaveSystem
{
    [Serializable]
    public class SavePlayerData
    {
        public Dictionary<string, bool> inv1; // Gwenn
        public Dictionary<string, bool> inv2; // Maya
        public Dictionary<string, bool> inv3; // Tim

        public List<bool> visitedForGwenn;
        public List<bool> visitedForMaya;
        public List<bool> visitedForTim;

        public SavePlayerData()
        {
            inv1 = new Dictionary<string, bool>();
            inv2 = new Dictionary<string, bool>();
            inv3 = new Dictionary<string, bool>();
            visitedForGwenn = new List<bool>();
            visitedForMaya = new List<bool>();
            visitedForTim = new List<bool>();
        }

        public void Init(InventoryHandler ih1, InventoryHandler ih2, InventoryHandler ih3)
        {
            foreach (var i1 in ih1.Inventory)
            {
                inv1.Add(i1.Name, i1.Hide);
            }
            foreach (var i2 in ih2.Inventory)
            {
                inv2.Add(i2.Name, i2.Hide);
            }
            foreach (var i3 in ih3.Inventory)
            {
                inv3.Add(i3.Name, i3.Hide);
            }
        }
    }
    
    public class SaveSystemHandler : MonoBehaviour
    {
        public static SaveSystemHandler Instance { get; private set; }

        public InventoryHandler forGwenn;
        public InventoryHandler forMaya;
        public InventoryHandler forTim;

        private SavePlayerData _playerData;

        public string coupable;

        private void Awake()
        {
            if (Instance != null && Instance != this) 
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            
            _playerData = new SavePlayerData();
            _playerData.Init(forGwenn, forMaya, forTim);
            coupable = "";
            InitMind();
        }

        public void InitMind()
        {
            _playerData.visitedForGwenn.AddRange(new []{ false, false, false, false, false });
            _playerData.visitedForMaya.AddRange(new []{ false, false, false, false, false });
            _playerData.visitedForTim.AddRange(new []{ false, false, false, false, false });
        }

        public int GetVisitedCount(string person)
        {
            if (person.ToLower().Contains("gwenn"))
            {
                return _playerData.visitedForGwenn.Count(x => x);
            }
            if (person.ToLower().Contains("maya"))
            {
                return _playerData.visitedForMaya.Count(x => x);
            }
            if (person.ToLower().Contains("tim"))
            {
                return _playerData.visitedForTim.Count(x => x);
            }

            return -1;
        }

        public void ChangeVisited(string person, int index, bool val)
        {
            if (person.ToLower().Contains("gwenn"))
            {
                _playerData.visitedForGwenn[index] = val;
            }
            else if (person.ToLower().Contains("maya"))
            {
                _playerData.visitedForMaya[index] = val;
            }
            else if (person.ToLower().Contains("tim"))
            {
                _playerData.visitedForTim[index] = val;
            }
        }

        public bool GetVisitedIndex(string person, int index)
        {
            if (person.ToLower().Contains("gwenn"))
            {
                return _playerData.visitedForGwenn[index];
            }
            if (person.ToLower().Contains("maya"))
            {
                return _playerData.visitedForMaya[index];
            }
            if (person.ToLower().Contains("tim"))
            {
                return _playerData.visitedForTim[index];
            }

            return false;
        }

        public void ChangeDataInventory(InventoryHandler ih, string key, bool val)
        {
            if (ih.name.ToLower().Contains("gwenn"))
            {
                _playerData.inv1[key] = val;
            }
            else if (ih.name.ToLower().Contains("maya"))
            {
                _playerData.inv2[key] = val;
            }
            else if (ih.name.ToLower().Contains("tim"))
            {
                _playerData.inv3[key] = val;
            }
        }

        public bool GetDataInventory(InventoryHandler ih, string key)
        {
            if (ih.name.ToLower().Contains("gwenn"))
            {
                return _playerData.inv1[key];
            }
            if (ih.name.ToLower().Contains("maya"))
            {
                return _playerData.inv2[key];
            }
            if (ih.name.ToLower().Contains("tim"))
            {
                return _playerData.inv3[key];
            }

            return true;
        }
    }
}