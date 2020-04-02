using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChainSpawn : MonoBehaviour
{


    public GameObject link;
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
    // Start is called before the first frame update
    void Start()
    {
        goarray = new GameObject[250];
        drop = 0.1f;
        i = 0;
        j = linknumber;
        k = linknumber;
        iheight = this.transform.position.y;
        height = iheight;
        for (i=0; i < linknumber; i++)
        {
            height = height - drop;
            rotate = Quaternion.Euler(0, 90 * ((float)i+1f), 90);
            link.name = string.Format("chainLink{0}", j);
            go = Instantiate(link, new Vector3(this.transform.position.x, height, this.transform.position.z), rotate) as GameObject;
            goarray[j] = go;
            j--;
        }
    }
    void RaiseChain()
    {
        if (currentheight - iheight > drop)
        {
            transform.Translate(-drop, 0, 0, Space.Self);
            transform.Rotate(90, 0, 0, Space.Self);
            Destroy(goarray[k]);
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
            transform.Translate(drop, 0, 0, Space.Self);
            transform.Rotate(90, 0, 0, Space.Self);
            k++;
            rotate2 = goarray[k - 1].transform.rotation;
            rotate = this.transform.rotation;
            avrotate.x = (rotate2.x + (rotate.x)) / 2;
            avrotate.y = (rotate2.y + (rotate.y)) / 2;
            avrotate.z = (rotate2.z + (rotate.z)) / 2;
            avrotate.w = (rotate2.w + (rotate.w)) / 2;
            link.name = string.Format("chainLink{0}", k);
            go = Instantiate(link, insttran, rotate) as GameObject;
            go.transform.Rotate(-90, 0, 0, Space.Self);
            goarray[k] = go;
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        currentheight = this.transform.position.y;
        if (Input.GetKeyDown("e")) { keytimer = 0f; }
        if (Input.GetKeyDown("q")) { keytimer = 0f; }
        if (Input.GetKeyDown("w")) { keytimer = 0f; }
        if (Input.GetKeyDown("a")) { keytimer = 0f; }
        if (Input.GetKeyDown("s")) { keytimer = 0f; }
        if (Input.GetKeyDown("d")) { keytimer = 0f; }
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
        if (Input.GetKey("d")) 
        { 
            if (keytimer < ramptime)
            {
                transform.Translate(Time.fixedDeltaTime * rlspeed * keytimer / ramptime,0, 0, Space.World);
            }
            else
            {
                transform.Translate(Time.fixedDeltaTime * rlspeed,0, 0, Space.World);
            }
        }
        if (Input.GetKey("a"))
        {
            if (keytimer < ramptime)
            {
                transform.Translate(-Time.fixedDeltaTime * rlspeed * keytimer / ramptime, 0, 0, Space.World);
            }
            else
            {
                transform.Translate(-Time.fixedDeltaTime * rlspeed, 0, 0, Space.World);
            }
        }
        if (Input.GetKey("w"))
        {
            if (keytimer < ramptime)
            {
                transform.Translate(0, 0, Time.fixedDeltaTime * rlspeed * keytimer / ramptime, Space.World);
            }
            else
            {
                transform.Translate(0, 0, Time.fixedDeltaTime * rlspeed, Space.World);
            }
        }
        if (Input.GetKey("s"))
        {
            if (keytimer < ramptime)
            {
                transform.Translate(0, 0, -Time.fixedDeltaTime * rlspeed * keytimer / ramptime, Space.World);
            }
            else
            {
                transform.Translate(0, 0, -Time.fixedDeltaTime * rlspeed, Space.World);
            }
        }
        keytimer += Time.fixedDeltaTime;
    }
}
