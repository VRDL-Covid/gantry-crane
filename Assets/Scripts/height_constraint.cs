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
    private Vector3 oldvel;
    private Vector3 oldWorldPos;
    private Vector3 oldconnpos;
    private Vector3 nextconnpos;
    private Vector3 nextvel;
    private Vector3 gravity;
    public float velfactor;
    public float gravfactor;
    public float offset;
    private float dot;
    private float xrot;
    private float yrot;
    private float zrot;
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
        oldvel = CS.velarray[i]; 
        angleWorld = Vector3.Dot(vectorWorld.normalized, Vector3.down);
        anglerad = Mathf.Acos(angleWorld);
        if (i != 1)
        {
            nextvel = CS.velarray[i-1];
        }
        else { nextvel = Vector3.zero; }
        if (oldvel.y >= 0f) { oldvel.y = 0f; }
        if (i != k)
        {
            oldconnpos = CS.posnarray[i + 1];
        } 
        else
        {
            oldconnpos = anchor.transform.position;
        }
        vectorWorld = oldconnpos - oldpos;
        gravity = 1f * 9.81f * Time.fixedDeltaTime * Mathf.Sin(anglerad) * Vector3.down;
        vector = oldpos + gravity + (velocityConn * 0.8f + oldvel * .1f + nextvel * 0.1f) * Time.fixedDeltaTime;
        this.transform.position = ((-oldconnpos + vector).normalized * offset)+oldconnpos;

        CS.posnarray[i] = this.transform.position;

        velocity = (this.transform.position - oldpos) / Time.fixedDeltaTime;
        
        yrot = Mathf.Atan(this.gameObject.transform.localPosition.z / this.gameObject.transform.localPosition.x);
        zrot = Mathf.Atan(this.gameObject.transform.localPosition.y / this.gameObject.transform.localPosition.x);
        transform.localRotation= Quaternion.Euler(90f, (yrot * 180f / Mathf.PI), (zrot * 180f / Mathf.PI));

        return velocity;

    }
    public void RotationUpdate(int i, int k, GameObject anchor)
    {
        transform.position = CS.posnarray[i];
        if (i != k)
        {
            oldconnpos = CS.posnarray[i + 1];
        }
        else
        {
            oldconnpos = anchor.transform.position;
        }
        if (i != 1)
        {
            nextconnpos = CS.posnarray[i - 1];
        }
        else
        {
            nextconnpos = transform.position;
        }

        vectorWorld = oldconnpos - nextconnpos;

        xrot = Mathf.Atan(vectorWorld.z / vectorWorld.y);
        zrot = -Mathf.Atan(vectorWorld.x / vectorWorld.y);
        transform.rotation = Quaternion.Euler((xrot * 180f / Mathf.PI), 90 * ((Mathf.Pow((-1f), (float)i) + 1f) / 2f), (zrot * 180f / Mathf.PI)+90f);
    }
}