using UnityEngine;
using System.Collections;

public class SoldierReaction : MonoBehaviour
{
    [Header("Materials")]
    public Material m1;
    public Material m2;
    public Material m3;
    [Space(20)]
    public string currentState;
    public float rotationSpeed;
    public LayerMask handMask;

    private Transform monster;
    private Animator anim;
    private GameObject hand;
    private Collider2D handCollider;

    public float prepareDuration=2;
    private float prepareEnd;

    public float shootDuration=3;
    private float shootEnd;

    public float startDuration = 2;
    private float startEnd;

    private LineRenderer lineRenderer;
    private Transform shotSpawn;
    private Vector3 keepRotation;

    public Renderer renderer;
    public Collider2D collider;

    void Start ()
    {
        anim = GetComponentInChildren<Animator>();
        monster = GameObject.Find("Monster").transform;
        hand = GameObject.Find("Hand");
        handCollider = hand.GetComponent<Collider2D>();
        currentState = "Start";
        lineRenderer = GetComponent<LineRenderer>();
        shotSpawn = transform.FindChild("shotSpawn");
        startEnd = Time.time + startDuration;
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        lineRenderer.enabled = false;
        if (collider.IsTouching(handCollider))
        //if (Physics2D.IsTouching(collider, handCollider))
        {
            Panic();
        }
        else if (Time.time>startEnd)
        {
            anim.SetBool("Start", false);
            anim.SetBool("Panic", false);
            if ((currentState == "Prepare") || (currentState == "Shoot"))
            {
                if (currentState == "Prepare")
                {
                    Aim();
                    if (Time.time > prepareEnd)
                    {
                        StartShoot();
                    }
                }
                if (currentState == "Shoot")
                {
                    if (Time.time > shootEnd)
                    {
                        Run();
                    }
                    else
                    {
                        Shoot();
                    }
                }
            }
            else
            {
                if (transform.position.y < Edges.topEdge - 1)
                {
                    Run();
                }
                else
                {
                    Prepare();
                }
            }

        }
        
    }
    void Prepare()
    {
        prepareEnd = Time.time + prepareDuration;
        anim.SetBool("Prepare", true);
        currentState = "Prepare";
    }

    void StartShoot()
    {
        shootEnd = Time.time + shootDuration;
        anim.SetBool("Shoot", true);
        currentState = "Shoot";
        StartCoroutine(ShootAnimation());
    }

    void Shoot()
    {
        //Aim();
        Quaternion rot = Quaternion.Euler(-keepRotation);
        transform.rotation *= rot;

        RaycastHit2D hit = Physics2D.Raycast(shotSpawn.position, shotSpawn.position-transform.position,50,handMask);
        lineRenderer.enabled = true;
        lineRenderer.SetVertexCount(2);
        //lineRenderer.SetPosition(0, transform.position);
        //lineRenderer.SetPosition(1, shotSpawn.position);
        lineRenderer.SetPosition(0, shotSpawn.position);
        lineRenderer.SetPosition(1, shotSpawn.position-transform.up*10);
        if ((hit.collider != null) && (hit.collider.gameObject.name == "Hand"))
        {
            HandReaction hand = hit.collider.gameObject.GetComponent<HandReaction>();
            //hand.GetHit();
        }
    }

    void Run()
    {
        anim.SetBool("Prepare",false);
        anim.SetBool("Shoot", false);
        currentState = "Run";
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void Panic()
    {
        //if (!anim.GetBool("Panic"))
        //{
        //    anim.SetBool("Panic", true);
        //}

        //anim.SetBool("Panic", true);
        //currentState = "Panic";


        
        anim.SetBool("Panic", true);
        currentState = "Panic";
        anim.SetBool("Shoot", false);
        anim.SetBool("Prepare", false);
        anim.SetBool("Start", false);
        anim.SetBool("Run", false);
    }

    void FixedUpdate()
    {

    }

    void Aim()
    {
        //Vector3 moveDirection = hand.transform.position - transform.position;
        //float angle = Mathf.Atan2(moveDirection.x, -moveDirection.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed);

        Vector3 moveDirection = hand.transform.position - transform.position;
        float angle = Mathf.Atan2(moveDirection.x, -moveDirection.y) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed);
        keepRotation = transform.rotation.eulerAngles - newRotation.eulerAngles;
        transform.rotation = newRotation;
    }

    IEnumerator ShootAnimation()
    {
        renderer.material = m1;
        yield return new WaitForSeconds(0.3f);
        renderer.material = m2;
        yield return new WaitForSeconds(shootDuration-0.5f);
        renderer.material = m3;
        yield break;
    }
}
