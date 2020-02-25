using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelControl : MonoBehaviour
{

    public GameObject Victory;
    public GameObject NextLevelButton;
    public GameObject LevelSelectButton;

    //when drone reaches the finish line, it goes to the next lvl
   void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Player")){

            Time.timeScale = 0; // stops the game
            Victory.SetActive(true);
            NextLevelButton.SetActive(true);
            LevelSelectButton.SetActive(true);

       }
   }

   public void nextLevel(string _level){
       SceneManager.LoadScene(_level);
   }

   public void levelSelect(){
       SceneManager.LoadScene("LevelSelect01");
   }
}
