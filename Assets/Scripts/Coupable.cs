using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Coupable : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> caracter = new List<string>();
    public TextMeshProUGUI text;
    private Button maya;
    private Button gwenn;
    private Button tim;
    private string currentPerso;
    private bool test = false;

    public void Awake()
    {
        maya = GameObject.FindGameObjectWithTag("Maya2").GetComponent<Button>();
        tim = GameObject.FindGameObjectWithTag("Tim2").GetComponent<Button>();
        gwenn = GameObject.FindGameObjectWithTag("Gwenn2").GetComponent<Button>();
        
    }

    public void OnClickPerso(string perso)
    {
        SceneManager.LoadScene("End_" + perso + "Scene");
    }

    public void Start()
    {
        maya.gameObject.SetActive(false);
        tim.gameObject.SetActive(false);
        gwenn.gameObject.SetActive(false);

        if (PlayerPrefs.GetString("perso1") == "Maya")
        {
            maya.gameObject.SetActive(true);
        }else if (PlayerPrefs.GetString("perso1") == "Tim")
        {
            tim.gameObject.SetActive(true);
        }
        else if(PlayerPrefs.GetString("perso1") == "Gwenn")
        {
            gwenn.gameObject.SetActive(true);
        }
        
        if (PlayerPrefs.GetString("perso2") == "Maya")
        {
            maya.gameObject.SetActive(true);
        }else if (PlayerPrefs.GetString("perso2") == "Tim")
        {
            tim.gameObject.SetActive(true);
        }
        else if(PlayerPrefs.GetString("perso2") == "Gwenn")
        {
            gwenn.gameObject.SetActive(true);
        }
        
        text.text = "Qui est le coupable ?";
    }
}
