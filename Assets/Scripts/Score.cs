using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Score : MonoBehaviour
{
    [SerializeField] protected TMP_Text scoreText;
    [SerializeField] protected Image fillBar;
    public GameObject Victoryobj;
    public bool isDone;

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = ScoreManager.Instance.GetScore() + " / 100";
        fillBar.fillAmount = (float)ScoreManager.Instance.GetScore() / 100;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (ScoreManager.Instance.GetScore() >= 30 && !isDone)
            {
                isDone = true;
                completeMap();
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (ScoreManager.Instance.GetScore() >= 20 && !isDone)
            {
                isDone = true;
                completeMap();
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (ScoreManager.Instance.GetScore() >= 30 && !isDone)
            {
                isDone = true;
                completeMap();
            }
        }

    }

    void completeMap()
    {
        Victoryobj.SetActive(true);
        Time.timeScale = 0;
    }
    public void continueMap()
    {
        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Time.timeScale = 1;
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
