using System.Collections;
using System.Collections.Generic;
using SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMindVisit : MonoBehaviour
{
    
    void Start()
    {
        var tmp = SaveSystemHandler.Instance.GetVisitedCount("gwenn");
        var tmp1 = SaveSystemHandler.Instance.GetVisitedCount("maya");
        var tmp2 = SaveSystemHandler.Instance.GetVisitedCount("tim");
        if (tmp == 3 && tmp1 == 3 && tmp2 == 3) SceneManager.LoadScene("ChooseInnocentScene");
    }
}
