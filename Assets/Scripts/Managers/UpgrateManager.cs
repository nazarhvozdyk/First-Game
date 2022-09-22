using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgrateManager : MonoBehaviour
{
    public Transform transformForGunModel;
    [HideInInspector] public Gun upgratingGun;
    public GameObject upgrateModeUI;
    private GameObject gunModel;
    public Menu menu;
    public ChosingGunButton[] choosingGunButtons;

    public UpgratingSlidersManager upgratingSlidersManager;
    private PlayerArmory playerArmory;

    [Space(10)]
    [Header("Min and max parameter of gun in the game")]

    // Максимальные и минимальные значения параметров любой пушки
    public float maxBulletSpeed = 50f;
    public float maxShootPeriod = 10f;
    public float maxBulletDamage = 100f;

    public float minBulletSpeed = 10f;
    public float minShootPeriod = 2f;
    public float minBulletDamage = 1f;

    private void Start()
    {
        playerArmory = PlayerArmory.instance;
    }
    public void SetUpgrateMode()
    {
        // настраиваєм кнопки выбора оружия
        SetChoosingGunButtons();

        // для начала будем показывать первую пушку пока игрок не выбрал другую
        upgratingGun = playerArmory.playerInventory[0];

        // создаєм модель пушки и выравниваэм по центру родителя
        gunModel = Instantiate(upgratingGun.gunModel, transformForGunModel);
        gunModel.transform.localPosition = new Vector3(0f, 0f, 0f);

        // отбираем у игрока возможность управлять игровым персонажем
        menu.DisableComponents();

        // устанавливает все ползунки
        SetSliders();

        upgrateModeUI.SetActive(true);
        Cursor.visible = true;
    }

    public void DisableUpgrateMode()
    {
        // даем игроку возможность управлять игровым персонажем
        menu.EnableComponents();

        // скидываэм слайдеры к их первоначальним настройкам
        upgratingSlidersManager.ResetSliders();

        // отключаэм окно апгрейда пушки
        upgrateModeUI.SetActive(false);

        // уничтожаэм модель пушки
        Destroy(gunModel);

        Cursor.visible = false;
    }

    // обновляет дание про пушку
    public void UpdateUpgratingMode()
    {
        // обновляэм все ползунки
        SetSliders();

        // уничтожаэм модель пушки
        Destroy(gunModel);

        // создаєм модель пушки и выравниваэм по центру родителя
        gunModel = Instantiate(upgratingGun.gunModel, transformForGunModel);
        gunModel.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    public void SetChoosingGunButtons()
    {
        for (int i = 0; i < playerArmory.playerInventory.Count; i++)
        {
            // устанавливает каждую кнопку так чтобы она показывала оружие, которое уже есть у игрока, 
            // чтобы игрок не мог улучшить оружие, которого у него нет
            choosingGunButtons[i].SetButton(playerArmory.playerInventory[i]);
        }

    }
    public void SetSliders()
    {
        // устанавливаем слайдеры, то есть минимальное, максимальное и текущее значение
        upgratingSlidersManager.SetSliders();
    }
}
