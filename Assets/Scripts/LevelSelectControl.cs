using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectControl : MonoBehaviour
{
	
	public void SelectLevel(string _scene)
	{
		SceneManager.LoadScene(_scene);
	}
}
