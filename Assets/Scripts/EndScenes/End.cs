using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Image blackscreen;
    public bool test;
    private void Start()
    {
        StartCoroutine(StartAnim());
    }

    // Update is called once per frame
    IEnumerator StartAnim()
    {
        yield return new WaitForSecondsRealtime(15);
        blackscreen.gameObject.SetActive(false);
        if (test)
        {
            yield return GetComponent<RectTransform>()
                .DOAnchorPos3DY(0, 4).WaitForCompletion(true);
        }
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("Main_Menu_2");
    }
}
