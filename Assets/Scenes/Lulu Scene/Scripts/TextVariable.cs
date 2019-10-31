using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextVariable : MonoBehaviour
{
    [SerializeField] public GameVariables.Variables variable;

    private TextMeshProUGUI textTMP;

    // Start is called before the first frame update
    void Start()
    {
        textTMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textTMP.text = GameVariables.getVariableFromEnum(variable).ToString();
    }
}
