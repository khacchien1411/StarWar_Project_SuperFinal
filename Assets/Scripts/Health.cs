using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    private float safeTime;
    public float safeTimeDuration = 0f;
    public bool isDead = false;

    public bool camShake = false;
    public GameObject GameOverobj;

    private void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
            healthBar.UpdateHealth(currentHealth, maxHealth);
        
    }

    public void TakeDam(int damage)
    {
        if (safeTime <= 0)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
             
                currentHealth = 0;
                if (this.gameObject.tag == "Enemy")
                {
                    //FindObjectOfType<WeaponManager>().RemoveEnemyToFireRange(this.transform);
                    //FindObjectOfType<Killed>().UpdateKilled();
                    //FindObjectOfType<PlayerExp>().UpdateExperience(UnityEngine.Random.Range(1, 4));
                    ScoreManager.Instance.AddScore(1);
                    Destroy(this.gameObject, 0.125f);
                    
                }
                if (this.gameObject.tag == "Player")
                {
                    //FindObjectOfType<WeaponManager>().RemoveEnemyToFireRange(this.transform);
                    //FindObjectOfType<Killed>().UpdateKilled();
                    //FindObjectOfType<PlayerExp>().UpdateExperience(UnityEngine.Random.Range(1, 4));
                    gameOver();
                    Destroy(this.gameObject, 0.125f);
                }
                isDead = true;
            }

            // If player then update health bar
            if (healthBar != null)
                healthBar.UpdateHealth(currentHealth, maxHealth);

            safeTime = safeTimeDuration;
        }
    }
    public void Heal(int healAmount)
    {
        if (currentHealth + healAmount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healAmount;
        }
            healthBar.UpdateHealth(currentHealth, maxHealth);
    }

    private void Update()
    {
        if (safeTime > 0)
        {
            safeTime -= Time.deltaTime;
        }
    }

    void gameOver()
    {
        GameOverobj.SetActive(true);
        Time.timeScale = 0;
    }
    public void resetGame()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(1);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(3);
        }
        
    }
    public void nextMap()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(3);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
