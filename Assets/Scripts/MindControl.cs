using System;
using System.Collections;
using System.Collections.Generic;
using SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MindControl : MonoBehaviour
{
    [SerializeField] private Button blueZone;
    [SerializeField] private Button redZone;
    [SerializeField] private Button greenZone;
    [SerializeField] private Button yellowZone;
    [SerializeField] private Button violetZone;
    public string person;
    public int Limits;

    private void Start()
    {
        Limits = 3 - SaveSystemHandler.Instance.GetVisitedCount(person);
        if (Limits == 0)
        {
            SceneManager.LoadScene("MainScene");
        }
        blueZone.interactable = !SaveSystemHandler.Instance.GetVisitedIndex(person, 0);
        redZone.interactable = !SaveSystemHandler.Instance.GetVisitedIndex(person, 1);
        greenZone.interactable = !SaveSystemHandler.Instance.GetVisitedIndex(person, 2);
        yellowZone.interactable = !SaveSystemHandler.Instance.GetVisitedIndex(person, 3);
        violetZone.interactable = !SaveSystemHandler.Instance.GetVisitedIndex(person, 4);
    }

    public void OnClick(int index)
    {
        Limits--;
        SaveSystemHandler.Instance.ChangeVisited(person, index, true);
    }
}
