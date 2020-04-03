using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainTest : MonoBehaviour
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
    private GameObject go;
    private GameObject[] goarray;
    private int i;
    private int j;
    private int k;
    private int l;
    private Vector3 insttran;
    private float offset;
    private Vector3 vector;
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
        drop = 0.1179f;
        offset = 0.12f;
        i = 0;
        j = linknumber;
        k = linknumber;
        iheight = this.transform.position.y;
        height = iheight;
        for (i = 0; i < linknumber; i++)
        {
            height -= drop;
            rotate = Quaternion.Euler(0, 90 * ((float)i + 1f), 90);
            link.name = string.Format("chainLink{0}", j);
            go = Instantiate(link, new Vector3(this.transform.position.x, height, this.transform.position.z), rotate) as GameObject;
            j--;
        }
        rotate = Quaternion.Euler(-90, 0, 0);
        //go = Instantiate(hook, new Vector3(this.transform.position.x, height - 0.1935482f, this.transform.position.z), rotate) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
