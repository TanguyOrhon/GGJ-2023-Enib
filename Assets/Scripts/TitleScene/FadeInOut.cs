using System;
using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class FadeInOut : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        while (true)
        {
            yield return _text.DOFade(0, 1).WaitForCompletion(true);
            yield return _text.DOFade(1, 1).WaitForCompletion(true);
        }
    }
}
