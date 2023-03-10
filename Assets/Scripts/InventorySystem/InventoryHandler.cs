using System;
using System.Collections;
using System.Collections.Generic;
using DialogueSystem;
using UnityEngine;

namespace InventorySystem
{
    [Serializable]
    public class InventoryItemData
    {
        public string Name;
        public Texture2D Image; // or Image
        public bool Hide;
        public DialogueSequence Dialogue;
    }
    
    [CreateAssetMenu(fileName = "Inventory01", menuName = "CUSTOM/Inventory")]
    public class InventoryHandler : ScriptableObject
    {
        [SerializeField] private List<InventoryItemData> inventory;

        public List<InventoryItemData> Inventory => inventory;
    }
}
