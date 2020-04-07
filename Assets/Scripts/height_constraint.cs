using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class height_constraint : MonoBehaviour
{
    public GameObject connGO;
    private Vector3 vector;
    private Vector3 velocity;
    private Vector3 velocityconn;
    private Vector3 oldpos;
    private Vector3 oldconnpos;
    public float velfactor;
    public float gravfactor;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        oldpos = this.transform.position;
        oldconnpos = connGO.transform.position;

        this.transform.position -= new Vector3(0f, gravfactor, 0);

        this.transform.position += (velocity*0.0f + (velocityconn * velfactor)) * Time.fixedDeltaTime;
        vector = connGO.transform.position - this.transform.position;
        if(vector.magnitude > 0f)
        {
            this.transform.position += vector.normalized * (vector.magnitude - (offset));
        }

        velocity = (this.transform.position - oldpos) / Time.fixedDeltaTime;
        velocityconn = (connGO.transform.position - oldconnpos) / Time.fixedDeltaTime;
    }   
}