using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Time.deltaTime * 2, 0, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Contact: Bullet Hit!");

        //if (other.gameObject.CompareTag("Pick up"))
        //{
        //    other.gameObject.SetActive(false);
        //}

        if (other.gameObject.CompareTag("MOB"))
        {
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
