using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Names : MonoBehaviour
{
    public GameObject namePage;
    public TMP_InputField nameInput;
    public GameObject invalidInput;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("NameSet") == 0.0f){
            namePage.SetActive(true);
        }
    }
    public void CheckInput(){
        if(((nameInput.text).Length > 2) && ((nameInput.text).Length < 13)){
            Confirm();
        }else{
            invalidInput.SetActive(true);
            StartCoroutine(TimerCoroutine());
        }
    }
    public void Confirm(){
        PlayerPrefs.SetFloat("NameSet", 1.0f);
        PlayerPrefs.SetString("UserID", nameInput.text);
        Debug.Log(PlayerPrefs.GetFloat("NameSet"));
        Debug.Log(PlayerPrefs.GetString("UserID"));
        namePage.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(1);
        invalidInput.SetActive(false);
    }
}
