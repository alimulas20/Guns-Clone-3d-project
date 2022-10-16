using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int type;
    public float[,] pos = { { 0, -2.034f }, { 0, 2f },{ 0, 2f }, { 0, 4f }, { 0, 2f }, { 0, 2f } };
    // Start is called before the first frame update
    bool collected = false;
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
            }
           
        }
        if(other.gameObject.tag == "Saw")
        {
           
            if (gameObject.
                tag == "Gun")
            {
                transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x, transform.position.y, transform.position.z -1),5*Time.deltaTime);
            }
            else
            {
                transform.SetParent(transform);
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
}
