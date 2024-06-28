using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public Text DamageButton;
    public Text AttackSpeedButton;
    public Text AmmoAmountButton;
    public Text ReloadTimeButton;

    

    public GameObject LevelUpPanel;
    public Slider slider;
    float Exp = 0f;

    public float lvlUpE = 100f;


    public void ExpirienceGet( float _expGet)
    {
        Exp += _expGet;
        Checklvl();
    }

    public void Checklvl()
    {
        if (Exp >= lvlUpE) lvlUp();
        else
        {
            slider.value = Exp / lvlUpE;
        }    
        }

    public void lvlUp()
    {
        Debug.Log("LVLUP!!!");
        Exp -= lvlUpE;
        slider.value = Exp / lvlUpE;
        slider.gameObject.SetActive(false);
        LevelUpPanel.SetActive(true);
        RandomBonus();
    }

    public void RandomBonus()
    {
        DamageButton.text = Random.Range(10, 30).ToString();
        AttackSpeedButton.text = Random.Range(10, 30).ToString();
        AmmoAmountButton.text = Random.Range(10, 30).ToString();
        ReloadTimeButton.text = Random.Range(10, 30).ToString();
    }
}
