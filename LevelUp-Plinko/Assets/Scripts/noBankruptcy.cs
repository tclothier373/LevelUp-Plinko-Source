using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class noBankruptcy : MonoBehaviour
{
    public GameObject[] images;
    public AudioSource boom;
    GameObject image;
    public GameObject actualReset;
    public CashMoney moneyScript;
    public TMP_Text ballIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void continueGambling(){
        actualReset.SetActive(false);
    }
    public void userLoser(){
        if(GameObject.Find("Rick Plinko(Clone)") ||
            GameObject.Find("Plinko(Clone)") ||
            GameObject.Find("Emoji Plinko(Clone)") ||
            GameObject.Find("DGambler Plinko(Clone)") ||
            GameObject.Find("Beach Plinko(Clone)") ||
            GameObject.Find("Hacker Plinko(Clone)") ||
            GameObject.Find("Eye Plinko(Clone)") ||
            GameObject.Find("Joyous Plinko(Clone)") ||
            GameObject.Find("Horse Plinko(Clone)") ||
            GameObject.Find("Java Plinko(Clone)") ||
            GameObject.Find("Rainbow Plinko(Clone)")||
            GameObject.Find("Sponge Plinko(Clone)") ||
            GameObject.Find("Red Plinko(Clone)") ||
            GameObject.Find("Orange Plinko(Clone)") ||
            GameObject.Find("Yellow Plinko(Clone)") ||
            GameObject.Find("Green Plinko(Clone)") ||
            GameObject.Find("Blue Plinko(Clone)") ||
            GameObject.Find("Purple Plinko(Clone)") ||
            GameObject.Find("Pink Plinko(Clone)") ||
            GameObject.Find("Galaxy Plinko(Clone)") ||
            GameObject.Find("Lava Plinko(Clone)")){
            ballIn.gameObject.SetActive(true);
            StartCoroutine(TimerCoroutine());
        }else{
            moneyScript.totalCash = 500.0f;
            actualReset.SetActive(false);
        }
    }
    public void ImagePop()
    {
        image = images[Random.Range(0,4)]; 
        image.SetActive(true);
        actualReset.SetActive(true);
        boom.Play();
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        image.SetActive(false);
}
IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(1);
        ballIn.gameObject.SetActive(false);
}
}
