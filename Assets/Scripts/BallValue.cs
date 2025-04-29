using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using TMPro;


public class BallValue : MonoBehaviour
{
    public float ballValue;
    public string trait;
    public int ballID;
    public string rarity;
    // Start is called before the first frame update
    void Start()
    {
        if(trait == ""){
            trait = "None";
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
