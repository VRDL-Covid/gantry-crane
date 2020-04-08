using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class height_constraint : MonoBehaviour
{
    public GameObject connGO;
    public int k;
    private Vector3 vector;
    private Vector3 vectorWorld;
    public Vector3 velocity;
    public Vector3 velocityConn;
    private Vector3 oldpos;
    private Vector3 oldWorldPos;
    private Vector3 oldconnpos;
    private Vector3 gravity;
    public float velfactor;
    public float gravfactor;
    public float offset;
    private float dot;
    private float anglerad;
    private float angledeg;
    private float angledegold;
    private float anglecur;
    private float anglediff;
    private float angleWorld;
    private ChainSpawn CS;
    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per 
    public Vector3 PositionUpdate(Vector3 velocityConn, int i,int k, GameObject anchor)
    {
        CS = anchor.GetComponent(typeof(ChainSpawn)) as ChainSpawn;
        oldpos = CS.posnarray[i];
        if (i != k)
        {
            oldconnpos = CS.posnarray[i + 1];
        } 
        else
        {
            oldconnpos = anchor.transform.position;
        }
        vectorWorld = oldconnpos - oldpos;
        angleWorld = Vector3.Dot(vectorWorld.normalized, Vector3.down);
        anglerad = Mathf.Acos(angleWorld);
        gravity = 0.1f * 9.81f * Time.fixedDeltaTime * Mathf.Sin(anglerad) * Vector3.down;
        vector = oldpos + gravity + velocityConn*Time.fixedDeltaTime*1f;
        this.transform.position = ((-oldconnpos + vector).normalized * offset)+oldconnpos;

        CS.posnarray[i] = this.transform.position;

        velocity = (this.transform.position - oldpos) / Time.fixedDeltaTime;
        
        //anglerad = Mathf.Acos(dot);
        angledeg = (anglerad * 180f / Mathf.PI) - 90f;
        anglecur = this.transform.rotation.eulerAngles.z;
        anglediff = -anglecur + angledeg;
        transform.Rotate(0, 0, anglediff, Space.Self);

        return velocity;

        //oldpos = this.transform.position;
        //oldconnpos = connGO.transform.position;
        //
        //vectorWorld = oldconnpos - oldpos;
        //angleWorld = Vector3.Dot(vectorWorld.normalized, Vector3.up);
        //gravity = 9.81f * Time.fixedDeltaTime*Mathf.Sin(Mathf.Acos(angleWorld))*Vector3.down;
        //vector = this.transform.position;
        ////vector -= new Vector3(9.81f * Time.fixedDeltaTime, 0,0);
        //vector += gravity;
        ////vector += vectorWorld.normalized * velocityconn.magnitude;
        ////vector += (velocity * Time.fixedDeltaTime) * (float)(1-0.8);
        ////vector = connGO.transform.position - this.transform.localPosition;
        //this.transform.position = vector.normalized * (vector.magnitude - (offset));
        ////this.transform.localPosition = vector.normalized * ((offset));
        //
        //
        //velocity = (this.transform.position - oldpos) / Time.fixedDeltaTime;
        //velocityconn = (connGO.transform.position - oldconnpos) / Time.fixedDeltaTime;
        //angledegold = angledeg;
    }
}