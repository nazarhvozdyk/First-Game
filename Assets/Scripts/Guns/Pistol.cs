using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public override void Activate()
    {
        base.Activate();
        bullet.damageValue = _bulletDamage;
    }
}
