using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startScreen;
    public GameObject scamera;
    public GameObject creditScreen;
    public AudioSource titleMusic;
    void Start()
    {
        
    }
    public void BackToStart(){
        creditScreen.SetActive(false);
        startScreen.SetActive(true);
    } 
    public void CreditScreen(){
        startScreen.SetActive(false);
        creditScreen.SetActive(true);
    }
    public void Play(){
        scamera.transform.position = new Vector3(-2,19.33f,-9);
        titleMusic.Stop();
    }
    public void Settings(){
        scamera.transform.position = new Vector3(-115,19.33f,-9);
        titleMusic.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
