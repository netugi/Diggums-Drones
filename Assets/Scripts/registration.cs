using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class registration : MonoBehaviour
{
    
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallRegister(){
        StartCoroutine(Register());
    }

    IEnumerator Register(){

        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("http://localhost:8888/sqlconnect/register.php", form);
        yield return www;
        
        if(www.text == "0"){
            Debug.Log("User created successfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }else{
            Debug.Log("User creation failed. " + www.text );
        }
    }

    public void VerifyInput(){
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }


}
