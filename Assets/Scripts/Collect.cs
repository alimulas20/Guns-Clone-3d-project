using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    // Start is called before the first frame update
    bool collected = false;
    Vector2 position;
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
    public bool isCollected()
    {
        return collected;
    }
    public void put(Vector2 pos)
    {
        position = pos;
    }

}
