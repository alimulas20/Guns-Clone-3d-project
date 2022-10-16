using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleVertical : MonoBehaviour
{
    bool collected;
    Vector2 pos = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void collect()
    {
        collected = true;
    }
    public Vector2 getPos()
    {
        return pos;
    }
    public void setPos(Vector2 newPos)
    {
        pos = newPos;
        transform.localPosition = new Vector3(newPos.x, 0, newPos.y);
    }
}
