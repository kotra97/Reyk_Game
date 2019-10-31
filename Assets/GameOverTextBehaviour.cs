using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTextBehaviour : MonoBehaviour
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
        if (GameVariables.gov_opinion == 0 || GameVariables.public_opinion == 0 || GameVariables.shareholders_opinion == 0)
        {
            if (GameVariables.gov_opinion == 0 && GameVariables.public_opinion == 0 && GameVariables.shareholders_opinion == 0)
                _text.text = "Vous n'avez plus aucun soutien, vous êtes l'homme le plus haïs de notre siécle.";
            else if (GameVariables.gov_opinion == 0)
                _text.text = "Nous ne pouvons accepter qu'un tueur en série tel que vous continue d'agir impunément";
            else if (GameVariables.public_opinion == 0)
                _text.text = "Le peuple a décidé que vous aviez trop de sang sur les mains, et ils ont décidé de vous éliminer.";
            else if (GameVariables.shareholders_opinion == 0)
                _text.text = "Les actionnaires ont été très déçu de vos performances. Vous ne nous êtes plus d'aucune utilité. Adieu.";
        }
    }
}
