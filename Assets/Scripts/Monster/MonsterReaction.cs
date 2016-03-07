using UnityEngine;
using System.Collections;

public class MonsterReaction : MonoBehaviour
{
    private Animator anim;
    private VerticalMove vert;
    private float nextIncrease;
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

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            anim.SetTrigger("Eat");
        }

        if (other.gameObject.tag == "Slower")
        {
            GetHit();
            vert.speed -= 0.5f;
            if (vert.speed < 0) vert.speed = 0;
        }
    }

   

    public void GetHit()
    {

        anim.SetTrigger("GetHit");
    }
}
