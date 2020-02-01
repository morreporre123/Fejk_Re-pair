using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float randomSpeed;

    bool movingRight = true;

    public Transform groundDetection;

    public LayerMask raycastMask;

    void Start()
    {
        randomSpeed = Random.Range(2f, 3f);
    }

    void Update()
    {
        Debug.DrawRay(groundDetection.position, Vector2.down * 1);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
        if (groundInfo.collider == false)
        {
            if(movingRight == true)
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
        transform.Translate(Vector2.right * randomSpeed * Time.deltaTime);
    }
}
