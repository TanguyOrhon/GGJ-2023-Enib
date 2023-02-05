using System;
using System.Collections;
using System.Collections.Generic;
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

        public void OnClick(int index)
        {
            Counter++;
            uiPart.SetActive(false);
            dialogueHandler.LoadAlter(doublons[index], () => { Check(); });
        }

        public void Check()
        {
            if (Counter == 3) prochain.gameObject.SetActive(true);
            else uiPart.SetActive(true);
        }
    }
}