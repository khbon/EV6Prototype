using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EV6 : Car
{
    GameObject[] initTyre_array;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        initTyre_array = GameObject.FindGameObjectsWithTag("Tyre");

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
