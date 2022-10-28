using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> resourcePrefabs;
    public int factoryResourceLevel = 0;
    [SerializeField] GameObject spawner;
    public float spawnSpeed = 5.0f;
    private bool spawnResourceActive = false;
    public float conveyorSpeed = 5.0f;
    public int moneyValue = 0;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject upgradeParent;
    private bool upgradeConveyerHasBeenClicked = false;
    private bool upgradeResourceHasBeenClicked = false;
    [SerializeField] GameObject notEnoughMoneyWindow;
    [SerializeField] GameObject alreadyClickedText;
    private string factoryName;
    private Color spawnerColor;
    [SerializeField] GameObject spawnerObject1;
    [SerializeField] GameObject spawnerObject2;
    [SerializeField] GameObject spawnerObject3;
    [SerializeField] TextMeshProUGUI factoryNameText;
    void Start()
    {
        spawnerColor = MainManager.Instance.factoryColor;
        upgradeConveyerHasBeenClicked = MainManager.Instance.conveyorUpgrade;
        upgradeResourceHasBeenClicked = MainManager.Instance.resourceUpgrade;
        moneyValue = MainManager.Instance.moneyValue;
        factoryName = MainManager.Instance.factoryName;

        spawnerObject1.GetComponent<Renderer>().material.color = spawnerColor;
        spawnerObject2.GetComponent<Renderer>().material.color = spawnerColor;
        spawnerObject3.GetComponent<Renderer>().material.color = spawnerColor;
        factoryNameText.text = factoryName + " Factory";
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnResourceActive)
        {
            StartCoroutine(SpawnResource(factoryResourceLevel));
        }
        moneyText.text = "Money: $" + moneyValue;
    }

    IEnumerator SpawnResource(int resource)
    {
        spawnResourceActive = true;
        Vector3 spawnPos = spawner.transform.position;
        Instantiate(resourcePrefabs[resource], spawnPos, resourcePrefabs[resource].transform.rotation);
        yield return new WaitForSeconds(spawnSpeed);
        spawnResourceActive = false;
    }

    public void OpenUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        upgradeParent.SetActive(false);
    }

    public void CloseUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
        upgradeParent.SetActive(true);
    }

    public void UpgradeConveyor()
    {
        if (!upgradeConveyerHasBeenClicked && moneyValue >= 5000)
        {
            conveyorSpeed = 10.0f;
            moneyValue -= 5000;
            upgradeConveyerHasBeenClicked = true;
        }
        else if(moneyValue < 5000)
        {
            notEnoughMoneyWindow.SetActive(true);
            StartCoroutine(NotEnoughMoney());
        }
        else
        {
            alreadyClickedText.SetActive(true);
            StartCoroutine(AlreadyClicked());
        }
    }

    public void UpgradeResource()
    {
        if(!upgradeResourceHasBeenClicked && moneyValue >= 1000)
        {
            factoryResourceLevel = 1;
            moneyValue -= 1000;
            upgradeResourceHasBeenClicked = true;
        }
        else if(moneyValue < 1000)
        {
            notEnoughMoneyWindow.SetActive(true);
            StartCoroutine (NotEnoughMoney());
        }
        else
        {
            alreadyClickedText.SetActive(true);
            StartCoroutine(AlreadyClicked());
        }
    }

    IEnumerator NotEnoughMoney()
    {
        GameObject notEnoughMoneyWidnow = notEnoughMoneyWindow;
        yield return new WaitForSeconds(2.0f);
        notEnoughMoneyWidnow.SetActive(false);
    }

    IEnumerator AlreadyClicked()
    {
        GameObject other = alreadyClickedText;
        yield return new WaitForSeconds(2.0f);
        other.SetActive(false);
    }

    public void Menu()
    {
        MainManager.Instance.SaveGame();
        SceneManager.LoadScene(0);
    }
}
