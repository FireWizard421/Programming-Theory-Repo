using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject mainMenuText;
    [SerializeField] GameObject factoryNamingText;
    private TextMeshProUGUI previousText = null;
    [SerializeField] GameObject errorText;
    public bool hasBeenClicked = false;
    [SerializeField] TMP_InputField InputField;
    private bool factoryColorValueEntered = false;
    private bool factoryNameValueEntered = false;
    void Start()
    {

    }

    // Update is called once per frame
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void FactorySelection()
    {
        mainMenuText.SetActive(false);
        factoryNamingText.SetActive(true);
    }

    public void BackToMenu()
    {
        mainMenuText.SetActive(true);
        factoryNamingText.SetActive(false);
    }
    public void ColorSelect(Color color, TextMeshProUGUI text)
    {
        if (hasBeenClicked)
        {
            hasBeenClicked = false;
            if(previousText != null)
            {
                previousText.text = "";
            }
        }
        if (!hasBeenClicked)
        {
            hasBeenClicked = true;
        }
        previousText = text;
        MainManager.Instance.factoryColor = color;
        factoryColorValueEntered = true;
    }

    public void StartGame()
    {
        if(factoryColorValueEntered && factoryNameValueEntered)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            errorText.SetActive(true);
        }
    }

    public void NameSelect()
    {
        MainManager.Instance.factoryName = InputField.text;
        factoryNameValueEntered = true;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        MainManager.Instance.LoadGame();
    }
}
