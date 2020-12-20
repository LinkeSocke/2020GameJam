using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    [SerializeField] private Transform collectibleParent;
    [SerializeField] private GameObject collectibleUIItem;

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

    public void AddKeycardToUI(Keycard keycards)
    {
        var newItem = Instantiate(collectibleUIItem, collectibleParent);
        newItem.GetComponent<Image>().sprite = keycards.keycardSprite;

        // TESTING
        newItem.GetComponent<Image>().color = keycards.keycardColor;
    }

}
 