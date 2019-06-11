using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePlayer : MonoBehaviour
{

    public float v, dy;
    public float speed;
    public float moveForce = 365f;
    public float maxSpeed = 5f;

    public GameObject projectile;

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

    }

    private void FixedUpdate()
    {
        #if !UNITY_ANDROID
        Move(Input.GetAxis("Horizontal"));
        #else
        Move(hInput);
        #endif
    }

    private void Move(float horizontalInput)
    {
        speed = 6;
        //v = Input.GetAxis("Horizontal");
        dy = horizontalInput * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + dy, transform.position.y);
    }

    public void startMoving(float horizontalInput)
    {
        hInput = horizontalInput;
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

    public void shoot()
    {
        Instantiate(projectile, GameObject.Find("Ship").transform.position, Quaternion.identity);
        //transform.Translate(0, Time.deltaTime * level, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
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
