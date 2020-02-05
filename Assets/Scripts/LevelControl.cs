using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelControl : MonoBehaviour
{

    public GameObject Victory;
    public GameObject NextLevelButton;

    //when drone reaches the finish line, it goes to the next lvl
   void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Player")){

            Time.timeScale = 0; // stops the game
            Victory.SetActive(true);
            NextLevelButton.SetActive(true);

       }
   }

   public void nextLevel(){
       SceneManager.LoadScene(1);
   }
}
