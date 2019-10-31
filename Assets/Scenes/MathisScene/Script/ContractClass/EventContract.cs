using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PointDomains
{
    public int governementPoint;
    public int publicPoint;
    public int stockPoint;
}

[System.Serializable]
public class EventContract
{
    public string nameEvent;
    public string detailEvent;
    public PointDomains acceptEvent;
    public PointDomains refuseEvent;
    public PointDomains bribeAcceptEvent;
    public PointDomains bribeRefuseEvent;
}
