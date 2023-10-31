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

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = ScoreManager.Instance.GetScore() + " / 100";
        fillBar.fillAmount = (float)ScoreManager.Instance.GetScore() / 100;
        if(ScoreManager.Instance.GetScore() == 10)
        {
            completeMap();
        }
    }

    void completeMap()
    {
        Victoryobj.SetActive(true);
        Time.timeScale = 0;
    }
    public void continueMap()
    {
        Time.timeScale = 1; // Set the time scale to 1 (normal speed) before changing scenes.

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
