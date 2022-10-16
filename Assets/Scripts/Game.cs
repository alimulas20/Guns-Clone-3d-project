using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public SingleCube s_cube;
    public DoubleCube d_cube;
    public TripleHorizontal t_hor;
    public TripleVertical t_ver;
    public Barrels barrels;
    public Plane plane;
    public Gun gun;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(s_cube);
    }

     void Update()
    {
        
    }

    void LevelCreator()
    {

    }
}
