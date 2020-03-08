using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logincontrol : MonoBehaviour
{
    
    public Text usertext;
    public Text pwdtext;
    public InputField userinput;
    public InputField pwdinput;

    public Button submitButton;


    //-------------------------------------
    //Blinking texts
   //-------------------------------------
   
    public IEnumerator BlinkText(){
        while(true){

            if(userinput.text == "") //username text blinks when field is empty
            {
                usertext.text = "";
            }
            if(pwdinput.text == "") // password text blinks when field is empty
            {
                pwdtext.text = "";
            }

            yield return new WaitForSeconds(.1f);

            usertext.text = "USERNAME:";
            pwdtext.text = "PASSWORD:";

            yield return new WaitForSeconds(.1f);
            //Debug.Log("BLINKING");
        }
    }


     //=====================================================
    //Pulling to the database
    //=====================================================

    
    public void CallLogin(){ 
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer(){
        //http://localhost/sqlconnect/register.php
        
            WWWForm form = new WWWForm();
            form.AddField("name", userinput.text);
            form.AddField("password", pwdinput.text);

            WWW www = new WWW("http://localhost:8888/sqlconnect/login.php", form);
            yield return www;
            

            if(www.text[0] == '0'){
                Debug.Log("success");
                DBmanager.username = userinput.text;
                DBmanager.highestlvl = int.Parse(www.text.Split('\t')[1]);
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
                


            }else{
                Debug.Log("User Login failed" + www.text);
            }
        
    }


    public void VerifyInput(){
        submitButton.interactable = (userinput.text.Length >= 8 && pwdinput.text.Length >= 8);
    }



    private void Start() {
        Debug.Log("Start");
        StartCoroutine(BlinkText());

    }
}
