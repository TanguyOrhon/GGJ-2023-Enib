using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class End : MonoBehaviour
{
	
    // Update is called once per frame
    void Start()
    {
        GetComponent<RectTransform>().DOAnchorPos3DY(0, 4);
    }
}
