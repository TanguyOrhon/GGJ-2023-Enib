using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public int Counter;
        public string nextSceneName;

        public void OnClick(int index)
        {
            Counter++;
            uiPart.SetActive(false);
            dialogueHandler.LoadAlter(doublons[index], () => { Check(); });
        }

        public void Check()
        {
            if (Counter == 3) SceneManager.LoadScene(nextSceneName);
            else uiPart.SetActive(true);
        }
    }
}