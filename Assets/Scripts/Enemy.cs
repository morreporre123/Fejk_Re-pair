using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float randomSpeed;

    bool movingRight = true;

    public Transform groundDetection;

    public LayerMask raycastMask;
            //Variabler
    void Start()
    {
        randomSpeed = Random.Range(2f, 3f);     //Sätter en random speed på enemyn i början av spelet
    }

    void Update()
    {
        //Debug.DrawRay(groundDetection.position, Vector2.down * 1);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);        //Skapar en Raycast so siktar rakt ner
        if (groundInfo.collider == false)       //Om Raycasten inte colliderar med någonting...
        {
            if(movingRight == true)     //Och om enemyn rör sig höger...
            {
                transform.eulerAngles = new Vector3(0, -180, 0);        //Ska den vända sig till vänster och börja gå
                movingRight = false;        //Samt sätter moving right till false
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);       //Om den redan går vänster ska den vända sig till höger och gå
                movingRight = true;     //Samt sätta moving right till true
            }
        }
        transform.Translate(Vector2.right * randomSpeed * Time.deltaTime);      //Dunno
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
