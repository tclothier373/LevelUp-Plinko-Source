using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplier : MonoBehaviour
{
    public float mult;  
    public CashMoney moneyScript;
    public float ballValue;
    GameObject ball;
    public AudioSource boop;
    public levels LevelScript;
    float tempMult;
    //public collider 
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnTriggerEnter(Collider other){
        ball = other.gameObject;
        if(ball.gameObject.GetComponent<BallValue>().trait == "Adept"){
            moneyScript.totalCash = moneyScript.totalCash + ball.gameObject.GetComponent<BallValue>().ballValue * mult;
            tempMult = mult;
            mult = mult * 2f; 
        }else{
            tempMult = mult;
            moneyScript.totalCash = moneyScript.totalCash + ball.gameObject.GetComponent<BallValue>().ballValue * mult;
        }
        ballValue = ball.gameObject.GetComponent<BallValue>().ballValue;
        Destroy(other.gameObject);
        boop.Play();
        LevelScript.multiplierScript = this;
        LevelScript.BallHit();
        mult = tempMult;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
