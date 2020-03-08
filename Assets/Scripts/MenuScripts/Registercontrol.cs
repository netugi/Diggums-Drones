using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registercontrol : MonoBehaviour
{
    public Text usertext;
    public Text pwdtext;
    public Text repwdtext;

    public InputField userinput;
    public InputField pwdinput;
    public InputField repwdinput;

    public Button submitButton; //Regsiter button
   

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

            if(repwdinput.text == ""){
                repwdtext.text ="";
            }

            yield return new WaitForSeconds(.1f);

            usertext.text = "USERNAME:";
            pwdtext.text = "PASSWORD:";
            repwdtext.text = "Verify PWD:";

            yield return new WaitForSeconds(.1f);
            //Debug.Log("BLINKING");
        }
    }


        
    //=====================================================
    //Pushing to the database
    //=====================================================
    public void CallRegister(){ 
        StartCoroutine(Register());
    }

    IEnumerator Register(){
       
        if(pwdinput.text == repwdinput.text) // verify if password matches
        {
            WWWForm form = new WWWForm();
            form.AddField("name", userinput.text);
            form.AddField("password", pwdinput.text);

            WWW www = new WWW("http://localhost:8888/sqlconnect/register.php", form);
            yield return www;
            
            if(www.text == "0"){
                Debug.Log("User created successfully");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);

            }else{
                Debug.Log("User creation failed. " + www.text );
            }
        }else{
            Debug.Log("password did not match");
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
