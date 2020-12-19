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

    [SerializeField] private GameObject playerPrefab = null;
    private GameObject player = null;
    private Transform spawnpoint = null;
    private string loadedScene;

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void FinishLevel()
    {
        OnLevelFinished.Invoke();
    }

    public void StartLevel()
    {
        OnLevelStart.Invoke();

        spawnpoint = GameObject.FindGameObjectWithTag("Spawnpoint").transform;

        if (spawnpoint == null) return;

        player = Instantiate(playerPrefab, spawnpoint.position, Quaternion.identity) as GameObject;
    }

    public void LoadLevel(string scene)
    {
        loadedScene = scene;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.path);
        if(scene.path.Equals(loadedScene))
        {
            StartLevel();
        }
    }
}
