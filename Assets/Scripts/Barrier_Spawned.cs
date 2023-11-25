using UnityEngine;

public class Barrier_Spawned : MonoBehaviour
{
    [SerializeField] private AudioClip impactBarrierClip;
    [SerializeField] private GameObject ImpactBarrierEffect;
    private float TimeBetweenSteps = 1;
    private int stepsTaken;
    [SerializeField] private ScriptableVariables variables;
    public delegate void Damage(float d);
    public static event Damage OnDamage;
    public delegate void Impact();
    public static event Impact OnImpact;

    void Update()
    {
        //Debug.Log(stepsTaken + " Movement");
        if (variables.TimeBetweenSteps > 0)
        {
            variables.TimeBetweenSteps -= Time.deltaTime;
        }
        else
        {
            Move();
        }

        if (stepsTaken == 13)
        {
            AudioManager.Instance.PlaySoundEffects(impactBarrierClip);
            Instantiate(ImpactBarrierEffect, transform.position, Quaternion.identity);
            OnImpact();
            OnDamage(20);
            DestroyObject(gameObject);
        }
    }

    public void CallDamage(int damage)
    {
        OnDamage(damage);
    }
    private void Move()
    {
        transform.position += new Vector3(0, 0, -1);
        variables.TimeBetweenSteps = 1f;
        stepsTaken += 1;
    }
}
