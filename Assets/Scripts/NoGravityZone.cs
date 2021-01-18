using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravityZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Отрицательная гравитация 
        // Physics2D.gravity = new Vector2(0, 9.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.attachedRigidbody.gravityScale = 0;
        collision.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.attachedRigidbody.gravityScale = 10;
        collision.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
