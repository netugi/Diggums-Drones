﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class tutorialcontrol : MonoBehaviour
{

    public Text mytext;
    public GameObject UIpanel;
    public Button next;
    private string[] helpText;
    private int indexOfHelp;

    IEnumerator print(string[] introtext){
        string temp = "";
        foreach (char letter in introtext[indexOfHelp]){
            
            temp = temp + letter;
            mytext.text = temp;

            yield return new WaitForSeconds(0.1f);
        }

        next.gameObject.SetActive(true);
        
    }

    public void nextHelp(){
        
        next.gameObject.SetActive(false);
        executeprint();

        

        indexOfHelp++;
    }

    public void executeprint(){
        if(indexOfHelp != 5){
            StartCoroutine(print(helpText));
        }else
        {
            UIpanel.gameObject.SetActive(false);
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        indexOfHelp = 0;
        helpText = new string[]{"hello world","Your mama", "is Amazing","come together", "hey jude"};
        executeprint();
        indexOfHelp ++;
        //StartCoroutine(print("hello world"));
    }

}