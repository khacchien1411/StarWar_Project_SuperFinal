using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI valueText;
    public void UpdateBar(int currentValue, int maxValue)
    {
        fillBar.fillAmount=(float)currentValue/(float)maxValue;
        valueText.text=currentValue.ToString()+" / " +maxValue.ToString();

    }

    public void UpdateHealth(int health, int maxHealth)
    {
        valueText.text = health.ToString() + " / " + maxHealth.ToString();
        fillBar.fillAmount = (float)health / (float)maxHealth;
    }


}
