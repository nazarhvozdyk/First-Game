using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedSlider : UpgratingSlider
{
    public override void SetMinAndMaxValues()
    {
        // апгрейд слайдер имеет 2 слайдера, текущее значение (желтый цвет)
        // и значение после апгрейда (зеленый цвет)
        // установка минимального и максимального значения для ползунка обновления (зеленый цвет) 
        // и ползунка текущего значения(жолтого), это значение должно быть одинаковым для обоих
        currentValueSlider.minValue = upgrateValueSlider.minValue = upgrateManager.minBulletSpeed;
        currentValueSlider.maxValue = upgrateValueSlider.maxValue = upgrateManager.maxBulletSpeed;
    }

    public override void SetSlider()
    {
        base.SetSlider();
        // додаєм евент на клік кнопки апгрейд
        upgrateButton.onClick.AddListener(EventOnClickUpgrateButton);
    }
    public override void UpdateSlider()
    {
        // Обновление даных
        priceForUpgrate = _upgratingGun.bulletSpeedUpgratePrice;

        // установка значения для ползунка и для текста
        currentValueSlider.value = _upgratingGun.GetBulletSpeed();
        currentValueText.text = _upgratingGun.GetBulletSpeed().ToString();

        // установка значения для апгрейд слайдера (зеленого цвета)
        upgrateValueSlider.value = _upgratingGun.GetUpgrateBulletSpeedValue();

        price.text = priceForUpgrate.ToString();
    }
    protected override void EventOnClickUpgrateButton()
    {
        // визываэм функцию апгрейда, она возвращаэт true если апгрейд прошел успешно   
        bool isGunUpgrated = _upgratingGun.UpgrateBulletSpeed();

        // проверяем прошел ли апшрейд  
        if (isGunUpgrated)
        {
            // если да берем деньги за апгрейд
            GameManager.instance.TakeMoney(priceForUpgrate);
            buySound.Play();
        }
        base.EventOnClickUpgrateButton();
    }
}