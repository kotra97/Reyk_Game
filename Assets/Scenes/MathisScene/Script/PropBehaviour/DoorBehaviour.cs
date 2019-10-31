using System.Collections;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    // 0 Close
    // 1 Opening
    // 2 Open
    // 3 Closing

    public int state = 0;
    public float speed = 1.0f;
    public bool reverse;

    void Start()
    {
        speed = (reverse ? speed : -speed);
    }

    private IEnumerator stillOpen()
    {
        yield return new WaitForSeconds(2f);
        state = 3;
    }

    void Update()
    {
        if (state == 0 || state == 2)
            return;
        if (state == 1)
        {
            transform.Rotate(new Vector3(0, speed * Time.deltaTime));
            switch (reverse)
            {
                case false:
                    if (transform.rotation.eulerAngles.y <= 270f)
                    {
                        state = 2;
                        StartCoroutine("stillOpen");
                    }
                    break;
                default:

                    if (transform.rotation.eulerAngles.y >= 90f)
                    {
                        state = 2;
                        StartCoroutine("stillOpen");
                    }
                    break;

            }
        }
        else if (state == 3)
        {
            transform.Rotate(new Vector3(0, -speed * Time.deltaTime));
            switch (reverse)
            {
                case false:
                    if (transform.rotation.eulerAngles.y >= 358.5f)
                        state = 0;
                    break;
                default:
                    if (transform.rotation.eulerAngles.y <= 1.5f)
                        state = 0;
                    break;

            }
        }
    }
}
