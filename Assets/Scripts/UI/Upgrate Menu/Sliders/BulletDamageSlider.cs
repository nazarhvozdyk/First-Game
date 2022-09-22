using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSlider : UpgratingSlider
{
    public override void SetMinAndMaxValues()
    {
        // апгрейд слайдер имеет 2 слайдера, текущее значение (желтый цвет)
        // и значение после апгрейда (зеленый цвет)
        // установка минимального и максимального значения для ползунка обновления (зеленый цвет) 
        // и ползунка текущего значения(жолтого), это значение должно быть одинаковым для обоих
        currentValueSlider.minValue = upgrateValueSlider.minValue = upgrateManager.minBulletDamage;
        currentValueSlider.maxValue = upgrateValueSlider.maxValue = upgrateManager.maxBulletDamage;
    }

    public override void SetSlider()
    {
        base.SetSlider();
        // додаєм евент на клік кнопки апгрейд
        upgrateButton.onClick.AddListener(EventOnClickUpgrateButton);
    }

    protected override void EventOnClickUpgrateButton()
    {
        // визываэм функцию апгрейда, она возвращаэт true если апгрейд прошел успешно   
        bool isGunUpgrated = _upgratingGun.UpgrateBulletDamage();

        // проверяем прошел ли апшрейд
        if (isGunUpgrated)
        {
            // если да берем деньги за апгрейд
            GameManager.instance.TakeMoney(priceForUpgrate);
            buySound.Play();
        }
        base.EventOnClickUpgrateButton();
    }

    public override void UpdateSlider()
    {
        // Обновление даных

        priceForUpgrate = _upgratingGun.bulletDamageUpgratePrice;
        // установка значения для ползунка и для текста

        currentValueSlider.value = _upgratingGun.GetBulletDamage();
        currentValueText.text = _upgratingGun.GetBulletDamage().ToString();

        // установка значения для апгрейд слайдера (зеленого цвета)
        upgrateValueSlider.value = _upgratingGun.GetUpgrateBulletDamageValue();

        price.text = priceForUpgrate.ToString();
    }
}
