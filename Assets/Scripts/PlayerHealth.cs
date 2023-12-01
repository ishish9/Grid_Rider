using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float playerHealth = 100f;
    [SerializeField] private UnityEvent AfterDeathEvent1;

    void OnEnable()
    {
        Barrier_Spawned.OnDamage += AddDamage;
    }

    void OnDisable()
    {
        //Barrier_Spawned.OnDamage -= TakeDamage;     
    }

    public void AddDamage(float damage)
    {
        playerHealth -= damage;
        healthBar.fillAmount = playerHealth / 100f;
        if (playerHealth <= 0)
        {
            AfterDeathEvent1.Invoke();
        }
    }

    public void AddHealthl(float healAmount)
    {
        playerHealth += healAmount;
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        healthBar.fillAmount = playerHealth / 100f;
    }
}
