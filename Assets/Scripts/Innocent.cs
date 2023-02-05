using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Innocent : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> caracter = new List<string>();
    public TextMeshProUGUI text;
    private Button maya;
    private Button gwenn;
    private Button tim;
    private Button oui;
    private Button non;
    private string currentPerso;
    private bool test = false;

    public void Awake()
    {
        maya = GameObject.FindGameObjectWithTag("Maya").GetComponent<Button>();
        tim = GameObject.FindGameObjectWithTag("Tim").GetComponent<Button>();
        gwenn = GameObject.FindGameObjectWithTag("Gwenn").GetComponent<Button>();
        oui = GameObject.FindGameObjectWithTag("Oui").GetComponent<Button>();
        non = GameObject.FindGameObjectWithTag("Non").GetComponent<Button>();
    }
    void Start()
    {
        caracter.Add("Tim");
        caracter.Add("Gwenn");
        caracter.Add("Maya");
        Choose();
    }

    void Choose()
    {
        maya.gameObject.SetActive(true);
        tim.gameObject.SetActive(true);
        gwenn.gameObject.SetActive(true);
        oui.gameObject.SetActive(false);
        non.gameObject.SetActive(false);
        text.text = "Qui est innocent ?";
    }
    // Update is called once per frame
    public void OnClick(string perso)
    {
        if (test == false)
        {
            text.text = "Etes-vous certain que " + perso + " est innocent ?";
            currentPerso = perso;
            maya.gameObject.SetActive(false);
            tim.gameObject.SetActive(false);
            gwenn.gameObject.SetActive(false);
            oui.gameObject.SetActive(true);
            non.gameObject.SetActive(true);
        }
    }
    
    public void OnClickNo()
    {
        Choose();
    }
    
    public void OnClickPerso(string perso)
    {
        if (test == true)
        {
            caracter.Remove(perso);
            PlayerPrefs.SetString("perso", caracter[0]);
            SceneManager.LoadScene("Interrogatoire2Sus" + perso + "Scene");
        }
        
    }
    
    public void OnClickYes()
    {
        test = true;
        maya.gameObject.SetActive(true);
        tim.gameObject.SetActive(true);
        gwenn.gameObject.SetActive(true);
        oui.gameObject.SetActive(false);
        non.gameObject.SetActive(false);
        if (currentPerso == "Maya")
        {
            maya.gameObject.SetActive(false);
        }else if (currentPerso == "Tim")
        {
            tim.gameObject.SetActive(false);
        }
        else if(currentPerso == "Gwenn")
        {
            gwenn.gameObject.SetActive(false);
        }
        text.text = "Qui voulez-vous interroger en premier ?";
        caracter.Remove(currentPerso);
        PlayerPrefs.SetString("perso1", caracter[0]);
        PlayerPrefs.SetString("perso2", caracter[1]);
    }
}
