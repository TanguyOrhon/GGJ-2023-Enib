using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;

    public void OnClick()
    {
       
        StartCoroutine(LoadNextScene());
       
    }

    public IEnumerator LoadNextScene()
    {
        yield return null;
        SceneManager.LoadScene(sceneName);
    }
}