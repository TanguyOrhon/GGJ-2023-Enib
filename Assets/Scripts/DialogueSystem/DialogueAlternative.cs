using System;
using System.Collections;
using System.Collections.Generic;
using SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DialogueSystem
{
    [Serializable]
    public class Alter
    {
        public DialogueSequence normal;
        public DialogueSequence alter;
        public bool asked;
    }
    
    public class DialogueAlternative : MonoBehaviour
    {
        public List<Alter> doublons;
        [SerializeField] private DialogueHandler dialogueHandler;
        [SerializeField] private GameObject uiPart;
        [SerializeField] private Button prochain;

        public int Counter;
        public string perso;

        public void OnClick(int index)
        {
            Counter++;
            uiPart.SetActive(false);
            if (index == 0 && !string.IsNullOrEmpty(SaveSystemHandler.Instance.coupable))
            {
                dialogueHandler.LoadAlter(doublons[index], () => { Check(); }, true);
                return;
            }
            if (index == 0) SaveSystemHandler.Instance.coupable = perso;
            
            dialogueHandler.LoadAlter(doublons[index], () => { Check(); }, false);
        }

        public void Check()
        {
            if (Counter == 3) prochain.gameObject.SetActive(true);
            else uiPart.SetActive(true);
        }
    }
}