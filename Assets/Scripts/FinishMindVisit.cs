using System.Collections;
using System.Collections.Generic;
using SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMindVisit : MonoBehaviour
{
    [SerializeField] private Button gwennButton;
    [SerializeField] private Button mayaButton;
    [SerializeField] private Button timButton;
    
    void Start()
    {
        var tmp = SaveSystemHandler.Instance.GetVisitedCount("gwenn");
        var tmp1 = SaveSystemHandler.Instance.GetVisitedCount("maya");
        var tmp2 = SaveSystemHandler.Instance.GetVisitedCount("tim");
        gwennButton.interactable = tmp != 3;
        mayaButton.interactable = tmp1 != 3;
        timButton.interactable = tmp2 != 3;
        if (tmp == 3 && tmp1 == 3 && tmp2 == 3) SceneManager.LoadScene("ChooseInnocentScene");
    }
}
