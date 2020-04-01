using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MoonSharp.Interpreter;

public static class LuaManager
{
    public static string CsharpCode;
    public static string LuaCode;

    public static string GenerateLuaSequence(){

        CoreModules modules = CoreModules.Preset_HardSandbox; // Allows access to only a select few APIs in Lua code.
        var luaFile = Resources.Load<TextAsset>("Lua/LuaCode");
        string functions;

        functions = luaFile.ToString();

        //final LUA code
        LuaCode = functions + CsharpCode + @"
        return sequence
        end
        ";

        Script myLuaScript = new Script(modules);
        DynValue temp = myLuaScript.DoString(LuaCode);
        temp = myLuaScript.Call(myLuaScript.Globals["getSequence"]); //calls getSequence function from  LUA script and returns the sequence

        return temp.ToString();

    }

    // Using this means we won't need to update Unity's link.xml to run on IL2CPP platforms
    public static void RegisterScripts() {

        Dictionary<string, string> scripts = new Dictionary<string, string>();
        object[] result = Resources.LoadAll("Lua", typeof(TextAsset));

        foreach(TextAsset ta in result.OfType<TextAsset>()) {
            scripts.Add(ta.name, ta.text);
        }

        Script.DefaultOptions.ScriptLoader = new MoonSharp.Interpreter.Loaders.UnityAssetsScriptLoader(scripts);
        
    }
}
