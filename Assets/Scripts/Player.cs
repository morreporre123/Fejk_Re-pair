using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    //Floats
    public float speed = 6f;
    public float jump = 9;
    private  float moveInputX;
    //Bools
    private bool isGrounded;
    bool isDead = false;
    bool hasWon = false;
    //gameObjects
    public GameObject redSock;
    public GameObject redSock2;
    //ints
    private int sockCount = 0;
    //Colliders
    Collider2D groundCollider;
    //layermask
    [SerializeField]
    LayerMask jumpable;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCollider = transform.Find("GroundCheck").GetComponentInChildren<Collider2D>();
    }



    void FixedUpdate()
    {
        //Man får ett värde som multipliseras med "speed" för att bestämma velocity;
        if (!isDead)
        {
            moveInputX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInputX * speed, rb.velocity.y);
        }


        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !isDead)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    
        if(sockCount <= 0)
        {
            gameObject.layer = 9;
        }

        else
        {
            gameObject.layer = 10;
        }

        if(sockCount == 2)
        {
            StartCoroutine(WaitForEndscreen(2));
        }


    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "RedSock")
        {
            Destroy(col.gameObject);
            sockCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Enemy" && sockCount == 1)
        {
            rb.velocity = Vector2.zero;
            isDead = true;
            GameController.instance.playerDied();
        }
    }

    bool IsGrounded()
    {
        return groundCollider.IsTouchingLayers(jumpable);
    }

    IEnumerator WaitForEndscreen(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        SceneManager.LoadScene("WinScreen");
    }
}


