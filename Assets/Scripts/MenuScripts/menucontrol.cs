using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menucontrol : MonoBehaviour
{
    public void SelectLevel(string _scene)
	{
		SceneManager.LoadScene(_scene);
	}
}
