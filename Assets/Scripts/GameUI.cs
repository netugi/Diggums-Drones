using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
	float timeSpeed = 1f;
	public static bool AIEditorIsOpen = false;

	public GameObject panelEditAI;
	public GameObject panelLevelUI;


	void Start()
	{
		
	}

	public void OpenLevelUI()
	{
		panelEditAI.SetActive(false);
		panelLevelUI.SetActive(true);
		Time.timeScale = timeSpeed;
		AIEditorIsOpen = false;
	}

	public void OpenAIEditor()
	{
		panelEditAI.SetActive(true);
		panelLevelUI.SetActive(false);
		Time.timeScale = 0f;
		AIEditorIsOpen = true;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
