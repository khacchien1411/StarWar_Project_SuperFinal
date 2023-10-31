using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;
    public int minDamage;
    public int maxDamage;

    Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }
    public void TakeDamage(int damage)
    {
        health.TakeDam(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            player =  collision.GetComponent<Player>();
            InvokeRepeating("DamagePlayer", 0, 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
            CancelInvoke("DamagePlayer");
        }
    }
    void DamagePlayer()
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        player.TakeDamage(damage);
    }
    //public Heal
    //public void TakeDamage(int damage) { 
    
    //}

}
