﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class height_constraint : MonoBehaviour
{
    public GameObject connGO;
    private Vector3 vector;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vector = connGO.transform.position - this.transform.position;
        if(vector.magnitude > offset)
        {
            this.transform.position += vector.normalized * (vector.magnitude - offset);
        }
    }
}