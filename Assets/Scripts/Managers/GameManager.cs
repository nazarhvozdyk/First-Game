using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text messageText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int startMoney = 10000000;
    public int money { get; private set; }
    private void Start()
    {
        money = startMoney;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            messageText.gameObject.SetActive(false);
        }
    }
    public void TakeMoney(int takenMoney)
    {
        money -= takenMoney;
    }

    public void AddMoney(int addedMoney)
    {
        money += addedMoney;
    }
}
