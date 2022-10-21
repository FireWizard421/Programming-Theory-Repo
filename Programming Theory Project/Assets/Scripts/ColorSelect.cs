using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColorSelect : MonoBehaviour
{
    // Start is called before the first frame update
    private MainMenuHandler mainMenuHandler;
    private Button button;
    [SerializeField] TextMeshProUGUI text;
    private Color color;
    public void Start()
    {
        button = gameObject.GetComponent<Button>();
        mainMenuHandler = GameObject.Find("MainMenuHandler").GetComponent<MainMenuHandler>();
    }

    public void Click()
    {
        color = button.image.color;
        text.text = "X";
        mainMenuHandler.ColorSelect(color, text);
    }
}
