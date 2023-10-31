using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    [SerializeField] int maxExp;

    int currentExp;

    public ExpBar expBar;

    private void Start()
    {
        currentExp = 0;
        expBar.UpdateBar(currentExp, maxExp);
    }

    public void TakeExp(int exp)
    {
        currentExp += exp;
        if(currentExp == maxExp) { 
        Destroy(gameObject);
         }
    }
}
