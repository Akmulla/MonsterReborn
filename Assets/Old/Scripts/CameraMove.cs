using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.up * speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.Translate(Vector3.up *speed* Time.deltaTime);

    }
}
