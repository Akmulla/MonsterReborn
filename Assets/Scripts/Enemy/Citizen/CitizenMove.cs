using UnityEngine;
using System.Collections;

public class CitizenMove : MonoBehaviour
{
    public float speed;
    private CitizenReaction react;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        react = GetComponent<CitizenReaction>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    void FixedUpdate()
    {
        if (!react.inPanic)
        {
            rb.velocity = Vector2.up * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
