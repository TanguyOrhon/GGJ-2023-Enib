using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Innocent : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> caracter = new List<string>();
    public TextMeshProUGUI text;
    void Start()
    {
        caracter.Add("Tim");
        caracter.Add("Gwenn");
        caracter.Add("Maya");
        text.text = "Qui est innocent ?";
    }

    // Update is called once per frame
    public void OnClick()
    {
        string perso = gameObject.name;
        text.text = "Etes-vous certain que " + perso + " est innocent ?";
        Button maya = GameObject.FindGameObjectWithTag("Maya").GetComponent<Button>();
        Button tim = GameObject.FindGameObjectWithTag("Tim").GetComponent<Button>();
        Button gwenn = GameObject.FindGameObjectWithTag("Gwenn").GetComponent<Button>();
        
        maya.gameObject.SetActive(false);
        tim.gameObject.SetActive(false);
        gwenn.gameObject.SetActive(false);
    }
}
