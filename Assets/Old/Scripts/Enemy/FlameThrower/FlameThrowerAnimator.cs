using UnityEngine;
using System.Collections;

public class FlameThrowerAnimator : MonoBehaviour
{
    private FlameThrowerController contr;
    private Animator anim;
	// Use this for initialization
	void Start ()
    {
        contr = GetComponent<FlameThrowerController>();
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    switch (contr.currentState)
        {
            case "Start":
                anim.SetBool("Start", true);
                anim.SetBool("Panic", false);
                anim.SetBool("Run", false);
                anim.SetBool("Prepare", false);
                anim.SetBool("Shoot", false);
                break;
            case "Panic":
                if (!anim.GetBool("Panic"))
                {
                    anim.SetBool("Panic", true);
                }
                anim.SetBool("Start", false);
                
                anim.SetBool("Run", false);
                anim.SetBool("Prepare", false);
                anim.SetBool("Shoot", false);
                break;
            case "Run":
                anim.SetBool("Start", false);
                anim.SetBool("Panic", false);
                anim.SetBool("Run", true);
                anim.SetBool("Prepare", false);
                anim.SetBool("Shoot", false);
                break;
            case "Prepare":
                anim.SetBool("Start", false);
                anim.SetBool("Panic", false);
                anim.SetBool("Run", false);
                anim.SetBool("Prepare", true);
                anim.SetBool("Shoot", false);
                break;
            case "Shoot":
                anim.SetBool("Start", false);
                anim.SetBool("Panic", false);
                anim.SetBool("Run", false);
                anim.SetBool("Prepare", false);
                anim.SetBool("Shoot", true);
                break;
        }
	}
}
