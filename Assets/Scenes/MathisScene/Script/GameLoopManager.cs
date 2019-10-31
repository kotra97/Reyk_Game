using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private enum contratState
    {
        UNKNOWN,
        ACCEPTED,
        REFUSED,
        BRIBE_ACCEPTED,
        BRIBE_REFUSED
    }

    public GameObject _standardVisitor;
    public GameObject _standardContract;

    public GameObject _gameOverScreen;
    private MoneyMakerBehaviour _moneyMaker;
    private EventDatabase _dbContract;
    private SliderVariable[] _sliders;

    private GameObject _currentVisitor;

    private GameObject _contractCurrent;
    private ContractInfo _contractInfo;
    private ContractBehaviour _contractBehaviour;
    private EventContract _dataInfo;

    private contratState _stateContrat;

    private void Awake()
    {
        GameVariables.public_opinion = 50;
        GameVariables.gov_opinion = 50;
        GameVariables.shareholders_opinion = 50;
        GameVariables.death_count = 0;
    }
    private void Start()
    {
        _moneyMaker = GameObject.FindObjectOfType<MoneyMakerBehaviour>();
        _dbContract = GameObject.FindObjectOfType<EventDatabase>();
        _sliders = GameObject.FindObjectsOfType<SliderVariable>();
        //callUiUpdate();
        getNewVisitor();
    }

    private void callUiUpdate()
    {
        //foreach (var slider in _sliders)
        //slider.updateValueSlider();
    }

    public void AcceptContract()
    {
        _contractInfo.stampMark(true);
        _contractBehaviour._canBePick = false;
        _contractBehaviour.releaseObject(true);
        _stateContrat = contratState.ACCEPTED;
    }

    public void RefuseContract()
    {
        _contractInfo.stampMark(false);
        _contractBehaviour._canBePick = false;
        _contractBehaviour.releaseObject(true);
        _stateContrat = contratState.REFUSED;
    }

    public void BribeContract()
    {
        _moneyMaker.createFortune();
        _contractBehaviour._canBePick = false;
        _contractBehaviour._isBribe = true;
        _contractBehaviour.releaseObject(true);
    }

    public void askBribe()
    {
        if (_currentVisitor.GetComponent<PersoMovement>().bribeAsk())
            _stateContrat = contratState.BRIBE_ACCEPTED;
        else
            _stateContrat = contratState.BRIBE_REFUSED;
    }

    IEnumerator Creation()
    {
        yield return new WaitForSeconds(0.1f);
        _currentVisitor = Instantiate(_standardVisitor);
        _contractCurrent = Instantiate(_standardContract);
        _dataInfo = _dbContract.getBestContract();
        _contractBehaviour = _contractCurrent.GetComponent<ContractBehaviour>();
        _contractInfo = _contractCurrent.GetComponent<ContractInfo>();
        _contractInfo.updateInfoContract(_dataInfo);
        _contractCurrent.transform.parent = _currentVisitor.transform.GetChild(0).transform;
        _contractCurrent.transform.localRotation = new Quaternion(0, 0, 0, 0);

    }

    private void getNewVisitor()
    {
        _stateContrat = contratState.UNKNOWN;
        StartCoroutine("Creation");

    }

    public void contractValidated()
    {
        _currentVisitor.GetComponent<PersoMovement>().receiveContract();
    }
    public void destroyContract()
    {
        Destroy(_contractCurrent);
        _contractCurrent = null;
    }


    private void changePointsValue(PointDomains point)
    {
        GameVariables.public_opinion = (uint)Mathf.Clamp(((int)GameVariables.public_opinion + point.publicPoint), 0, 100);
        GameVariables.gov_opinion = (uint)Mathf.Clamp(((int)GameVariables.gov_opinion + point.governementPoint), 0, 100);
        GameVariables.shareholders_opinion = (uint)Mathf.Clamp(((int)GameVariables.shareholders_opinion + point.stockPoint), 0, 100);
        if (GameVariables.shareholders_opinion == 0 || GameVariables.public_opinion == 0 || GameVariables.gov_opinion == 0)
        {
            Time.timeScale = 0f;
            _gameOverScreen.SetActive(true);
        }
        callUiUpdate();
    }

    private void updateData()
    {
        GameVariables.death_count += 116;
        switch (_stateContrat)
        {
            case contratState.ACCEPTED:
                changePointsValue(_dataInfo.acceptEvent);
                break;
            case contratState.REFUSED:
                changePointsValue(_dataInfo.refuseEvent);
                break;
            case contratState.BRIBE_ACCEPTED:
                changePointsValue(_dataInfo.bribeAcceptEvent);
                break;
            case contratState.BRIBE_REFUSED:
                changePointsValue(_dataInfo.bribeRefuseEvent);
                break;
            default:
                break;
        }
    }

    public void visitorLeave()
    {
        if (_contractCurrent != null)
            Destroy(_contractCurrent);
        Destroy(_currentVisitor);
        updateData();
        getNewVisitor();
    }
}
