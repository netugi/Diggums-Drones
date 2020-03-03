using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashTransition : MonoBehaviour
{
	public Image blanket;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeSplash());
    }
	
	IEnumerator FadeSplash()
	{
		blanket.canvasRenderer.SetAlpha(0f);
		blanket.CrossFadeAlpha(1f, 1.5f, false);
		yield return new WaitForSeconds(2.5f);
		blanket.CrossFadeAlpha(0f, 1.5f, false);
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("MainMenu");
	}
}
