using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    float velocity=-3f;
    bool start = false;
    bool left =false;
    bool right = false;
    Vector2 pos = new Vector2(0, 0);
    Vector3 leftMax;
    Vector3 rigthMax;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        leftMax = new Vector3(-.8f, transform.position.y, transform.position.z);
        rigthMax = new Vector3(1, transform.position.y, transform.position.z);
        if (start || Input.GetMouseButton(0))
        {
            transform.Translate(0,0, Time.deltaTime * velocity);
            start = true;
            if (Input.touchCount > 0)
            {
                Touch finger = Input.GetTouch(0);
                if (finger.deltaPosition.x > 20f)
                {
                    left = false;
                    right = true;
                }
                if (finger.deltaPosition.x < -20f)
                {
                    left = true;
                    right = false;
                }
                if (left)
                {
                    transform.position = Vector3.Lerp(transform.position,leftMax,5*Time.deltaTime);
                    //sol 800 sað 1000
                }
                if (right)
                {
                    transform.position = Vector3.Lerp(transform.position, rigthMax, 5 * Time.deltaTime);
                    //sol 800 sað 1000
                }
            }
        }
       
    }
    public float getDistance()
    {
        return transform.position.z;
    }
    
}
