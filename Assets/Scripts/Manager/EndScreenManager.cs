using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    private static EndScreenManager _instance;
    public static EndScreenManager Instance { get { return _instance; } }
    public TMP_Text scoreText;
   
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void SetScore(int score, int maxScore)
    {
        scoreText.SetText($"You destroyed {score} out of {maxScore}!");
    }

    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
