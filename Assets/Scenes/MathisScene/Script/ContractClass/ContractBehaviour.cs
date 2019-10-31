using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractBehaviour : MonoBehaviour
{
    private bool isCarried = false;
    private Transform _carryPosition;
    private Transform _carryPositionP;
    private Transform _carryPositionV;
    private ButtonsContract _buttonContract;
    public bool _canBePick;
    public bool _isBribe;

    private Shader _normal;
    private Shader _outline;
    private Renderer _renderer;

    void Start()
    {
        _normal = Shader.Find("Standard");
        _outline = Shader.Find("Unlit/Outline");
        _renderer = GetComponent<Renderer>();
        _renderer.material.shader = _normal;
        _buttonContract = GameObject.FindGameObjectWithTag("ButtonContract").GetComponent<ButtonsContract>();
        _carryPositionP = GameObject.FindGameObjectWithTag("CarryPlayer").transform;
        _carryPositionV = GameObject.FindGameObjectWithTag("CarryVisitor").transform;
        _carryPosition = _carryPositionV;
        _buttonContract.ShowButtons(false);
        fixPositionObject(false);
        _canBePick = false;
        _isBribe = false;
    }

    private IEnumerator WaitForPickup()
    {
        yield return new WaitForSeconds(0.8f);
        changeTransformFocus(false);
        fixPositionObject(false);
        FindObjectOfType<GameLoopManager>().contractValidated();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Desk" && !_canBePick)
            StartCoroutine("WaitForPickup");
        if (collision.gameObject.tag == "Ground" && _isBribe)
            FindObjectOfType<GameLoopManager>().destroyContract();
    }

    public void changeTransformFocus(bool player)
    {
        if (player)
            _carryPosition = _carryPositionP;
        else
            _carryPosition = _carryPositionV;
    }

    public void fixPositionObject(bool player)
    {
        changeTransformFocus(player);
        isCarried = true;
        this.transform.parent = _carryPosition;
        this.transform.position = _carryPosition.position;
        if (player)
            transform.rotation = Quaternion.Euler(0, 90, 90);
        else
            transform.rotation = Quaternion.Euler(0, -90, 90);
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void releaseObject(bool player)
    {
        if (player)
        {
            _buttonContract.ShowButtons(false);
            Vector3 direction = transform.position - transform.parent.transform.parent.transform.position;
            if (!_isBribe)
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
        _renderer.material.shader = _normal;
        fixPositionObject(true);
        _buttonContract.ShowButtons(true);
    }
    private void OnMouseEnter()
    {
        if (_canBePick && !isCarried)
            _renderer.material.shader = _outline;
    }

    private void OnMouseExit()
    {
        _renderer.material.shader = _normal;
    }
}
