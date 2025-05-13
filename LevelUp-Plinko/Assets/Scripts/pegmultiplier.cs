using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegmultiplier : MonoBehaviour
{
    public float mult;  
    GameObject ball;
    public AudioSource boop;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other){
        ball = other.gameObject;
        ball.gameObject.GetComponent<BallValue>().ballValue = ball.gameObject.GetComponent<BallValue>().ballValue * mult;
        boop.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
