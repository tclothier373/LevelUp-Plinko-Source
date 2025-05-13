using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItem : MonoBehaviour
{
    public int ballID;
    public float cost;
    public GameObject buyButton;
    public GameObject equipButton;
    public bool isBought;
    public GameObject storeManager;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        if((ballID == 1) && (PlayerPrefs.GetFloat("HasEmojiBall") > 0.0f)){
            isBought = true;
        }
        if((ballID == 2) && (PlayerPrefs.GetFloat("HasDGamblerBall") > 0.0f)){
            isBought = true;
        }
        if((ballID == 3) && (PlayerPrefs.GetFloat("HasBustaBall") > 0.0f)){
            isBought = true;
        }
        if((ballID == 4) && (PlayerPrefs.GetFloat("HasHackerBall") > 0.0f)){
            isBought = true;
        }
        if((ballID == 5) && (PlayerPrefs.GetFloat("HasEyeBall") > 0.0f)){
            isBought = true;
        }
        if((ballID == 6) && (PlayerPrefs.GetFloat("HasJoyousBall") > 0.0f)){
            isBought = true;
        }
        if((ballID == 7) && (PlayerPrefs.GetFloat("HasHorseBall") > 0.0f)){
            isBought = true;
        }
        if((ballID == 8) && (PlayerPrefs.GetFloat("HasRickBall") > 0.0f)){
            isBought = true;
        }
        if((ballID == 9) && (PlayerPrefs.GetFloat("HasJavaBall") > 0.0f)){
            isBought = true;
        }
        if((ballID == 10) && (PlayerPrefs.GetFloat("HasRainbowBall") > 0.0f)){
            isBought = true;
        }
        if((ballID == 11) && (PlayerPrefs.GetFloat("HasMysteryBall") > 0.0f)){
            isBought = true;
        }

        // Themes start here
        if((ballID == 1001) && (PlayerPrefs.GetFloat("HasRedTheme") > 0.0f)){
            isBought = true;
        }
        if((ballID == 1002) && (PlayerPrefs.GetFloat("HasCodeTheme") > 0.0f)){
            isBought = true;
        }
        if((ballID == 1003) && (PlayerPrefs.GetFloat("HasCode2Theme") > 0.0f)){
            isBought = true;
        }
        if((ballID == 1004) && (PlayerPrefs.GetFloat("HasDGamblerTheme") > 0.0f)){
            isBought = true;
        }
        if((ballID == 1005) && (PlayerPrefs.GetFloat("HasSynthTheme") > 0.0f)){
            isBought = true;
        }
        if((ballID == 1006) && (PlayerPrefs.GetFloat("HasFortniteTheme") > 0.0f)){
            isBought = true;
        }
        if((ballID == 1007) && (PlayerPrefs.GetFloat("HasSpongebobTheme") > 0.0f)){
            isBought = true;
        }
        if((ballID == 1008) && (PlayerPrefs.GetFloat("HasLightTheme") > 0.0f)){
            isBought = true;
        }
        if((ballID == 1009) && (PlayerPrefs.GetFloat("HasCode3Theme") > 0.0f)){
            isBought = true;
        }
        if((ballID == 1010) && (PlayerPrefs.GetFloat("HasNightOwlTheme") > 0.0f)){
            isBought = true;
        }
        if(isBought){
            buyButton.SetActive(false);
            equipButton.SetActive(true);
        }
    }
    public void Buy(){
        storeManager.GetComponent<Store>().themeItem = parent.GetComponent<StoreItem>();
        storeManager.GetComponent<Store>().BuyTheme();
    }
    public void Equip(){
        storeManager.GetComponent<Store>().themeItem = parent.GetComponent<StoreItem>();
        storeManager.GetComponent<Store>().EquipTheme();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
