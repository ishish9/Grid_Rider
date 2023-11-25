using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sine : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public float xSin;
    public float ySin;
    public float zSin;
    public float Move;
    public float Distance;
    public bool xbool;
    public bool ybool;
    public bool zbool;
    private Vector3 Loc;

    private void Start()
    {
        Loc = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log(Loc + "START");

    }

    void Update()
    {
        Debug.Log(Loc);
        if (xbool)
        {
            x = Mathf.Sin(Time.time * xSin) * Distance;
            transform.position = new Vector3(x + Move, transform.position.y, transform.position.z);
        }

        if (ybool)
        {
            y = Mathf.Sin(Time.time * ySin) * Distance;
            transform.position = new Vector3(transform.position.x, y + Move , transform.position.z);
        }

        if (zbool)
        {
            z = Mathf.Sin(Time.time * zSin) * Distance;
            //transform.position = new Vector3(transform.position.x, transform.position.y, z + Move);
            transform.position = new Vector3(Loc.x, Loc.y, z + Move);
        }

    }
}
