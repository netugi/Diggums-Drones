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

    public void print(string[] introtext){
        string temp = "";
        foreach (char letter in introtext[indexOfHelp]){
            
            temp = temp + letter;
            mytext.text = temp;

            //yield return new WaitForSeconds(0.01f);
        }
        mytext.text = Regex.Unescape(introtext[indexOfHelp]);

        next.gameObject.SetActive(true);
        
    }

    public void nextHelp(){
        
        next.gameObject.SetActive(false);
        if(k == 0){
            executeprint(helpText);
        }
        else{
            executeprint(helpText2);
        }


        

        indexOfHelp++;
    }

    public void executeprint(){
        if(indexOfHelp < helpText.Length){
            print(helpText);
        }else
        {
            if(k == 1) SceneManager.LoadScene("lvl2");
            k++;
            UIpanel.gameObject.SetActive(false);
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        k = 0;
        indexOfHelp = 0;
        executeprint();
        indexOfHelp ++;
    }
    public void help2next() {


         if(k == 1){
            
             UIpanel.gameObject.SetActive(true);

            indexOfHelp = 0;
            executeprint(helpText2);
            
            
        }
        
    }
}
