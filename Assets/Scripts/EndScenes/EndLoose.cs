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
    public Image blackscreen;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAnim());
        
    }

    // Update is called once per frame
    public void OnClick()
    {
        SceneManager.LoadScene("Main_Menu_2");
    }
    
    IEnumerator StartAnim()
    {
        yield return new WaitForSecondsRealtime(15);
        blackscreen.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        yield return text_button.DOFade(1, 3);
    }
}
