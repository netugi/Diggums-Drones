using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;

public class tutorialcontrol : MonoBehaviour
{

    public Text mytext;
    public GameObject UIpanel;
    public Button next;
    public string[] helpText;
    private int indexOfHelp;

    public void print(string[] introtext){
        /*string temp = "";
        foreach (char letter in introtext[indexOfHelp]){
            
            temp = temp + letter;
            mytext.text = temp;

            yield return new WaitForSeconds(0.01f);
        }*/
        mytext.text = Regex.Unescape(introtext[indexOfHelp]);

        next.gameObject.SetActive(true);
        
    }

    public void nextHelp(){
        
        next.gameObject.SetActive(false);
        executeprint();

        

        indexOfHelp++;
    }

    public void executeprint(){
        if(indexOfHelp < helpText.Length){
            print(helpText);
        }else
        {
            UIpanel.gameObject.SetActive(false);
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        indexOfHelp = 0;
        /*helpText = new string[]{"Hello world!",
            "To get started, we'll learn some basic commands you can give to your drone.",
            "Lets start by programming the drone by calling some commands, called \"precedures\".", 
            "Calling a procedure performs a series of tasks.", 
            "Now, in the bottom-right hand corner of the screen you'll see a button to open the text editor",
            "You can tap on that button to start editing the AI of your drone!",
            "First, start out by typing the \"forward()\" command, then tap the play button to execute the code."};*/
        executeprint();
        indexOfHelp ++;
        //StartCoroutine(print("hello world"));
    }

}
