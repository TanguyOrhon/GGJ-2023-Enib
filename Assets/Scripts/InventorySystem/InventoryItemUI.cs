using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SaveSystem;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryItemUI : MonoBehaviour
    {
        public string keyFromStore;
        public InventoryHandler inventoryHandler;

        public void OnShow()
        {
            var b = SaveSystemHandler.Instance.GetDataInventory(inventoryHandler, keyFromStore);
            gameObject.SetActive(!b);
        }

        public void OnClick()
        {
            var dialogue = inventoryHandler.Inventory.First(x => x.Name == keyFromStore).Dialogue;
            InventoryUI.Instance.dialogueHandler.LoadSpecific(dialogue);
        }
    }
}