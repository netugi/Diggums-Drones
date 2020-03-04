using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectControl : MonoBehaviour
{	

	public Button lvl1;
	public Button lvl2;
	public Button lvl3;


	public void SelectLevel(string _scene)
	{
		SceneManager.LoadScene(_scene);
	}

	private void Start() {
		int lvl = DBmanager.highestlvl;
		
		if(lvl == 1){
			lvl1.interactable = true;
		}else if (lvl == 2){
			lvl1.interactable = true;
			lvl2.interactable = true;
			
		}else if(lvl == 3){
			lvl1.interactable = true;
			lvl2.interactable = true;
			lvl3.interactable = true;
		}

	}
}
