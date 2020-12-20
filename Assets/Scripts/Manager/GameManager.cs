using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private List<IBreakable> brokenObjects = new List<IBreakable>();
    private int brokenObjectTotal = 0;

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

        var gameEvents = this.gameObject.GetComponents<IGameEvent>();
        if (gameEvents == null) return;

        foreach(var gameEvent in gameEvents)
        {
            gameEvent.Invoke();
        }

        Debug.Log($"{brokenObjects.Count} / {brokenObjectTotal}");
    }

    public void StartLevel()
    {
        OnLevelStart.Invoke();

        spawnpoint = GameObject.FindGameObjectWithTag("Spawnpoint").transform;

        if (spawnpoint == null) return;

        player = Instantiate(playerPrefab, spawnpoint.position, Quaternion.identity) as GameObject;

        brokenObjectTotal = GameObject.FindObjectsOfType<Breaking>().Length;
    }

    public void AddBrokenObject(IBreakable brokenObject)
    {
        brokenObjects.Add(brokenObject);
    }

    public void LoadLevel(string scene)
    {
        loadedScene = scene;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.path.Equals(loadedScene))
        {
            StartLevel();
        }
    }
}
