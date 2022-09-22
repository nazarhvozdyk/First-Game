using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuWindow;
    public GameObject[] allWindows;
    public MonoBehaviour[] componentsToDisableOnPause;

    // включать компоненты после того как меню будет закрыто?
    [HideInInspector]
    public bool enableComponentsAfterMenu;

    // включать курсор после того как меню будет закрыто?
    [HideInInspector]
    public bool enableCursorAfterMenu;

    // окно, которое было открыто перед тем как игрок нажал Esc
    private GameObject windowBeforeMenu;
    [HideInInspector]   public bool showMenu = true;
    private void Start()
    {
        enableComponentsAfterMenu = true;
        enableCursorAfterMenu = false;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuWindow.activeSelf == false && showMenu)
        {
            OpenMenuWindow();
        }
    }
    public void OpenMenuWindow()
    {
        for (int i = 0; i < allWindows.Length; i++)
        {
            if (allWindows[i].activeSelf)
            {
                windowBeforeMenu = allWindows[i];
            }

            allWindows[i].SetActive(false);
        }

        if (enableComponentsAfterMenu)
        {
            EnableComponents();
        }

        menuWindow.SetActive(true);

        Cursor.visible = true;

        DisableComponents();

        Time.timeScale = 0.01f;
    }
    public void CloseMenuWindow()
    {
        if (enableComponentsAfterMenu)
        {
            EnableComponents();
        }

        for (int i = 0; i < allWindows.Length; i++)
        {
            allWindows[i].SetActive(false);
        }

        // откриваєм окно которое было открыто перед тем как игрок нажал Esc
        windowBeforeMenu.SetActive(true);

        Cursor.visible = enableCursorAfterMenu;

        Time.timeScale = 1f;
    }

    public void DisableComponents()
    {
        for (int i = 0; i < componentsToDisableOnPause.Length; i++)
        {
            if (componentsToDisableOnPause[i])
            {
                componentsToDisableOnPause[i].enabled = false;
            }
        }
    }

    public void EnableComponents()
    {
        for (int i = 0; i < componentsToDisableOnPause.Length; i++)
        {
            if (componentsToDisableOnPause[i])
            {
                componentsToDisableOnPause[i].enabled = true;
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenUpgrateWindow()
    {
        menuWindow.SetActive(false);
        DisableComponents();
        Cursor.visible = true;
    }

    public void EnableComponentsAfterMenu(bool value)
    {
        enableComponentsAfterMenu = value;
    }

    public void EnableCursorAfterMenu(bool value)
    {
        enableCursorAfterMenu = value;
    }
}
