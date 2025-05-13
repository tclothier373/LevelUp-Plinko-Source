using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    public Material[] colors;
    public GameObject parent;
    public float delay = 0.25f;
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(delay > 0){
            delay -= Time.deltaTime;
        }
        if(delay <= 0){
            delay = 0.25f;
            if(counter > 4){
                counter = 0;
            }
            parent.GetComponent<MeshRenderer>().material = colors[counter];
            counter++;
            
        }
    }
}
