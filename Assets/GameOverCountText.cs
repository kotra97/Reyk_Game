using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCountText : MonoBehaviour
{
    Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Vous êtes resté à votre poste durant " + GameVariables.death_count / 116 + " semaines.\nEt vous avez perdu " + GameVariables.death_count + "K clients.";
    }
}
