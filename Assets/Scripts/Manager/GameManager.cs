using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public UnityEvent OnLevelStart;
    public UnityEvent OnLevelFinished;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        if (OnLevelFinished == null)
            OnLevelFinished = new UnityEvent();

        if (OnLevelStart == null)
            OnLevelStart = new UnityEvent();
    }

    public void FinishLevel()
    {
        OnLevelFinished.Invoke();
    }

    public void StartLevel()
    {
        OnLevelStart.Invoke();
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(loadSceneAsync(scene));
    }

    private IEnumerator loadSceneAsync(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
