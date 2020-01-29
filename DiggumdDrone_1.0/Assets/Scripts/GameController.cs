using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoonSharp.Interpreter;



public class GameController : MonoBehaviour
{
    public GameObject ExecuteButton;
    public GameObject inputField;
    public InputField InputCode;
    string filePath;
    string functions;
    public MovementControl movementcontrol;

    string LuaCode; //raw LUA code
    string LuaSequence; //sequence of movements
    int seqlen;

    //gets the inputed LUA code from player

    void getInputCode(){

        //gets LUA functions

        filePath = System.IO.Path.Combine("Assets","LUA");
        filePath = System.IO.Path.Combine(filePath,"LuaCode.LUA");
        functions = System.IO.File.ReadAllText(filePath);

        //final LUA code
        LuaCode = functions + InputCode.text + @"
        return sequence
        end
        ";

        Debug.Log(LuaCode);
   
    }

    
    
    //executes on click
    public void executeLUA(){

        getInputCode();

        //runs the LUA code
        Script myLuaScript = new Script();
        DynValue temp = myLuaScript.DoString(LuaCode);
        temp = myLuaScript.Call(myLuaScript.Globals["getSequence"]); //calls getSequence function from  LUA script and returns the sequence

        LuaSequence = temp.ToString(); //converts raw LUA to string
        Debug.Log(LuaSequence);
        seqlen = LuaSequence.Length;


        //hides button and inputField
        inputField.SetActive(false);
        ExecuteButton.SetActive(false);

        StartCoroutine(StartTheDrone());
    }

    //starts the drone, gives delay for movements
    IEnumerator StartTheDrone(){

        for(int i = 0; i < seqlen; i++){

            movementcontrol.Move(LuaSequence[i].ToString());
            yield return new WaitForSeconds(1f); //sets the delay of movements
        }
    }

    
}
