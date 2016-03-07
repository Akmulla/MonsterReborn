using UnityEngine;
using System.Collections;

public class LvlButton : MonoBehaviour {
    private BoxCollider2D thisCollider;
    public string levelToGo;

	// Use this for initialization
	void Start ()
    {
        thisCollider = GetComponent<BoxCollider2D>();
        Debug.Log(thisCollider);
	}

    // Update is called once per frame
    void Update()
    {
        
        Touch myTouch;
        if (Input.touchCount > 0)
        {
            myTouch = Input.GetTouch(0);

            if (myTouch.phase == TouchPhase.Began)
            {
                
                Vector3 touchStart = Camera.main.ScreenToWorldPoint(myTouch.position);
                touchStart.z = -1;
                //Debug.DrawLine(touchStart, touchStart * 2, Color.red, 10);

                //    Collider2D outHit = Physics2D.OverlapPoint(touchStart);

                //    if (outHit == thisCollider)
                //    {
                //        Debug.Log(this.levelToGo);

                //        Application.LoadLevel(this.levelToGo);

                //    }


                //Ray screenRay = Camera.main.ScreenPointToRay(myTouch.position);

                //RaycastHit hit;
                //if (Physics.Raycast(screenRay, out hit))
                //{
                //    //print("User tapped on game object " + hit.collider.gameObject.name);
                //    if (hit.collider.gameObject.name=="Button1")
                //    {
                //        Debug.Log("sfdbdf");
                //        Application.LoadLevel(this.levelToGo);
                //    }
                //    if (hit.collider.gameObject.name == "Button2")
                //    {
                //        Debug.Log("asd");
                //        Application.LoadLevel(this.levelToGo);
                //    }
                //}
                
                if (thisCollider.bounds.Contains(touchStart))
                {
                    Application.LoadLevel(levelToGo);
                }

                //if (thisCollider==Physics2D.OverlapArea(touchStart,touchStart*2))
                //{
                //    Debug.Log(thisCollider);
                //    Application.LoadLevel(levelToGo);
                //}
            }


            
            


        }
    }
}
