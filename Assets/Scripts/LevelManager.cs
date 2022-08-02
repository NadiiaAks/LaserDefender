using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDeley = 2f;
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainManu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad(2, sceneLoadDeley));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int Scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(Scene);
    }
}
