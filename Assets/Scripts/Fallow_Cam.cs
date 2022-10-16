using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallow_Cam : MonoBehaviour
{
    public GameObject hang_object;
    Vector3 gap;
    // Start is called before the first frame update
    void Start()
    {
        gap = transform.position - hang_object.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = gap + hang_object.transform.position;
    }
}
