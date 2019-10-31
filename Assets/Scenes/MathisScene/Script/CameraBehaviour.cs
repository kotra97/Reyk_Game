using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public float Hspeed;
    public float Vspeed;
    private float yaw = 0;
    private float pitch = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yaw += Hspeed * Input.GetAxis("Mouse X");
        pitch += Vspeed * Input.GetAxis("Mouse Y");
        yaw = Mathf.Clamp(yaw, -20f, 20f);
        pitch = Mathf.Clamp(pitch, 70f, 110f);
        transform.eulerAngles = new Vector3(90 + pitch, yaw, -180);

    }
}
