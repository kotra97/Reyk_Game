using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBehaviour : MonoBehaviour
{
    private bool isCarried = false;
    private Transform _carryPosition;
    private Transform _carryPositionP;
    private Transform _carryPositionV;
    public bool _canBePick;

    private Shader _normal;
    private Shader _outline;
    private Renderer _renderer;

    void Start()
    {
        _normal = Shader.Find("Standard");
        _outline = Shader.Find("Unlit/Outline");
        _renderer = GetComponent<Renderer>();
        _renderer.material.shader = _normal;
        _carryPositionP = GameObject.FindGameObjectWithTag("CarryPlayer").transform;
        _carryPositionV = GameObject.FindGameObjectWithTag("CarryVisitor").transform;
        _carryPosition = _carryPositionV;
        _canBePick = false;
    }

    public void changeTransformFocus(bool player)
    {
        if (player)
            _carryPosition = _carryPositionP;
        else
        {
            if (_carryPositionV == null)
                _carryPositionV = GameObject.FindGameObjectWithTag("CarryVisitor").transform;
            _carryPosition = _carryPositionV;
        }
    }

    public void fixPositionObject(bool player)
    {
        changeTransformFocus(player);
        isCarried = true;
        this.transform.parent = _carryPosition;
        this.transform.position = _carryPosition.position;
        if (player)
            transform.rotation = Quaternion.Euler(0, 90, 90);
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void releaseObject(bool player)
    {
        if (player)
        {
            Vector3 direction = transform.position - transform.parent.transform.parent.transform.position;
            GetComponent<Rigidbody>().AddForce(direction.normalized * 100);
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 150);
            GetComponent<Rigidbody>().AddForce(Vector3.left * 150);
            changeTransformFocus(true);
            _canBePick = true;
        }
        GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().isTrigger = false;
        this.transform.parent = null;
        isCarried = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && isCarried)
            releaseObject(true);
    }

    private void OnMouseDown()
    {
        if (_canBePick == false)
            return;
        Destroy(this.gameObject);
        //        fixPositionObject(true);
    }

    private void OnMouseEnter()
    {
        if (_canBePick)
            _renderer.material.shader = _outline;
    }

    private void OnMouseExit()
    {
        _renderer.material.shader = _normal;
    }
}
