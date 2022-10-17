using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public Bullet bullet;
    float velocity=-3f;
    bool start = false;
    bool left =false;
    bool right = false;
    Vector2 pos = new Vector2(0, 0);
    Vector3 leftMax;
    Vector3 rigthMax;
    bool wait = false;
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
            if (!start)
                GetComponent<Collector>().startShoot();
            if(!wait)
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
        if (transform.position.z > 35)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public float getDistance()
    {
        return transform.position.z;
    }
    public void SawCrash()
    {
        if(!wait)
        StartCoroutine(stoper());
    }
    IEnumerator stoper()
    {
        wait = true;
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 0, -3), Time.deltaTime*5 );
        yield return new WaitForSeconds(1f);
        wait = false;
    }
    
}
