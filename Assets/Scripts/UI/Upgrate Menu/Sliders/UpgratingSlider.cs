using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgratingSlider : MonoBehaviour
{
    public Slider currentValueSlider;
    public Slider upgrateValueSlider;
    public UpgrateManager upgrateManager;
    public PlayerArmory playerArmory;
    protected Gun _upgratingGun;
    public Text currentValueText;
    public Text price;
    public Button upgrateButton;
    protected int priceForUpgrate;
    public AudioSource buySound;
    private void Start()
    {
        playerArmory = PlayerArmory.instance;
    }
    public virtual void SetMinAndMaxValues()
    { }

    public virtual void SetSlider()
    {
        // берем пушку которую надо улучшить
        _upgratingGun = upgrateManager.upgratingGun;

        // обновляєм слайдер
        UpdateSlider();
    }
    public void ResetSlider()
    {
        // уничтожаєм евенты лежавшие на кнопке улучшение параметра (на плюсике)
        upgrateButton.onClick.RemoveAllListeners();
    }
    public virtual void UpdateSlider()
    { }
    protected virtual void EventOnClickUpgrateButton()
    {
        // добавляэм евенты на кнопку апгрейта пушки (на плюсик)
        // каждая кнопка улучшает свой параметр
        UpdateSlider();
    }
}
