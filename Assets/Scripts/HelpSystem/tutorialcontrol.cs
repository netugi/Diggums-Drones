using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class tutorialcontrol : MonoBehaviour
{

    public Text mytext;
    public GameObject UIpanel;
    public Button next;
    public string[] helpText;
    private int indexOfHelp;

    /*public IEnumerator print(string[] introtext){
        string temp = "";
        foreach (char letter in introtext[indexOfHelp]){
            
            temp = temp + letter;
            mytext.text = Regex.Unescape(temp);

            yield return new WaitForSeconds(0.01f);
        }
        mytext.text = Regex.Unescape(temp);

        next.gameObject.SetActive(true);
    }*/

    public void print(string[] introtext){
        
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
        }
        else {
            UIpanel.SetActive(false);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        indexOfHelp = 0;
        nextHelp();
    }
}
