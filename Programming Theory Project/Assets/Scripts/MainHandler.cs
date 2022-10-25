using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> resourcePrefabs;
    public int factoryResourceLevel = 0;
    [SerializeField] GameObject spawner;
    public float spawnSpeed = 5.0f;
    private bool spawnResourceActive = false;
    public float conveyorSpeed = 5.0f;
    public int moneyValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnResourceActive)
        {
            StartCoroutine(SpawnResource(factoryResourceLevel));
        }
    }

    IEnumerator SpawnResource(int resource)
    {
        spawnResourceActive = true;
        Vector3 spawnPos = spawner.transform.position;
        Instantiate(resourcePrefabs[resource], spawnPos, resourcePrefabs[resource].transform.rotation);
        yield return new WaitForSeconds(spawnSpeed);
        spawnResourceActive = false;
    }
}
