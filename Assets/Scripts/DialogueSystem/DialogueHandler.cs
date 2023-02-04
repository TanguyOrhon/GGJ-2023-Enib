using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHandler : MonoBehaviour
    {
        [SerializeField] private DialogueUI dialogueUI;
        [SerializeField] private List<DialogueSequence> sequences;

        private int _currentSequenceIndex; private DialogueSequence _currentSequence;
        private DialogueData _currentSpeaker; private int _currentSentenceIndex;
        private int _currentSubsentenceIndex;

        private void Awake()
        {
            dialogueUI.HideDialogue();
        }

        public void LoadSequence()
        {
            _currentSequenceIndex = -1;
            _currentSequence = null;
            _currentSpeaker = null;
            _currentSentenceIndex = -1;
            _currentSubsentenceIndex = -1;
            dialogueUI.ShowDialogue();
            NextSequence(); // the first by default
        }

        private void NextSentence()
        {
            _currentSentenceIndex++;
            if (_currentSequence == null || _currentSentenceIndex >= _currentSequence.DialogueList.Count)
            {
                _currentSentenceIndex = -1;
                // On finished
                NextSequence();
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

        private void NextSequence()
        {
            _currentSequenceIndex++;
            if (_currentSequenceIndex >= sequences.Count)
            {
                _currentSequenceIndex = -1;
                // On finished
                dialogueUI.HideDialogue();
                print("SEQUENCES END");
                return;
            }
            _currentSequence = sequences[_currentSequenceIndex];
            NextSentence();
        }

        public void NextButtonAction()
        {
            NextSubSentence();
        }
    }
}