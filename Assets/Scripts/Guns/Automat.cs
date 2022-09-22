using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    public Text bulletsText;
    public PlayerArmory playerArmory;

    private void Start()
    {
        playerArmory = PlayerArmory.instance;
    }
    public override void Shoot()
    {
        base.Shoot();
        bulletsText.text = "Пули: " + numberOfBullets;
    }

    public override void Activate()
    {
        base.Activate();
        UpdateText();
        bulletsText.enabled = true;
        bullet.damageValue = _bulletDamage;
    }

    public override void DeActivate()
    {
        base.DeActivate();
        bulletsText.enabled = false;
    }

    private void UpdateText()
    {
        bulletsText.text = "Пули: " + numberOfBullets;
    }

    public override void AddBullets(int numberOfBullets)
    {
        this.numberOfBullets += numberOfBullets;
        UpdateText();
    }
}
