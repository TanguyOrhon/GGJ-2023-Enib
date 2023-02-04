using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventoryHandler inventoryHandler;
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private GameObject inventoryInstance;
        [SerializeField] private GameObject inventoryContent;
        [SerializeField] private GameObject itemPrefab;
        [Header("Text")] 
        [SerializeField] private string textOnHide;
        [SerializeField] private string textOnShow;
        

        private bool _inventoryActive;

        private void Awake()
        {
            _inventoryActive = false;
            foreach (var inventoryItemData in inventoryHandler.Inventory)
            {
                var obj = Instantiate(itemPrefab, inventoryContent.transform);
                obj.name = inventoryItemData.Name;
                obj.GetComponentInChildren<RawImage>().texture = inventoryItemData.Image;
                obj.SetActive(!inventoryItemData.Hide);
            }
        }

        public void ShowHideInventory()
        {
            _inventoryActive = !_inventoryActive;
            inventoryInstance.SetActive(_inventoryActive);
            buttonText.text = _inventoryActive ? textOnShow : textOnHide;
            if (_inventoryActive) OnShowInventory();
        }

        private void OnShowInventory()
        {
            foreach (Transform item in inventoryContent.transform)
            {
                var obj = inventoryHandler.Inventory.Where(x => x.Name == item.name).ToList();
                if (obj.Count == 1)
                {
                    item.gameObject.SetActive(!obj[0].Hide);
                }
            }
        }
    }
}
