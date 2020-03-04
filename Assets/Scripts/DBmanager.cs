using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBmanager
{
    public static string username;
    public static int highestlvl;

    public static bool LoggedIn {get {return username != null; }}

    public static void Logout(){
        username = null;
    }
}
