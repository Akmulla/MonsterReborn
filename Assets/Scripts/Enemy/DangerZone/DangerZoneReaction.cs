using UnityEngine;
using System.Collections;

public class DangerZoneReaction : MonoBehaviour
{
    private Animator anim;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Hand")
        {
            if (!other.gameObject.GetComponent<HandReaction>().invincible)
            {
                anim.SetTrigger("Boom");
            }
        }
    }

}
