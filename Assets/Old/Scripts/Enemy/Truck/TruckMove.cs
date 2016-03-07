using UnityEngine;
using System.Collections;

public class TruckMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	
	void Update ()
    {
	
	}

    void FixedUpdate()
    {
        
        rb.velocity = Vector2.down * speed;
    }
}
