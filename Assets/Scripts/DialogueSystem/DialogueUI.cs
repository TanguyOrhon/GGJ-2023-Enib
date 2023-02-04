using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameDisplay;
        [SerializeField] private TextMeshProUGUI textDisplay;

        public void StopAllTypings()
        {
            StopAllCoroutines();
        }

        public void UpdateBox(string _name, string text)
        {
            nameDisplay.text = _name;
            StartCoroutine(TypingText(text, 0.025f));
        }

        private IEnumerator TypingText(string text, float delay)
        {
            textDisplay.text = "";
            foreach (var c in text)
            {
                textDisplay.text += c;
                yield return new WaitForSecondsRealtime(delay);
            }
        }

        public void HideDialogue()
        {
            gameObject.SetActive(false);
        }
        
        public void ShowDialogue()
        {
            gameObject.SetActive(true);
        }
    }
}
