using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    [Scene] public string playerScene1;
    [Scene] public string playerScene2;

    [SerializeField] private Transform startMenu = null;

    [SerializeField] private Transform slideShowContainer = null;
    [SerializeField] private Transform slideShow = null;
    public UnityEvent OnSlideshowFinished;
    private List<Transform> slides = new List<Transform>();
    private int currentIndex = 0;

    private void Start()
    {
        if (OnSlideshowFinished == null)
            OnSlideshowFinished = new UnityEvent();

        if (slideShowContainer == null) return;
        foreach(Transform child in slideShowContainer)
        {
            slides.Add(child);
            child.gameObject.SetActive(false);
        }

        slides[currentIndex].gameObject.SetActive(true);
    }

    public void LoadDirector()
    {
        startMenu.gameObject.SetActive(false);
        slideShow.gameObject.SetActive(true);
    }

    public void BackDirector()
    {
        startMenu.gameObject.SetActive(true);
        slideShow.gameObject.SetActive(false);
    }

    public void LoadPlayer()
    {
        int rand =  Mathf.RoundToInt(Random.Range(1f, 2f));
        string selectedScene = string.Empty;

        switch(rand)
        {
            case 1:
                if (string.IsNullOrEmpty(playerScene1)) return;
                selectedScene = playerScene1;
                break;
            case 2:
                if (string.IsNullOrEmpty(playerScene2)) return;
                selectedScene = playerScene2;
                break;
        }

        if (string.IsNullOrEmpty(selectedScene)) return;

        GameManager.Instance.LoadLevel(selectedScene);
    }

    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void SlideLeft()
    {
        if (currentIndex <= 0) return;
        else currentIndex--;

        resetAll();
        slides[currentIndex].gameObject.SetActive(true);
    }

    public void SlideRight()
    {
        if (currentIndex >= slides.Count - 1)
        {
            endReached();
            return;
        }
        else currentIndex++;

        resetAll();
        slides[currentIndex].gameObject.SetActive(true);
    }

    private void resetAll()
    {
        foreach (Transform child in slides)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void endReached()
    {
        OnSlideshowFinished.Invoke();
    }
}
