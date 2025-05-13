using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tos : MonoBehaviour
{
    public AudioSource boom;
    public GameObject image;
    public GameObject tosScreen;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("TOSAgree") == 0.0f){
            tosScreen.SetActive(true);
        }
    }
    public void DontCare(){
        boom.Play();
    }
    public void Agree(){
        PlayerPrefs.SetFloat("TOSAgree", 1.0f);
        tosScreen.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(1);
        image.SetActive(false);
}
}
