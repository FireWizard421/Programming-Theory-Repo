using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject ConveyorBelt;
    private bool isOnConveyorBelt = true;
    private MainHandler mainHandler;
    private float conveyorSpeed;
    void Start()
    {
        ConveyorBelt = GameObject.Find("Conveyor Belt");
        mainHandler = GameObject.Find("MainHandler").GetComponent<MainHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        conveyorSpeed = mainHandler.conveyorSpeed;
        if (isOnConveyorBelt)
        {
            transform.Translate(Vector3.back * conveyorSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Conveyor Belt") || collision.gameObject.CompareTag("Spawner"))
        {
            isOnConveyorBelt = true;
        }
        else if (!collision.gameObject.CompareTag("Resource"))
        {
            isOnConveyorBelt = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ending Pad"))
        {
            if (gameObject.name == "Iron(Clone)")
            {
                mainHandler.moneyValue += 50;
            }
            else if (gameObject.name == "Gold(Clone)")
            {
                mainHandler.moneyValue += 100;
            }
            Destroy(gameObject);
        }
    }

}
