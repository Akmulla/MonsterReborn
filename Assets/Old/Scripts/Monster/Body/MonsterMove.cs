using UnityEngine;
using System.Collections;

public class MonsterMove : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            speed*=-1;
        }
    }

    //private Rigidbody2D rb;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    rb.velocity = Vector2.right * speed;
    //}

    //void Update()
    //{

    //}


    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Boundary")
    //    {
    //        if (other.gameObject.name == "rightBoundary")
    //        {
    //            rb.velocity = Vector2.left * speed;
    //        }
    //        else
    //        {
    //            rb.velocity = Vector2.right * speed;
    //        }
    //    }
    //}
}
