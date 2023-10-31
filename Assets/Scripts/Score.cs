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
            Victoryobj.SetActive(true);
            Time.timeScale = 0;
        }
    }

    //void completeMap()
    //{
        
    //}
    


}
