using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFader : MonoBehaviour
{
    public bool mFaded = false;
    public float duration = 0.4f;
    
    public void Fade(GameObject item)
    {
        var canvGroup = GetComponent<CanvasGroup>();

        // Toggle the direction of fade
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

        mFaded = !mFaded;
    }

    IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, counter / duration);

            yield return null;
        }
    }
}
