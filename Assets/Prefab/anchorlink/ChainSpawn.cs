using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChainSpawn : MonoBehaviour
{


    public GameObject link;
    public GameObject hook;
    private Quaternion rotate;
    private Quaternion rotate2;
    private Quaternion avrotate;
    private float iheight;
    private float height;
    private float currentheight;
    public int linknumber;
    public float rlspeed;
    private GameObject go;
    private GameObject[] goarray;
    private int i;
    private int j;
    private int k;
    private Vector3 insttran;
    private float drop;
    private float keytimer;
    public float ramptime;
    private SpringJoint gosj;
    private Rigidbody gorb;
    private height_constraint gohc;
    // Start is called before the first frame update
    void Start()
    {
        goarray = new GameObject[250];
        drop = 0.117f;
        i = 0;
        j = linknumber;
        k = linknumber;
        iheight = this.transform.position.y;
        height = iheight;
        for (i=0; i < linknumber; i++)
        {
            height -= drop;
            rotate = Quaternion.Euler(0, 90 * ((float)i+1f), 90);
            link.name = string.Format("chainLink{0}", j);
            go = Instantiate(link, new Vector3(this.transform.position.x, height, this.transform.position.z), rotate) as GameObject;
            gohc = go.GetComponent(typeof(height_constraint)) as height_constraint;
            if (j == linknumber) {
                gohc.connGO = this.gameObject;
            }
            else
            {
                gohc.connGO = goarray[j + 1];
            }
            gohc.offset = 0.125f;
            goarray[j] = go;
            j--;
        }
        rotate = Quaternion.Euler(-90, 0, 0);
        go = Instantiate(hook, new Vector3(this.transform.position.x, height - 0.1935482f, this.transform.position.z), rotate) as GameObject;
        gohc = go.GetComponent(typeof(height_constraint)) as height_constraint;
        gohc.connGO = goarray[1];
        gohc.offset = 0.25f;
    }
    void RaiseChain()
    {
        if (currentheight - iheight > drop)
        {
            transform.Translate(-drop, 0, 0, Space.Self);
            transform.Rotate(90, 0, 0, Space.Self);
            Destroy(goarray[k]);
            gohc = goarray[k - 1].GetComponent(typeof(height_constraint)) as height_constraint;
            gohc.connGO = this.gameObject;
            gohc.offset = 0.12f;
            k--;
        }
    }
    void LowerChain()
    {
        if (currentheight - iheight < -drop)
        {
            insttran.x = this.transform.position.x;
            insttran.y = this.transform.position.y;
            insttran.z = this.transform.position.z;
            rotate = this.transform.rotation;
            k++;
            avrotate.x = (rotate2.x + (rotate.x)) / 2;
            avrotate.y = (rotate2.y + (rotate.y)) / 2;
            avrotate.z = (rotate2.z + (rotate.z)) / 2;
            avrotate.w = (rotate2.w + (rotate.w)) / 2;
            link.name = string.Format("chainLink{0}", k);
            go = Instantiate(link, insttran, rotate) as GameObject;
            goarray[k] = go;
            gohc = goarray[k - 1].GetComponent(typeof(height_constraint)) as height_constraint;
            gohc.connGO = go.gameObject;
            gohc.offset = 0.12f;
            transform.Translate(drop, 0, 0, Space.Self);
            transform.Rotate(90, 0, 0, Space.Self);
            gohc = goarray[k].GetComponent(typeof(height_constraint)) as height_constraint;
            gohc.connGO = this.gameObject;
            gohc.offset = 0.12f;
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        currentheight = this.transform.position.y;
        if (Input.GetKeyDown("e")) { keytimer = 0f; }
        if (Input.GetKeyDown("q")) { keytimer = 0f; }
        if (Input.GetKey("e"))
        {
            if(keytimer < ramptime) {
                transform.Translate(0, Time.fixedDeltaTime * rlspeed * keytimer / ramptime, 0, Space.World);
            }
            else
            {
                transform.Translate(0, Time.fixedDeltaTime * rlspeed, 0, Space.World);
            }
            RaiseChain();
        }
        if (Input.GetKey("q"))
        {
            if (keytimer < ramptime)
            {
                transform.Translate(0, -Time.fixedDeltaTime * rlspeed * keytimer / ramptime, 0, Space.World);
            }
            else
            {
                transform.Translate(0, -Time.fixedDeltaTime * rlspeed, 0, Space.World);
            }
            LowerChain();
        }
        keytimer += Time.fixedDeltaTime;
    }
}
