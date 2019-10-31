using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryBehaviour : MonoBehaviour
{
    public void sendContract()
    {
        if (transform.childCount == 0)
            return;
        transform.GetChild(0).GetComponent<ContractBehaviour>().releaseObject(false);
    }
}
