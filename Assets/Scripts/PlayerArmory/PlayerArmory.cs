using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    public static PlayerArmory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Other player armory script detected");
        }
    }
    public Gun[] allGuns;
    // игрок не может иметь все оружие одновременно
    // поэтому мы ограничиваем оружие, которое будет у игрока
    // это список, потому что количество оружия будет меняться по ходу игры
    [HideInInspector]
    public List<Gun> playerInventory = new List<Gun>();
    public int currentGunIndex;
    private Gun _currentGun;
    private void Start()
    {
        for (int i = 0; i < allGuns.Length; i++)
        {
            allGuns[i].DeActivate();
        }
        // для начала пусть в игрока будет 2 оружия
        for (int i = 0; i < 2; i++)
        {
            playerInventory.Add(allGuns[i]);
        }

        currentGunIndex = Mathf.Clamp(currentGunIndex, 0, allGuns.Length);
        TakeGunByIndex(currentGunIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeGunByIndex(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TakeGunByIndex(1);
        }
    }
    public void TakeGunByIndex(int gunIndex)
    {
        playerInventory[currentGunIndex].DeActivate();
        currentGunIndex = gunIndex;
        playerInventory[gunIndex].Activate();
        _currentGun = playerInventory[currentGunIndex];
    }

    public void AddBullets(int gunIndex, int numberOfBullets)
    {
        playerInventory[gunIndex].AddBullets(numberOfBullets);
    }
}
