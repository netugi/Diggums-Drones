using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditExecute : MonoBehaviour
{
   
    public InputField Code; // inputfield code

    public Button EditCode;
    public Button ExecuteCode;
    
    private bool FieldIsOpen;

    private string codeText;

    private GameObject playerCamera;
    private GameObject MainCamera;
    // public void getCode(){
    //     codeText = Code.text;
    // }
    private void Start() {
        FieldIsOpen = false;
        playerCamera = GameObject.FindGameObjectWithTag("dronecamera");
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void EditCodeOnCall(){
        if(!FieldIsOpen){
            Debug.Log("Opening");
            Code.gameObject.SetActive(true);
            FieldIsOpen = true;

        }
        else{
            Debug.Log("closing");
            Code.gameObject.SetActive(false);
            FieldIsOpen = false;
        }
    } 

    public void ExecuteCodeOnCall(){
        LuaManager.CsharpCode = codeText;
        Code.gameObject.SetActive(false);
        
    }


    //makes runCode button clickable if some lines of codes was inputed.
    public void IsThereCode(){
        ExecuteCode.interactable = (Code.text != null);
    }
    

    private void Update() {
        codeText = Code.text;
        
    }
    
   

}
