using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradeMenu : MonoBehaviour
{
    // Start is called before the first frame update
    MainHandler mainHandler;
    private void Start()
    {
        mainHandler = GameObject.Find("MainHandler").GetComponent<MainHandler>();
    }

    private void OnMouseDown()
    {
        mainHandler.OpenUpgradeMenu();
    }
}
