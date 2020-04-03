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
    private bool isVisible;

    public void ToggleTutorial() {
        if(!isVisible) {
            UIpanel.GetComponent<CanvasGroup>().interactable = true;
            UIpanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
            UIpanel.GetComponent<CanvasGroup>().alpha = 1;
            indexOfHelp = 0;
            isVisible = true;
            nextHelp();
        }
        else {
            UIpanel.GetComponent<CanvasGroup>().interactable = false;
            UIpanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            UIpanel.GetComponent<CanvasGroup>().alpha = 0;
            isVisible = false;
        }
    }

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
            UIpanel.GetComponent<CanvasGroup>().interactable = false;
            UIpanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            UIpanel.GetComponent<CanvasGroup>().alpha = 0;
            isVisible = false;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        indexOfHelp = 0;
        isVisible = true;
        nextHelp();
    }
}
