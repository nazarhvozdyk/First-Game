using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Скрипт уже проверен

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public int maxHealth = 5;
    public Menu menu;
    public GameObject afterDeadUI;
    public HealthUI healthUI;
    public AudioSource AddHealthSound;
    public Animator AfterDeathUIAnimator;
    public UnityEvent eventOnTakeDamage;

    private void Start()
    {
        healthUI.Setup(maxHealth);
        healthUI.DisplayIcons(health);
    }
    public void TakeDamage(int damageValue)
    {
        health -= damageValue;

        if (health <= 0)
        {
            health = 0;
            Die();
        }

        eventOnTakeDamage.Invoke();
        healthUI.DisplayIcons(health);
    }

    public void AddHealth(int healthValue)
    {
        health += healthValue;
        AddHealthSound.Play();

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthUI.DisplayIcons(health);
    }

    private void Die()
    {
        Destroy(gameObject);

        menu.showMenu = false;

        afterDeadUI.SetActive(true);

        AfterDeathUIAnimator.SetTrigger("Appear");

        Cursor.visible = true;
    }

}
