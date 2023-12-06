using UnityEngine;

public class Barrier_Spawned : MonoBehaviour
{
    [SerializeField] private AudioClip impactBarrierClip;
    [SerializeField] private GameObject ImpactBarrierEffect;
    public static float TimeBetweenSteps = 3;
    public static float BarrierSpeed = 3;
    private int stepsTaken;
    public delegate void Damage(float d);
    public static event Damage OnDamage;
    public delegate void Impact();
    public static event Impact OnImpact;

    void Update()
    {
        //Debug.Log(stepsTaken + " Movement");
        if (TimeBetweenSteps > 0)
        {
            TimeBetweenSteps -= Time.deltaTime;
        }
        else
        {
            Move();
        }

        if (stepsTaken == 13)
        {
            stepsTaken = 0;
            AudioManager.Instance.PlaySoundEffects(impactBarrierClip);
            Instantiate(ImpactBarrierEffect, transform.position, Quaternion.identity);
            OnImpact();
            OnDamage(20);          
        }
    }

    public void CallDamage(int damage)
    {
        OnDamage(damage);
    }
    private void Move()
    {
        Debug.Log(BarrierSpeed + " BarrierSpeed");

        transform.position += new Vector3(0, 0, -1);
        TimeBetweenSteps = BarrierSpeed;
        Debug.Log(TimeBetweenSteps + " TimeBetweenSteps");
        stepsTaken += 1; 
    }

    public static void RestartSpeed()
    {
        TimeBetweenSteps = 3;
        BarrierSpeed = 3;
    }
}
