using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DialogueSystem
{
    public class DialogueHandler : MonoBehaviour
    {
        [SerializeField] private DialogueUI dialogueUI;
        [SerializeField] private List<DialogueSequence> sequences;

        public bool usingObjects;
        public DialogueSequence objectSequences;

        private int _currentSequenceIndex;
        private DialogueSequence _currentSequence;
        private DialogueData _currentSpeaker;
        private int _currentSentenceIndex;
        private int _currentSubsentenceIndex;
        
        [SerializeField] private Button prochain;

        private Action onEndLocal;

        private void Awake()
        {
            dialogueUI.HideDialogue();
        }

        public void LoadSequence(int index)
        {
            if (usingObjects)
            {
                _currentSequence = objectSequences;
            }
            else
            {
                _currentSequence = sequences[_currentSequenceIndex];
            }

            _currentSequenceIndex = index;
            _currentSpeaker = null;
            _currentSentenceIndex = -1;
            _currentSubsentenceIndex = -1;
            dialogueUI.ShowDialogue();
            NextSentence();
        }

        public void LoadSpecific(DialogueSequence ds)
        {
            _currentSequence = ds;
            _currentSpeaker = null;
            _currentSentenceIndex = -1;
            _currentSubsentenceIndex = -1;
            dialogueUI.ShowDialogue();
            NextSentence();
        }
        
        public void LoadSpecific2(DialogueSequence ds)
        {
            _currentSequence = ds;
            _currentSpeaker = null;
            _currentSentenceIndex = -1;
            _currentSubsentenceIndex = -1;
            dialogueUI.ShowDialogue();
            NextSentence();
        }

        public void LoadAlter(Alter alter, Action onEnd)
        {
            onEndLocal = onEnd;
            LoadSpecific2(alter.normal);
        }

        private void NextSentence()
        {
            _currentSentenceIndex++;
            if (_currentSequence == null || _currentSentenceIndex >= _currentSequence.DialogueList.Count)
            {
                _currentSentenceIndex = -1;
                // On finished
                dialogueUI.HideDialogue();
                print("DIALOGUE END");
                onEndLocal?.Invoke();
                onEndLocal = null;
                if(prochain != null) prochain.gameObject.SetActive(true);
                return;
            }

            _currentSpeaker = _currentSequence.DialogueList[_currentSentenceIndex];
            NextSubSentence();
        }

        private void NextSubSentence()
        {
            _currentSubsentenceIndex++;
            if (_currentSpeaker == null || _currentSubsentenceIndex >= _currentSpeaker.Sentences.Count)
            {
                _currentSubsentenceIndex = -1;
                // On finished
                NextSentence();
                return;
            }

            var s = _currentSpeaker.Sentences[_currentSubsentenceIndex];
            dialogueUI.StopAllTypings();
            dialogueUI.UpdateBox(_currentSpeaker.Speaker, s);
        }

        public void NextButtonAction()
        {
            NextSubSentence();
        }

        public void OnClick()
        {
            if (SceneManager.GetActiveScene().name != "Interrogatoire2Sus" + PlayerPrefs.GetString("perso2") + "Scene")
            {
                SceneManager.LoadScene("Interrogatoire2Sus" + PlayerPrefs.GetString("perso2") + "Scene");
            }
            else
            {
                SceneManager.LoadScene("Main_Menu_2");
            }
        }
    }
}