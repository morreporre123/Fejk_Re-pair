using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    //Floats
    public float speed = 6f;
    public float jump = 10;
    private  float moveInputX;
    //Bools
    private bool isGrounded;
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
        moveInputX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInputX * speed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    
        if(sockCount == 2)
        {
            StartCoroutine(WaitForEndscreen(2));
        }


    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "RedSock1")
        {
            Destroy(redSock);
            sockCount++;
        }

        if (col.gameObject.name == "RedSock2")
        {
            Destroy(redSock2);
            sockCount++;
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


