using UnityEngine;
using System.Collections;

public class FlameThrowerController : MonoBehaviour
{
    //public Pool fireShotPool;
    public float shotRange;
    public string currentState;
    public float speed;
    public GameObject shot;
    public float shotSpeed;
    public LayerMask handMask;

    private Rigidbody2D rb;
    private Transform monster;

    public float prepareDuration = 2;
    private float prepareEnd;

    public float shootDuration = 3;
    private float shootEnd;

    public float startDuration = 2;
    private float startEnd;
    public Collider2D collider;
    private GameObject hand;
    private Collider2D handCollider;
    private Collider2D shotCollider;
    private Animator shotAnim;

    private Transform shotSpawn;
    private Transform shotEnd;
    private LineRenderer lineRenderer;

    // Use this for initialization
    void Start()
    {
        shotSpawn = gameObject.transform.FindChild("ShotSpawn");
        rb = GetComponent<Rigidbody2D>();
        startEnd = Time.time + startDuration;
        collider = GetComponent<Collider2D>();
        hand = GameObject.Find("Hand");
        handCollider = hand.GetComponent<Collider2D>();
        currentState = "Start";
        //fireShotPool = GameObject.Find("FireShotPool").GetComponent<Pool>();
        lineRenderer = GetComponent<LineRenderer>();
        shotEnd= gameObject.transform.FindChild("ShotEnd");
        shotCollider = shotEnd.GetComponent<Collider2D>();
        shotAnim=shotEnd.GetComponent<Animator>();
}

    // Update is called once per frame
    void Update()
    {
        
        //shotAnim.SetBool("Smoke", false);
        shotEnd.GetComponent<SpriteRenderer>().sprite = null;
        
        if (currentState!="Shoot")
        {
            shotEnd.position = shotSpawn.position;
            lineRenderer.enabled = false;
            shotEnd.gameObject.SetActive(false);
            
        }
        if (collider.IsTouching(handCollider))
        //if (Physics2D.IsTouching(collider, handCollider))
        {
            Panic();
        }
        else if (Time.time > startEnd)
        {
            if ((currentState == "Prepare") || (currentState == "Shoot"))
            {
                if (currentState == "Prepare")
                {

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
                if (transform.position.y < Edges.topEdge)
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
        currentState = "Prepare";
    }

    void StartShoot()
    {
        shootEnd = Time.time + shootDuration;
        currentState = "Shoot";
        shotEnd.gameObject.SetActive(true);
        //StartCoroutine(CreateShot());
    }

    void Shoot()
    {
        
        RaycastHit2D hit;
        Ray ray = new Ray(shotSpawn.position, -shotSpawn.transform.up);
        hit = Physics2D.Raycast(shotSpawn.position, -shotSpawn.transform.up, Vector2.Distance(shotEnd.position, shotSpawn.position), handMask);
        //
        if ((hit.collider != null)&&(hit.collider.gameObject.name=="Hand"))
        {
            shotEnd.position = hit.point;
            
        }
        else
        if ((hit.collider != null) && (hit.collider.gameObject.name == "Monster"))
        {
            shotEnd.position = hit.point;
            hit.collider.gameObject.GetComponent<MonsterReaction>().GetHit();
        }
        //Debug.Log(hit.collider);
        lineRenderer.enabled = true;
        lineRenderer.SetVertexCount(2);
        lineRenderer.SetPosition(0, shotSpawn.position);
        lineRenderer.SetPosition(1, shotEnd.position);
        Rigidbody2D rb2 = shotEnd.GetComponent<Rigidbody2D>();
        
        if ((Vector2.Distance(shotEnd.position, shotSpawn.position) < shotRange)&&(!Physics2D.IsTouching(shotCollider,handCollider)))
        {
            rb2.velocity = -shotEnd.transform.up * shotSpeed;
            //shotEnd.transform.Translate(-shotEnd.transform.up * Time.deltaTime*shotSpeed);
        }
        else
        {
            shotAnim.SetBool("Smoke", true);
            rb2.velocity = Vector2.zero;
        }

        //Debug.Log(rb2.velocity);
    }

    void Run()
    {
        currentState = "Run";
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    }

    void Panic()
    {
        currentState = "Panic";
    }

    void FixedUpdate()
    {
        if ((currentState == "Panic") || (currentState == "Prepare") || (currentState == "Start") || (currentState == "Shoot"))
        {
            rb.velocity = Vector2.zero;
        }
        else
        if (currentState == "Run")
        {
            rb.velocity = Vector2.up * speed;
        }
    }

    //IEnumerator CreateShot()
    //{
    //    while (currentState=="Shoot")
    //    {
    //        Vector2 spawnPosition = shotSpawn.position + transform.right*Random.Range(-0.1f,0.1f);
    //        //GameObject createdShot = (GameObject)Instantiate(shot, spawnPosition, Quaternion.identity);
    //        //createdShot.GetComponent<Rigidbody2D>().velocity = -transform.up * shotSpeed;

    //        GameObject createdShot = fireShotPool.Activate(spawnPosition, Quaternion.identity);
    //        createdShot.GetComponent<Rigidbody2D>().velocity = -transform.up * shotSpeed;

    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}






}
