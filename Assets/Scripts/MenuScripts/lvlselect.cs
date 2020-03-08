using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class lvlselect : MonoBehaviour
{
   
    public Text usernamedisplay;

    public Button lvl1;
	public Button lvl2;
	public Button lvl3;
    public Button lvl4;
    public Button lvl5;
    public Button lvl6;

    public void SelectLevel(string _scene)
	{
		SceneManager.LoadScene(_scene);
	}

    void Start()
    {
        string user = DBmanager.username;
        int lvl = DBmanager.highestlvl;
        usernamedisplay.text = user;

        switch (lvl)
        {
            case 1:
                lvl1.interactable = true;
                break;
            case 2:
                lvl1.interactable = true;
                lvl2.interactable = true;
                break;
            case 3:
                lvl1.interactable = true;
                lvl2.interactable = true;
                lvl3.interactable = true;
                break;
            case 4:
                lvl1.interactable = true;
                lvl2.interactable = true;
                lvl3.interactable = true;
                lvl4.interactable = true;
                break;
            case 5:
                lvl1.interactable = true;
                lvl2.interactable = true;
                lvl3.interactable = true;
                lvl4.interactable = true;
                lvl5.interactable = true;
                break;
            case 6:
                lvl1.interactable = true;
                lvl2.interactable = true;
                lvl3.interactable = true;
                lvl4.interactable = true;
                lvl5.interactable = true;
                lvl6.interactable = true;
                break;
        }


    }

    
}
