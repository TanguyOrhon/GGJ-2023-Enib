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
        currentPerso = perso;
        text.text = "Etes-vous certain que " + perso + " est innocent ?";

        maya.gameObject.SetActive(false);
        tim.gameObject.SetActive(false);
        gwenn.gameObject.SetActive(false);
        oui.gameObject.SetActive(true);
        non.gameObject.SetActive(true);
    }
    
    public void OnClickNo()
    {
        Choose();
    }
    
    public void OnClickYes()
    {
        caracter.Remove(currentPerso);
        PlayerPrefs.SetString("perso1", caracter[0]);
        PlayerPrefs.SetString("perso2", caracter[1]);
        SceneManager.LoadScene("Interrogatoire2Sus" + caracter[0] + "Scene");
    }
}
