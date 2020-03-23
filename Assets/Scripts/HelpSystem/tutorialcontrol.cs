using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class tutorialcontrol : MonoBehaviour
{

    public Text mytext;
    public GameObject UIpanel;
    public Button next;
    private string[] helpText;
    private string[] helpText2;
    private int indexOfHelp;

    private int k;



    IEnumerator print(string[] introtext){
        string temp = "";
        foreach (char letter in introtext[indexOfHelp]){
            
            temp = temp + letter;
            mytext.text = temp;

            yield return new WaitForSeconds(0.05f);
        }

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

    public void executeprint(string[] ht){
        if(indexOfHelp != ht.Length){
            StartCoroutine(print(ht));
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
        helpText = new string[]{"hello world!!","Welcome to Diggums Drones", "Learn How to Code the FUN way","Lets start by programming the drone by calling functions", "a function is a block of code that performs tasks", "Now open your Text Editor, and type in the function: forward(), and then press play"};
        helpText2 = new string[]{"good Job!!", "now you are ready for the next challenge!"};
        executeprint(helpText);
        indexOfHelp ++;
        //StartCoroutine(print("hello world"));
    }
    public void help2next() {


         if(k == 1){
            
             UIpanel.gameObject.SetActive(true);

            indexOfHelp = 0;
            executeprint(helpText2);
            
            
        }
        
    }
}
