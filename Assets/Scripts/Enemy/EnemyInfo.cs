using UnityEngine;
using System.Collections;

public class EnemyInfo : MonoBehaviour
{
    public string name;
    public Pool pool;

    void Awake()
    {
        pool = GameObject.Find("PoolManager").GetComponent<PoolManager>().GetPool(name);
    }

}
