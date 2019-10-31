using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsContract : MonoBehaviour
{
    public GameObject bribeGo;

    private GameObject buttonsGO;

    // Start is called before the first frame update
    void Start()
    {
        buttonsGO = this.gameObject;
        HideButtons(false, false);
    }

    public void ShowButtons(bool value)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            var child = this.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(value);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void AcceptContract()
    {
        Debug.Log("Accepting contract");
    }

    public void RefuseContract()
    {
        Debug.Log("Refusing contract");
    }

    public void Bribe()
    {
        Debug.Log("Bribing");
    }

    public void HideButtons(bool hide, bool hideBribe = true)
    {
        buttonsGO.SetActive(!hide);

        if (!hide)
        {
            bribeGo.GetComponent<Button>().interactable = !hideBribe;
        }
    }
}
