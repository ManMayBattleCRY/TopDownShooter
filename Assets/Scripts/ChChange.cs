using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChChange : MonoBehaviour
{

    public UsingProjectiles _proj;
    // Start is called before the first frame update

    public Text S_DamageText;
    public Text S_AttackSpeedText;
    public Text S_MaxAmmoAmountText;
    public Text S_ReloadTime;

    public void DamageChange(Text tex)
    {
        float damage = float.Parse(tex.text) / 100f;
        _proj.damage = _proj.damage + _proj.damage * damage;
        _proj.ProjectilePrefab.damage = _proj.damage;
        Debug.Log(_proj.ProjectilePrefab.damage);
        S_DamageText.text ="Damege: " + _proj.damage;
    }

    public void AttackSpeedChange(Text tex)
    {
        float cooldown = float.Parse(tex.text) / 100f;
        _proj.cooldown = _proj.cooldown - _proj.cooldown * cooldown;
        S_AttackSpeedText.text = "Attack Speed: " + _proj.cooldown;
    }

    public void AmmoAmountChange(Text tex)
    {
        float ammount = float.Parse(tex.text) / 100f;
        _proj.MaxAmmoAmount = Convert.ToInt32(_proj.MaxAmmoAmount + _proj.MaxAmmoAmount * ammount);
        S_MaxAmmoAmountText.text = "Max Ammo: " + _proj.MaxAmmoAmount;
        _proj.AmmoAmountChange();
    }

    public void ReloadTimeChange(Text tex)
    {
        float _reloadTime = float.Parse(tex.text) / 100f;
        _proj.ReloadTime = (_proj.ReloadTime - _proj.ReloadTime * _reloadTime);
        S_ReloadTime.text = "Reload Time: " + _proj.ReloadTime;
    }

    private void Start()
    {
        S_DamageText.text = "Damege: " + _proj.damage;
        S_AttackSpeedText.text = "Attack Speed: " + _proj.cooldown.ToString();
        S_MaxAmmoAmountText.text = "Max Ammo: " + _proj.MaxAmmoAmount;
        S_ReloadTime.text = "Reload Time: " + _proj.ReloadTime;
    }
}
