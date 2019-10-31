using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDatabase : MonoBehaviour
{
    public EventContract[] evenement;

    public EventContract getBestContract()
    {
        return (evenement[Random.Range(0, evenement.Length)]);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
