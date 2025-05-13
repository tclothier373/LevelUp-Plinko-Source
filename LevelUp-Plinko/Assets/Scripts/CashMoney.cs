using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class CashMoney : MonoBehaviour
{
    public float totalCash;
    public TMP_Text cashText, cashText1;
    public TMP_Text bonusText;
    public multiplier[] scriptList;
    public GameObject bonusButton;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("Total Cash") > 0.0f){
        totalCash = PlayerPrefs.GetFloat("Total Cash");
        }else{
            totalCash = 500.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        totalCash = (float) System.Math.Round(totalCash, 2);
        cashText.text = ("$" + totalCash.ToString("n"));
        SaveMoney();
        LoadMoney();
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetFloat("Total Cash", totalCash); 
    }
    public void LoadMoney()
    {
        totalCash = PlayerPrefs.GetFloat("Total Cash");
    }
}
