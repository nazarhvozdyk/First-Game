using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChosingGunButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite defaultImage;
    public Image buttonImage;
    public Button button;
    public UpgrateManager upgrateManager;

    // оружие которое будет улучшаться при нажатие на кнопку
    private Gun gun;

    public void SetButton(Gun gun)
    {
        // присваиваєм оружие которое кнопка, 
        // назначит как оружие которое игрок хочет улушить
        this.gun = gun;

        // назначаєм спрайт оружия на кнопку
        buttonImage.sprite = gun.image;

        // добавляєм евенты на нажатия кнопки
        button.onClick.AddListener(SetListener);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();

        // меняєм размер кнопки
        StartCoroutine(ChangingScaleWithLerp(1.5f, 2f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        
        // меняєм размер кнопки
        StartCoroutine(ChangingScaleWithLerp(1, 2f));
    }
    public void ResetButton()
    {
        // сносим кнопку к первоначальним настройкам
        buttonImage.sprite = defaultImage;
        button.onClick.RemoveAllListeners();
    }
    private void SetListener()
    {
        // назначаєм пушку 
        upgrateManager.upgratingGun = gun;

        // обновляем дание
        upgrateManager.UpdateUpgratingMode();
    }

    private IEnumerator ChangingScaleWithLerp(float scaleValue, float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp( transform.localScale, new Vector3(scaleValue, scaleValue, scaleValue), i);

            yield return null;
        }
    }
}
