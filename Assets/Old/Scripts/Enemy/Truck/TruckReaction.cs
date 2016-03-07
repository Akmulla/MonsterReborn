using UnityEngine;
using System.Collections;

public class TruckReaction : MonoBehaviour
{
    private Animator anim;

	
	void Start ()
    {
        anim = GetComponentInChildren<Animator>();
	}
	
	
	void Update ()
    {
	    if (Vector2.Angle(-transform.up,Vector2.down)>30)
        {
            Destroy(gameObject);
        }
	}
}
