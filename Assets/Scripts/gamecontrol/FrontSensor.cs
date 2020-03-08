using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontSensor : MonoBehaviour
{
   
   void OnTriggerEnter(Collider other)
   {
       datamanager.obstacleType = other.gameObject.tag;
       datamanager.obstacle = other.gameObject;
   }


  
}
