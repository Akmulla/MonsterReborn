using UnityEngine;
using System.Collections;

public class MonsterReaction : MonoBehaviour
{
    private Animator anim;
    private VerticalMove vert;
    private float nextIncrease;
    public BoxCollider2D helicopterCollider;
    public BoxCollider2D helicopterTarget;
    private float invincibleDuration = 2.0f;
    private float invincibleEnd;
    private bool b=true;
    public HandReaction hand;
    public bool invincible = false;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponentInChildren<Animator>();
        vert = GetComponentInParent<VerticalMove>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if ((Time.time > nextIncrease) && (vert.speed < vert.maxSpeed))
        {
            vert.speed += 0.1f;
            nextIncrease = Time.time + 1f;

            
        }
        if (b&&(helicopterCollider.IsTouching(helicopterTarget)))
        {
            anim.SetTrigger("EatHelicopter");
            b = false;
        }

        if (Time.time > invincibleEnd)
        {
            anim.SetBool("Burn", false);
            invincible = false;
            hand.invincible = false;
            hand.anim.SetBool("Invincible", true);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            anim.SetTrigger("Eat");
        }

        if ((other.gameObject.tag == "Slower")&&(!invincible))
        {
            GetHit();
            hand.GetInvincible();
            invincible = true;
            hand.invincible = true;
        }

        //if (other.gameObject.name == "Helicopter")
        //{
        //    anim.SetTrigger("EatHelicopter");
        //}
    }

   

    public void GetHit()
    {
        vert.speed -= 0.5f;
        if (vert.speed < 0) vert.speed = 0;
        anim.SetTrigger("GetHit");
    }

    public void Burn()
    {
        vert.speed -= 0.5f;
        if (vert.speed < 0) vert.speed = 0;
        anim.SetTrigger("Burn");
        invincibleEnd = Time.time + invincibleDuration;
    }

}
