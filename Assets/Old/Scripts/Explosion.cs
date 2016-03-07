using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(DestroyExplosion());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
