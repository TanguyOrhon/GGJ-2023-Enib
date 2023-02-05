using System;
using System.Linq;
using DG.Tweening;
using DialogueSystem;
using SaveSystem;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventoryRef : MonoBehaviour
    {
        [SerializeField] private DialogueHandler handler;
        [SerializeField] private string keyFromStore;
        [SerializeField] private InventoryHandler inventoryHandler;

        private void Start()
        {
            var b = SaveSystemHandler.Instance.GetDataInventory(inventoryHandler, keyFromStore);
            if (!b) GetComponent<Image>().DOFade(0, 0.01f);
        }

        public void Load()
        {
            var tmp = inventoryHandler.Inventory
                .First(x => x.Name == keyFromStore);
            handler.objectSequences = tmp.Dialogue;
            handler.usingObjects = true;
            handler.LoadSequence(0);
            
            SaveSystemHandler.Instance.ChangeDataInventory(inventoryHandler, keyFromStore, false);
        }
    }
}