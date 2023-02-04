using System.Linq;
using DialogueSystem;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryRef : MonoBehaviour
    {
        [SerializeField] private DialogueHandler handler;
        [SerializeField] private string keyFromStore;
        [SerializeField] private InventoryHandler inventoryHandler;

        public void Load()
        {
            handler.objectSequences = inventoryHandler.Inventory
                .First(x => x.Name == keyFromStore).Dialogue;
            handler.usingObjects = true;
            handler.LoadSequence(0);
        }
    }
}