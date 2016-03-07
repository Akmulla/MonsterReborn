using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 movement=Vector2.zero;
    public float speed;
    public float rotationSpeed;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void FixedUpdate()
    {
        rb.velocity = movement;
    }
    void Move()
    {
        Touch myTouch;
        if (Input.touchCount > 0)
        {
            myTouch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(myTouch.position);
            touchPosition.z = 0;

            //transform.position = Vector3.Lerp(transform.position, touchPosition, speed);
            

            Vector3 moveDirection = touchPosition - transform.position;
            movement = moveDirection * speed;

            float angle = Mathf.Atan2(moveDirection.x, -moveDirection.y) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed);

        }
        else
        {
            movement = Vector2.zero;
        }
    }

    
}
