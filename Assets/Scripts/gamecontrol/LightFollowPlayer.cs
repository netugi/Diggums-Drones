﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollowPlayer : MonoBehaviour
{
    public GameObject thePlayer;
   
   // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform);
    }
}
