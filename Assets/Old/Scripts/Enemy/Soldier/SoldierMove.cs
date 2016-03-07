using UnityEngine;
using System.Collections;

public class SoldierMove : MonoBehaviour
{
    public float speed;
    private SoldierReaction react;
    private Rigidbody2D rb;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        react = GetComponent<SoldierReaction>();
    }
	
	// Update is called once per frame
	

    void FixedUpdate()
    {
        if ((react.currentState=="Panic")||(react.currentState == "Prepare")|| (react.currentState == "Start"))
        {
            rb.velocity = Vector2.zero;
        }
        else 
        if (react.currentState=="Run")
        {
            rb.velocity = Vector2.up * speed;
        }
        
    }
}
