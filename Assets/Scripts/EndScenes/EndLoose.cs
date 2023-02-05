using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLoose : MonoBehaviour
{

    public TextMeshProUGUI text_button;
    
    // Start is called before the first frame update
    void Start()
    {
        text_button.DOFade(1, 3);
    }

    // Update is called once per frame
    public void OnClick()
    {
        SceneManager.LoadScene("Main_Menu_2");
    }
}
