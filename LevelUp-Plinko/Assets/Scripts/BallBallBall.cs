using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBallBall : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 5.0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontalInput =  Input.GetAxis("Horizontal");
       transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}
