using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVariable : MonoBehaviour
{
    [SerializeField] public GameVariables.Variables variable;

    private Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameVariables.getVariableFromEnum(variable);
    }
}
