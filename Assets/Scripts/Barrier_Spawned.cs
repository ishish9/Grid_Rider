using UnityEngine;

public class Barrier_Spawned : MonoBehaviour
{
    [SerializeField] private AudioClip impactBarrierClip;
    [SerializeField] private GameObject ImpactBarrierEffect;
    public static float TimeBetweenSteps = 5;
    private int stepsTaken;
    public delegate void Damage(float d);
    public static event Damage OnDamage;
    public delegate void Impact();
    public static event Impact OnImpact;
    private int ScoreS;

    private void Start()
    {
        Score ScoreS = new Score();
       // ScoreS.GetScore();
    }

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
        transform.position += new Vector3(0, 0, -1);
        TimeBetweenSteps = 1f;
        stepsTaken += 1; 
    }
}
