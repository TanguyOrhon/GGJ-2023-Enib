using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DialogueSystem;
using SaveSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        public static InventoryUI Instance { get; private set; }

        public DialogueHandler dialogueHandler;

        [SerializeField] private GameObject ParentObject;
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
            if (Instance != null && Instance != this) 
            {
                Destroy(ParentObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(ParentObject);
            }
            
            _inventoryActive = false;
            inventoryInstance.SetActive(_inventoryActive);
            
            InitInventory(SaveSystemHandler.Instance.forGwenn);
            InitInventory(SaveSystemHandler.Instance.forMaya);
            InitInventory(SaveSystemHandler.Instance.forTim);
        }

        private void InitInventory(InventoryHandler ih)
        {
            foreach (var inventoryItemData in ih.Inventory)
            {
                var obj = Instantiate(itemPrefab, inventoryContent.transform);
                var comp = obj.GetComponent<InventoryItemUI>();
                obj.name = inventoryItemData.Name;
                obj.GetComponentInChildren<RawImage>().texture = inventoryItemData.Image;
                comp.keyFromStore = inventoryItemData.Name;
                comp.inventoryHandler = ih;
                comp.OnShow();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                ShowHideInventory();
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
                item.GetComponent<InventoryItemUI>().OnShow();
            }
        }
    }
}
