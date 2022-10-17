using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public Bullet bullet;
    public int type;
    public float[,] pos = { { 0, -2.034f }, { 0, 2f },{ 0, 2f }, { 0, 4f }, { 0, 2f }, { 0, 2f } };
    // Start is called before the first frame update
    bool collected = false;
    float shotSpeed = 1;
    bool startShot = false;
    bool stopShot;
    void Start()
    {
        if (type == 0)
        {
            collected = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "SingleCube"|| other.gameObject.tag == "SingleCubeb" || other.gameObject.tag == "TripleVer" || other.gameObject.tag == "TripleHor" || other.gameObject.tag == "DoubleCube")
        {
            if (!other.GetComponent<Collector>().isCollected())
            {
                int coltype = other.GetComponent<Collector>().type;
                other.gameObject.transform.parent = this.transform;
                if (type == 0)
                {
                    float[] newPos = { pos[coltype, 0] + pos[type, 0], pos[coltype, 1] + pos[type, 1] };
                    other.gameObject.GetComponent<Collector>().setPos(newPos);
                }else if (type == 5)
                {
                    float[] newPos = { pos[coltype, 0] , pos[coltype, 1] -1 };
                    other.gameObject.GetComponent<Collector>().setPos(newPos);
                }
                else
                {
                    float[] newPos = { pos[coltype, 0] , pos[coltype, 1]  };
                    other.gameObject.GetComponent<Collector>().setPos(newPos);
                }
                
                other.gameObject.GetComponent<Collector>().collect();

                
                    GetComponent<Collector>().stopShoot();
                other.GetComponent<Collector>().startShoot();


                /////parçaya özel type kontrolü yaparak ateþleme ayarlarý düzenlenecek
            }
           
        }
        if(other.gameObject.tag == "Saw")
        {
           
            if (gameObject.tag == "Gun")
            {
                
                GetComponent<Gun>().SawCrash();
            }
            else
            {

                Crash();
            }
        }
    }
    public void setPos(float[] newPos)
    {
        
        transform.localPosition = new Vector3(newPos[0], 0, newPos[1]);
    }
    public void collect()
    {
        collected = true;
    }
    public bool isCollected()
    {
        return collected;
    }
    public void Crash()
    {
        ///her kutuya özel collider eklenerek parça parça kýrýlma eklenecek
        transform.parent = null;
    }
    IEnumerator shooter()
    {
        
        while (transform.position.z < 35)
        {
            
                yield return new WaitForSeconds(shotSpeed / 3f);
            if (!stopShot)
            {
                Bullet newBullet = Instantiate(bullet);
                if (type == 0)
                    newBullet.transform.position = transform.position + new Vector3(-0.15f, 0, .4f);
                else
                {
                    newBullet.transform.position = transform.position + new Vector3(0, 0, .4f);
                }
            }
           //bullet mezili ayarlanacak
        }

    }
    public float getRate()
    {
        return shotSpeed;
    }
    public void setRate(float rate)
    {
        shotSpeed = rate;
    }
    public void stopShoot()
    {
        stopShot = true;
        StopCoroutine(shooter());
    }
    public void startShoot()
    {
        StartCoroutine(shooter());
    }

}
