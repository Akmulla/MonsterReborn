using UnityEngine;
using System.Collections;

public class PoolManager : MonoBehaviour
{
    public Pool citizenPool;
    
    public Pool truckPool;

    public Pool boxPool;

    public Pool dangerZonePool;

    // Use this for initialization
    void Start ()
    {
        
    }

    public Pool GetPool(string name)
    {

        switch (name)
        {
            case "citizen":
                return citizenPool;
            case "truck":
                return truckPool;
            case "box":
                return boxPool;
            case "dangerZone":
                return dangerZonePool;
            default:
                return null;
        }
        
    }

    void Update()
    {
        
    }
}
