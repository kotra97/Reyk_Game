using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCountBehaviour : MonoBehaviour
{
    private UnityEngine.UI.Text _count;

    void Start()
    {
        _count = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.death_count < 1000)
            _count.text = GameVariables.death_count.ToString() + "K";
        else
            _count.text = (System.Math.Round((float)GameVariables.death_count / 1000, 2)).ToString() + "M";
    }
}
