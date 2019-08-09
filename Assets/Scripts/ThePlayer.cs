using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePlayer : MonoBehaviour
{

    public float v, dy;
    public float speed;
    public float moveForce = 365f;
    public float maxSpeed = 5f;

    public Transform projectile;
    public Joystick joystick;

    private Rigidbody2D rb2d;

    private float hInput = 0;

    // Start is called before the first frame update

    void Awake()
    {
        rb2d = gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {


        //#if !UNITY_ANDROID
        //Move(Input.GetAxis("Horizontal"));
        //#else
        //Move(hInput);
        //#endif

        if(transform.position.x < 0)
        {
            Debug.Log('R');
        }
        else if(transform.position.x > 0)
        {
            Debug.Log('L');
        }
        else
        {
            Debug.Log('M');
        }


    }

    private void FixedUpdate()
    {
        //remap for joysticks
        #if !UNITY_ANDROID
        Move(Input.GetAxis("Horizontal"));
        #else
        Move(hInput);
        #endif
        //Move(Input.GetAxis("Horizontal"));

    }

    private char PosChk()
    {
        if (transform.position.x < 0)
        {
            return('L');
        }
        else if (transform.position.x > 0)
        {
            return('R');
        }
        else
        {
            return('M');
        }

    }

    private void Move(float horizontalInput)
    {
         float cPos = transform.position.x;

        //v = Input.GetAxis("Horizontal");

        //These two lines below are for movement incrementally
        //speed = 6;
        //dy = horizontalInput * speed * Time.deltaTime;

        //since for this game we dont need incremental movement we will be using static values (aka no need for "Time.deltaTime")
        if (horizontalInput > 0 && PosChk() != 'R')
        {
            //Had to convert horizontalInput from double to float

            transform.position = new Vector2(cPos + (float)1.8 * horizontalInput, transform.position.y);
        }
        else if(horizontalInput < 0 && PosChk() != 'L')
        {
            transform.position = new Vector2(cPos + (float)1.8 * horizontalInput, transform.position.y);
        }
        else
        {
            // Do Nothing, might need to change this to make it more graceful
        }
        
    }

    public void startMoving(float horizontalInput)
    {
        //float horizontalInput was the originalparameter
        //Debug.Log(joystick.Horizontal);
        //hInput = joystick.Horizontal;
        hInput = horizontalInput;

    }

    public void stopMoving()
    {
        hInput = 0;
    }

    public void physMove(float horizontalInput)
    {
        //rb2d.MovePosition()
        if (horizontalInput * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * horizontalInput * moveForce);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

    }

    //not for this build of space travellers
    public void shoot()
    {
        Instantiate(projectile, GameObject.Find("Temp-Ship").transform.position, Quaternion.identity);
        //transform.Translate(0, Time.deltaTime * level, 0, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Contact");

        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("MOB"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
