using System;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [Serializable]
    public class DialogueData
    {
        public string Speaker;
        [TextArea]
        public List<string> Sentences;
    }
    
    [CreateAssetMenu(fileName = "Dialogue01", menuName = "CUSTOM/Dialogue", order = 0)]
    public class DialogueSequence : ScriptableObject
    {
        [SerializeField] private List<DialogueData> dialogueList;

        public List<DialogueData> DialogueList => dialogueList;
    }
}
