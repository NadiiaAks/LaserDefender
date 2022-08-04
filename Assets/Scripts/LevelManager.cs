using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDeley = 2f;
    [SerializeField] int scoreForNextLvl = 100;

    ScoreKeeper scoreKeeper;
    int currentScene;
    int lastScene;

    private void Awake()
    {
        scoreKeeper =  FindObjectOfType<ScoreKeeper>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        lastScene = SceneManager.sceneCountInBuildSettings;
    }

    private void Update()
    {
        NextLevel();
    }
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene(1);
    }

    public void LoadMainManu()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        Debug.Log("Game Over" + lastScene);
        StartCoroutine(WaitAndLoad(3, sceneLoadDeley));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void NextLevel()
    {
        if (scoreKeeper.GetScore() >= scoreForNextLvl && currentScene != lastScene)
        {
            StartCoroutine(WaitAndLoad(currentScene + 1, sceneLoadDeley));
        }
    }

    IEnumerator WaitAndLoad(int Scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(Scene);
    }
}
