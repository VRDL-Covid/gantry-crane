using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChainSpawn : MonoBehaviour
{


    public GameObject link;
    public GameObject hook;
    private Quaternion rotate;
    private Quaternion rotate2;
    private float height0;
    private float x0;
    private float z0;
    private Quaternion avrotate;
    private float iheight;
    private float height;
    private float currentheight;
    private float heighttracked;
    public int linknumber;
    public float rlspeed;
    public float gravity;
    public float velmult;
    private GameObject go;
    private GameObject[] goarray;
    public Vector3[] velarray;
    public Vector3[] posnarray;
    private int i;
    private int j;
    private int k;
    private int l;
    private Vector3 insttran;
    private Vector3 vector;
    private float drop;
    private float keytimer;
    public float ramptime;
    private height_constraint gohc;
    // Start is called before the first frame update
    void Start()
    {
        goarray = new GameObject[250];
        velarray = new Vector3[250];
        posnarray = new Vector3[250];
        drop = 0.1179f;
        i = 0;
        j = linknumber;
        k = linknumber;
        iheight = this.transform.position.y;
        height = iheight;
        for (i = 0; i < linknumber; i++)
        {
            height -= drop;
            rotate = Quaternion.Euler(0, 90 * ((Mathf.Pow((-1f), (float)i) + 1f) / 2f), 90);
            link.name = string.Format("chainLink{0}", j);
            go = Instantiate(link, new Vector3(this.transform.position.x, height, this.transform.position.z), rotate) as GameObject;
            posnarray[j] = go.transform.position;
            gohc = go.GetComponent(typeof(height_constraint)) as height_constraint;
            if (j == linknumber)
            {
                gohc.connGO = this.gameObject;
            }
            else
            {
                gohc.connGO = goarray[j + 1];
            }
            gohc.offset = 0.1179f;
            gohc.velfactor = velmult;
            gohc.gravfactor = gravity;
            goarray[j] = go;
            j--;
        }
        rotate = Quaternion.Euler(-90, 0, 0);
        go = Instantiate(hook, new Vector3(this.transform.position.x, height - 0.25f, this.transform.position.z), rotate) as GameObject;
        gohc = go.GetComponent(typeof(height_constraint)) as height_constraint;
        gohc.connGO = goarray[1];
        gohc.offset = 0.25f;
        go.transform.SetParent(goarray[1].transform);
        i = 0;
        goarray[linknumber].transform.SetParent(this.transform);
        for (i = 1; 1 < (linknumber - 1); i++)
        {
            goarray[i].transform.SetParent(goarray[i + 1].transform);
        }
    }
    public void RaiseChain()
    {
        transform.Translate(0, Time.fixedDeltaTime * rlspeed, 0, Space.World);
        if (currentheight - iheight > drop)
        {
            this.transform.DetachChildren();
            transform.Translate(0, -drop, 0, Space.World);
            transform.Rotate(90, 0, 0, Space.Self);
            goarray[k].transform.DetachChildren();
            Destroy(goarray[k]);
            goarray[k - 1].transform.SetParent(this.transform);
            gohc = goarray[k - 1].GetComponent(typeof(height_constraint)) as height_constraint;
            gohc.connGO = this.gameObject;
            gohc.offset = 0.1179f;
            k--;
        }
    }
    public void LowerChain()
    {
        transform.Translate(0, -Time.fixedDeltaTime * rlspeed, 0, Space.World);
        if (currentheight - iheight < -drop)
        {
            insttran.x = this.transform.position.x;
            insttran.y = this.transform.position.y;
            insttran.z = this.transform.position.z;
            rotate = this.transform.rotation;
            k++;
            link.name = string.Format("chainLink{0}", k);
            go = Instantiate(link, insttran, rotate) as GameObject;
            posnarray[k] = go.transform.position;
            goarray[k] = go;
            goarray[k - 1].transform.SetParent(go.transform);
            gohc = goarray[k].GetComponent(typeof(height_constraint)) as height_constraint;
            gohc.connGO = this.gameObject;
            gohc.offset = 0.1179f;
            gohc.velfactor = velmult;
            gohc.gravfactor = gravity;
            gohc = goarray[k - 1].GetComponent(typeof(height_constraint)) as height_constraint;
            gohc.connGO = go.gameObject;
            this.transform.DetachChildren();
            transform.Translate(0, drop, 0, Space.World);
            transform.Rotate(90, 0, 0, Space.Self);
            go.transform.SetParent(this.transform);
            gohc = goarray[k].GetComponent(typeof(height_constraint)) as height_constraint;
            gohc.connGO = this.gameObject;
            gohc.offset = 0.1179f;
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        currentheight = this.transform.position.y;
//        if (Input.GetKeyDown("e")) { keytimer = 0f; }
//        if (Input.GetKeyDown("q")) { keytimer = 0f; }
//        if (Input.GetKey("e"))
//        {
//            if (keytimer < ramptime)
//            {
//                transform.Translate(0, Time.fixedDeltaTime * rlspeed * keytimer / ramptime, 0, Space.World);
//            }
//            else
//            {
//                transform.Translate(0, Time.fixedDeltaTime * rlspeed, 0, Space.World);
//            }
//            RaiseChain();
//        }
//        if (Input.GetKey("q"))
//        {
//            if (keytimer < ramptime)
//            {
//                transform.Translate(0, -Time.fixedDeltaTime * rlspeed * keytimer / ramptime, 0, Space.World);
//            }
//            else
//            {
//                transform.Translate(0, -Time.fixedDeltaTime * rlspeed, 0, Space.World);
//            }
//            LowerChain();
//        }
        for (i = k; i > 0; i--)
        {
            gohc = goarray[i].GetComponent(typeof(height_constraint)) as height_constraint;
            velarray[i] = gohc.PositionUpdate(velarray[i + 1], i, k, this.gameObject);
        }
        for (i = k; i > 0; i--)
        {
            gohc = goarray[i].GetComponent(typeof(height_constraint)) as height_constraint;
            gohc.RotationUpdate(i, k, this.gameObject);
        }
        keytimer += Time.fixedDeltaTime;
    }


}
