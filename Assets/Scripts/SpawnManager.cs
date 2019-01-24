using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstacle;
    public GameObject coin;
    public GameObject shipPickup;

    public Transform obsTest;
    public Transform coinTest;
    public Transform shipTest;

    private BoxCollider2D bc2d;
    private float timer = 0.0f;
    private GameObject[] gameObjects;
    private Transform[] testObjects;


    // Start is called before the first frame update
    void Start()
    {
        gameObjects = new GameObject[] { obstacle, coin, shipPickup};

        testObjects = new Transform[] { obsTest, coinTest, shipTest };

        //bc2d = GetComponent<BoxCollider2D>();

        //int choice = Random.Range(0, 3);
        //Instantiate(obstacle, new Vector2(0, 8), Quaternion.identity);

        entitySpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > 5)
        {
            //int choice = Random.Range(0, 3);
            //Instantiate(gameObjects[choice], bc2d.transform.position, Quaternion.identity);
            Debug.Log("Timer divisible");
            entitySpawn();
            timer -= 5;
        }
    }

    void entitySpawn()
    {
        int choice = Random.Range(0, 3);
        //Debug.Log("Choice: " + choice + "Object type: " + gameObjects[2]);
        //Instantiate(gameObjects[0], new Vector2(0, 8), Quaternion.identity);

        Instantiate(testObjects[choice], new Vector2(0, 8), Quaternion.identity);

    }
}
