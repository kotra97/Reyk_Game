using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMakerBehaviour : MonoBehaviour
{
    public GameObject _moneyRef;
    private IEnumerator coroutine;

    IEnumerator createXMoney(int money)
    {
        for (int i = 0; i < money; i++)
        {
            Instantiate(_moneyRef).transform.position = this.transform.position;
            yield return new WaitForSeconds(Random.Range(0.2f, 0.8f));
        }
        yield return new WaitForSeconds(1f);
        GameObject.FindObjectOfType<GameLoopManager>().askBribe();
    }

    public void createFortune()
    {
        int nbPack = Random.Range(2, 6);
        coroutine = createXMoney(nbPack);
        StartCoroutine(coroutine);
    }
}
