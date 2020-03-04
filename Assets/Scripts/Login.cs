using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    

    public Button submitButton;

    public void CallLogin(){ 
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer(){
        //http://localhost/sqlconnect/register.php
        
            WWWForm form = new WWWForm();
            form.AddField("name", nameField.text);
            form.AddField("password", passwordField.text);

            WWW www = new WWW("http://localhost:8888/sqlconnect/login.php", form);
            yield return www;
            

            if(www.text[0] == '0'){
                Debug.Log("success");
                DBmanager.username = nameField.text;
                DBmanager.highestlvl = int.Parse(www.text.Split('\t')[1]);
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
                


            }else{
                Debug.Log("User Login failed" + www.text);
            }
        
    }


    public void VerifyInput(){
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
