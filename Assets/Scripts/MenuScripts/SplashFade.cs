using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashFade : MonoBehaviour
{
	public Image splash;
	
    // Start is called before the first frame update
    void Start()
    {
		splash = GetComponent<Image>();
		splash.CrossFadeAlpha(0f, 0f, false);
		StartCoroutine(FadeImage());
    }
	
	IEnumerator FadeImage()
	{
		splash.CrossFadeAlpha(1f, 1.5f, false);
		yield return new WaitForSeconds(2.5f);
		splash.CrossFadeAlpha(0f, 1.5f, false);
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("lvlselect");
	}
}
