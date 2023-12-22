using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float healthAmount = 100f;
    [SerializeField] private UnityEvent AfterDeathEvent1;
    [SerializeField] private UnityEvent InstantAfterDeathEvent;


    void OnEnable()
    {
        Barrier_Spawned.OnDamage += TakeDamage;
        HealthBarrier.GiveHealth += Heal;
        Laser.OnLaserDamage += TakeDamage;
    }

    void OnDisable()
    {
        Barrier_Spawned.OnDamage -= TakeDamage;
        HealthBarrier.GiveHealth -= Heal;
        Laser.OnLaserDamage -= TakeDamage;
    }

    public void TakeDamage (float damage)
    {
        float temp = healthAmount;
        healthAmount -= damage;
        float t = healthAmount / damage;

        // healthBar.fillAmount = healthAmount / 100f;
        healthBar.fillAmount = Mathf.Lerp(temp,  healthAmount, healthAmount / 100f);

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
        InstantAfterDeathEvent.Invoke();
        StartCoroutine(wait());
        IEnumerator wait()
        {
            yield return new WaitForSeconds(2.5f);
            AfterDeathEvent1.Invoke();
        }
    }
}
