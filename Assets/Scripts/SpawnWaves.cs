using UnityEngine;
using System.Collections;

public class SpawnWaves : MonoBehaviour
{
    private PoolManager poolManager;
    [Header("Pool")]
    private Pool citizenPool;
    private Pool truckPool;
    private Pool boxPool;
    private Pool dangerZonePool;
    [Header("Wave Rates")]
    public float citizenWaveRate;
    public float truckWaveRate;
    public float boxWaveRate;
    public float dangerZoneWaveRate;
    [Space(20)]
    public float startWait;
    
    void Start ()
    {

        poolManager = GameObject.Find("PoolManager").GetComponent<PoolManager>();
        citizenPool = poolManager.GetPool("citizen");
        truckPool = poolManager.GetPool("truck");
        boxPool = poolManager.GetPool("box");
        dangerZonePool= poolManager.GetPool("dangerZone");
        StartCoroutine(SpawnCitizen());
        //StartCoroutine(SpawnSoldier());
        //StartCoroutine(SpawnTruck());
        StartCoroutine(SpawnTruck());
        StartCoroutine(SpawnBox());
        StartCoroutine(SpawnDangerZone());
    }
	

    IEnumerator SpawnCitizen()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0f, 2f));
            Vector2 spawnPosition = new Vector2(Random.Range((float)Edges.leftEdge+1.0f, (float)Edges.rightEdge-1.0f), Edges.topEdge+1);
            //Instantiate(citizen, spawnPosition, Quaternion.identity);
            citizenPool.Activate(spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(citizenWaveRate);
        }
    }

    //IEnumerator SpawnSoldier()
    //{
    //    yield return new WaitForSeconds(startWait);
    //    while (true)
    //    {
    //        Vector2 spawnPosition = new Vector2(Random.Range((float)Edges.leftEdge, (float)Edges.rightEdge), Edges.topEdge);
    //        Instantiate(soldier, spawnPosition, Quaternion.identity);
    //        yield return new WaitForSeconds(soldierWaveRate);
    //    }
    //}
    //IEnumerator SpawnTruck()
    //{
    //    yield return new WaitForSeconds(startWait);
    //    while (true)
    //    {
    //        Vector2 spawnPosition = new Vector2(Random.Range((float)Edges.leftEdge, (float)Edges.rightEdge), Edges.topEdge);
    //        Instantiate(truck, spawnPosition, Quaternion.identity);
    //        yield return new WaitForSeconds(truckWaveRate);
    //    }
    //}

    IEnumerator SpawnTruck()
    {
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        while (true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range((float)Edges.leftEdge, (float)Edges.rightEdge), Edges.topEdge+1);
            //Instantiate(flameThrower, spawnPosition, Quaternion.identity);
            truckPool.Activate(spawnPosition, Quaternion.Euler(new Vector3(0f,0f,Random.Range(0f,360f))));
            yield return new WaitForSeconds(truckWaveRate);
        }
    }

    IEnumerator SpawnBox()
    {
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        while (true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range((float)Edges.leftEdge, (float)Edges.rightEdge), Edges.topEdge+1);
            //Instantiate(flameThrower, spawnPosition, Quaternion.identity);
            boxPool.Activate(spawnPosition, Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f))));
            yield return new WaitForSeconds(boxWaveRate);
        }
    }

    IEnumerator SpawnDangerZone()
    {
        yield return new WaitForSeconds(Random.Range(0f,2f));
        while (true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range((float)Edges.leftEdge, (float)Edges.rightEdge), Edges.topEdge+1);
            //Instantiate(flameThrower, spawnPosition, Quaternion.identity);
            dangerZonePool.Activate(spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(dangerZoneWaveRate);
        }
    }


}
