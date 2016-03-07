using UnityEngine;
using System.Collections;

public class FireShotReaction : MonoBehaviour
{
    public Pool fireShotPool;
    public Pool fireExplosionPool;

    public GameObject explosion;

    void Start()
    {
        fireShotPool = GameObject.Find("FireShotPool").GetComponent<Pool>();
        fireExplosionPool = GameObject.Find("FireExplosionPool").GetComponent<Pool>();
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Hand")
        {
            //Instantiate(explosion, transform.position, transform.rotation);
            fireExplosionPool.Activate(transform.position, transform.rotation);
            fireShotPool.Deactivate(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name=="Destroy")
        {
            fireShotPool.Deactivate(gameObject);
        }
    }

}
