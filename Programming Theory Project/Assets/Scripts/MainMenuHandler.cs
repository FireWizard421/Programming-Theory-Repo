using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject mainMenuText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }
}
