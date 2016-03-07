using UnityEngine;
using System.Collections;

public class Scale480x800 : MonoBehaviour
{


    // Use this for initialization
    void Awake()
    {
        //Debug.Log(Screen.height);
        //Debug.Log(Screen.width);
        //float ratio = (float)Screen.height / Screen.width;
        //float target = 480 * ratio;
        //float ortSize = target / 200f;
        //Camera.main.orthographicSize = ortSize;

        
        float ortSize = 800 / 200f;
        Camera.main.orthographicSize = ortSize;
    }

}
