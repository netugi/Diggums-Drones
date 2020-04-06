using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadBar;
    public Text loadText;
    public Text loadMessage;

    public void LoadScene(string _scene, string _loadMsg)
    {
        loadMessage.text = _loadMsg;
        FindObjectOfType<PanelFader>().Fade(loadingScreen);
        StartCoroutine(LoadAsync(_scene));
    }

    IEnumerator LoadAsync(string _scene)
    {
        float counter = 0f;

        AsyncOperation operation = SceneManager.LoadSceneAsync(_scene);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadBar.value = progress;
            loadText.text = Mathf.Round(progress * 100f).ToString() + "%";

            yield return null;
        }
    }

}
