using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(StartAnim());
    }

    // Update is called once per frame
    IEnumerator StartAnim()
    {
        yield return GetComponent<RectTransform>()
            .DOAnchorPos3DY(0, 4).WaitForCompletion(true);
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("Main_Menu_2");
    }
}
