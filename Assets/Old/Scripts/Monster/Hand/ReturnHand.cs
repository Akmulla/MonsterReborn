using UnityEngine;
using System.Collections;

public class ReturnHand : MonoBehaviour
{
    void Update()
    {
        if ((transform.position.x<Edges.leftEdge)|| (transform.position.x > Edges.rightEdge)
                || (transform.position.y < Edges.botEdge)|| (transform.position.y > Edges.topEdge))
        {
            //transform.position = new Vector2((Edges.rightEdge - Edges.leftEdge) / 2, (Edges.topEdge - Edges.botEdge) / 2);

            transform.position = new Vector2(Camera.main.gameObject.transform.position.x, Camera.main.gameObject.transform.position.y);
        }
    }
}
