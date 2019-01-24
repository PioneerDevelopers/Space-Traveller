using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
   

    //void OnCollisionEnter2D (Collision2D col)
    //{
    //    if((col.gameObject.tag == "Player") || (col.gameObject.tag == "Platform"))
    //    {
    //        Destroy(col.gameObject);
    //    }
    //}

    //void Start()
    //{
        
    //}

    //private void Update()
    //{
       
        
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MOB")
        {

            Destroy(collision.gameObject);            
        }

        
    }
        
}
