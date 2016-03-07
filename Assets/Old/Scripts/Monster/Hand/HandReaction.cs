using UnityEngine;
using System.Collections;

public class HandReaction : MonoBehaviour
{
    private Animator anim;
    private float damageDuration=2;
    private float damageEnd;

	void Start ()
    {
        anim = GetComponentInChildren<Animator>();
	}
	
	
	void Update ()
    {
	    if (Time.time>damageEnd)
        {
            anim.SetBool("Damaged", false);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag=="Bullet")
        {
            GetHit();    
        }
    }

    public void GetHit()
    {
        anim.SetBool("Damaged",true);
        damageEnd = Time.time + damageDuration;
    }
}
