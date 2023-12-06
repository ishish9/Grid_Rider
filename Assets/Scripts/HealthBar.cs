using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float healthAmount = 100f;
    [SerializeField] private UnityEvent AfterDeathEvent1;

    void OnEnable()
    {
        Barrier_Spawned.OnDamage += TakeDamage;
        HealthBarrier.GiveHealth += Heal;
    }

    void OnDisable()
    {
        Barrier_Spawned.OnDamage -= TakeDamage;
        HealthBarrier.GiveHealth -= Heal;
    }

    public void TakeDamage (float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
        if (healthAmount <= 0)
        {
            AfterDeathRest();
        }
    }

    public void Heal(float healAmount)
    {
        healthAmount += healAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0 , 100);
        healthBar.fillAmount = healthAmount / 100f;
    }

    void AfterDeathRest()
    {
        StartCoroutine(wait());
        IEnumerator wait()
        {
            yield return new WaitForSeconds(3);
            AfterDeathEvent1.Invoke();
        }
    }
}
