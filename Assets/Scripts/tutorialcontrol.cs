using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class tutorialcontrol : MonoBehaviour
{

    System.IO.StreamReader file;
    public Text mytext;
    public GameObject UIpanel;

    IEnumerator print(string introtext){
        string temp = "";
        foreach (char letter in introtext){
            
            temp = temp + letter;
            mytext.text = temp;

            yield return new WaitForSeconds(0.1f);
        }
        
    }

    public void executeprint(){
        
     
        StartCoroutine(print(file.ReadLine()));
        
        
       

    }
    
    // Start is called before the first frame update
    void Start()
    {
        file = new System.IO.StreamReader (@"/Users/earlbalageo/Documents/GitHub/Digg/Diggums-Drones/Assets/Scripts/tutorial.txt");
        executeprint();
        //StartCoroutine(print("hello world"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
