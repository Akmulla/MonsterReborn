using UnityEngine;
using System.Collections;

public class CitizenReaction : MonoBehaviour
{
    public bool inPanic = true;

    private float panicDuration = 2;
    private float panicEnd;

    private Transform monster;
    private Animator anim;
    private GameObject hand;
    private Collider2D handCollider;

    
    
    
    void Start ()
    {
        anim = GetComponentInChildren<Animator>();
        //panicEnd = Time.time + panicDuration;
        monster = GameObject.Find("Monster").transform;
        hand = GameObject.Find("Hand");
        handCollider = hand.GetComponent<Collider2D>();
    }
	
	void Update ()
    {
        Vector2 toMonster = transform.position - monster.position;
        if ((Physics2D.IsTouching(GetComponent<Collider2D>(),handCollider))|| (toMonster.magnitude < 2))
        {
            anim.SetBool("Panic", true);
            inPanic = true;
        }
        else
        if (Time.time > panicEnd)
        {
            anim.SetBool("Panic", false);
            inPanic = false;
        }
        
    }
}
