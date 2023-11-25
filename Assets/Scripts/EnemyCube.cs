using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    [SerializeField] private int FireAmount;
    [SerializeField] private float FireRate;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform EnemyProjectileSpawnLocation;
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip EnemyExplodeClip;
    [SerializeField] private int ActiveDistance;
    [SerializeField] private GameObject Enemy_Die;
    [SerializeField] private GameObject UWin;
    [SerializeField] private int Health;
    [SerializeField] private bool isEnemyOnSide;
    [SerializeField] private bool isBoss;
    [SerializeField] private Score script2;
    [SerializeField] private bool AlternateSpawnLocation;
    private bool disable = false;
    private int hits;
    public float x;
    public float y;
    public float z;
    public float xSpeed;
    public float ySpeed;
    public float zSpeed;
    public float DistanceToTravel;

    private void Update()
    {
        switch (isEnemyOnSide)
        {
            case true:
                x = Mathf.Sin(Time.time * xSpeed) * DistanceToTravel;
                y = Mathf.Sin(Time.time * ySpeed) * DistanceToTravel;
                z = Mathf.Sin(Time.time * zSpeed) * DistanceToTravel;

                transform.position = new Vector3(transform.position.x , y + -3.5f, transform.position.z);
                break;

            case false:
                x = Mathf.Sin(Time.time * xSpeed) * DistanceToTravel;
                y = Mathf.Sin(Time.time * ySpeed) * DistanceToTravel;
                z = Mathf.Sin(Time.time * zSpeed) * DistanceToTravel;

                transform.position = new Vector3(x + .5f, transform.position.y, transform.position.z);
                break;
        }
            
        float dist = Vector3.Distance(transform.position, Player.position);
        if (isBoss)
        {
            if (dist < ActiveDistance && disable == false)
            {
                FireAmount = 200;
                disable = true;
                StartEnemyFire();
            }

            if (dist > ActiveDistance)
            {
                disable = false;
                hits = 0;
                FireAmount = 0;
            }
        }
        else
        {
            if (dist < ActiveDistance && disable == false)
            {
                FireAmount = 10;
                disable = true;
                StartEnemyFire();
            }

            if (dist > ActiveDistance)
            {
                disable = false;
                hits = 0;
                FireAmount = 0;
            }
        }
    }

    private void StartEnemyFire()
    {
        StartCoroutine(w1());

        IEnumerator w1()
        {
            for (int j = 0; j < FireAmount; j++)
            {
                yield return new WaitForSeconds(FireRate);
                GameObject fx2 = ObjectPool_Enemy.instance2.GetPooledObject2();

                if (fx2 != null)
                {
                    if (AlternateSpawnLocation)
                    {
                        fx2.transform.position = EnemyProjectileSpawnLocation.transform.position;
                    }
                    else
                    {
                        fx2.transform.position = gameObject.transform.position;
                    }
                    fx2.SetActive(true);
                }
            }
        }       
    }

    private void OnTriggerEnter(Collider hitbox)
    {
        hits++;
        AudioManager.Instance.PlaySoundEffects(hitClip);
        if (hitbox.gameObject.CompareTag("Bullet") && hits >= Health && !isBoss)
        {
            AudioManager.Instance.PlaySoundEffects(EnemyExplodeClip);
            Instantiate(Enemy_Die, transform.position, Quaternion.identity);
            hits = 0;
            gameObject.SetActive(false);
        }
        else if (hitbox.gameObject.CompareTag("Bullet") && hits >= Health && isBoss)
        {
            StartCoroutine(Wait());

            IEnumerator Wait()
            {
                yield return new WaitForSeconds(5);
                script2.EndScoreCalculation();
                AudioManager.Instance.PlaySoundEffects(EnemyExplodeClip);
                Instantiate(Enemy_Die, transform.position, Quaternion.identity);
                Instantiate(Enemy_Die, transform.position + new Vector3(10 , 0, 0), Quaternion.identity);
                Instantiate(Enemy_Die, transform.position, Quaternion.identity);

                hits = 0;
                UWin.SetActive(true);
                Death_Trigger.instance.Die();
                gameObject.SetActive(false);
            }       
        }
    }
}
