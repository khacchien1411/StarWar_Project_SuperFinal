using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image fillBar;

    public TextMeshProUGUI valueText;

    public void UpdateBar(int currenValue, int maxValue)
    {
        fillBar.fillAmount=(float)currenValue/float.MaxValue;
        valueText.text=currenValue.ToString()+" / " + maxValue.ToString();
    }
}
