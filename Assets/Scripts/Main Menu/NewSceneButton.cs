using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewSceneButton : MonoBehaviour
{

    [SerializeField] private Button sceneButton;
    [SerializeField] private int targetScene;

    void Start()
    {
        if (sceneButton != null)
        {
            sceneButton.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(targetScene);
    }
}
