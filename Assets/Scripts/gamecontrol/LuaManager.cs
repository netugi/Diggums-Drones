using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public static class LuaManager
{
    public static string CsharpCode;
    public static string LuaCode;

    public static string GenerateLuaSequence(){

        string functions;
        string filePath = System.IO.Path.Combine("Assets","LUA");
        filePath = System.IO.Path.Combine(filePath,"LuaCode.LUA");
        functions = System.IO.File.ReadAllText(filePath);

        //final LUA code
        LuaCode = functions + CsharpCode + @"
        return sequence
        end
        ";

        Script myLuaScript = new Script();
        DynValue temp = myLuaScript.DoString(LuaCode);
        temp = myLuaScript.Call(myLuaScript.Globals["getSequence"]); //calls getSequence function from  LUA script and returns the sequence

        return temp.ToString();

    }
}
