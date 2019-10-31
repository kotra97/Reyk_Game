using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContractInfo : MonoBehaviour
{
    private EventContract _info;
    private ContractBehaviour _contractBehaviour;

    public TextMeshPro _title;
    public TextMeshPro _description;
    public SpriteRenderer _acceptStamp;
    public SpriteRenderer _refuseStamp;

    private void Start()
    {
        _contractBehaviour = GetComponent<ContractBehaviour>();
    }

    public void updateInfoContract(EventContract info)
    {
        _info = info;
        _title.text = _info.nameEvent;
        _description.text = _info.detailEvent;
    }

    public void stampMark(bool response)
    {
        if (!response)
            _refuseStamp.enabled = true;
        else
            _acceptStamp.enabled = true;
    }
}
