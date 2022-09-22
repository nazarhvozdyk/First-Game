using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPeriodSlider : UpgratingSlider
{
    public override void SetMinAndMaxValues()
    {
        // апгрейд слайдер имеет 2 слайдера, текущее значение (желтый цвет)
        // и значение после апгрейда (зеленый цвет)
        // установка минимального и максимального значения для ползунка обновления (зеленый цвет) 
        // и ползунка текущего значения(жолтого), это значение должно быть одинаковым для обоих
        currentValueSlider.minValue = upgrateValueSlider.minValue = upgrateManager.minShootPeriod;
        currentValueSlider.maxValue = upgrateValueSlider.maxValue = upgrateManager.maxShootPeriod;
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
        bool isGunUpgrated = _upgratingGun.UpgrateShootPeriod();

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
        priceForUpgrate = _upgratingGun.shootPeriodUpgratePrice;
        
        // установка значения для ползунка и для текста
        currentValueSlider.value = _upgratingGun.GetShootPeriod();
        currentValueText.text = _upgratingGun.GetShootPeriod().ToString();

        // установка значения для апгрейд слайдера (зеленого цвета)
        upgrateValueSlider.value = _upgratingGun.GetUpgrateShootPeriodValue();

        price.text = priceForUpgrate.ToString();
    }
}
