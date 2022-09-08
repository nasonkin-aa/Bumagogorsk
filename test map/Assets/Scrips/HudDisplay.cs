using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudDisplay : MonoBehaviour
{

    public Text levelHud;
    public Text moneyHud;
    public Text peopleHud;
    public Text paperHud;
    public Text cutPaperHud;

    private void Update()
    {
        moneyHud.text = ResurceManager._coins.ToString();
        peopleHud.text = ResurceManager._population.ToString() + " / " + ResurceManager._MaxPopulation.ToString();
        levelHud.text = ResurceManager._level.ToString();
        cutPaperHud.text = ResurceManager._cutPaper.ToString();
        paperHud.text = ResurceManager._paper.ToString() + " / " + ResurceManager._maxPaper.ToString();
    }
}
