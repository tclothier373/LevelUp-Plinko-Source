using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class codes : MonoBehaviour
{
    public TMP_InputField input;
    public CashMoney moneyScript;
    public TMP_Text validCode;
    public TMP_Text invalidCode;
    public TMP_Text debug;
    float delay;
    public AudioSource claimed;
    public AudioSource invalid;
    public Store storeScript;
    public GameObject codeTheme;
    public levels levelScript;
    public GameObject codeTheme1;
    public TMP_Text infoText;
    public Traits traitScript;
    public int iCantCode;
    public int bustaCode;
    public int visualCode;
    public int traitCode;
    public int saveCode;
    public int bannerCode;
    public int playsCode;
    public int Twokplayscode;
    public int Fivekplayscode;
    public int Tenkplayscode;
    public int TwentyFivekplayscode;
    public GameObject codeTheme2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0f){
            delay -= Time.deltaTime;
        }
        /*if (delay > 0f){
        delay -= Time.deltaTime;
        }
        if((Input.GetKey("return")) && (delay <= 0) && (String.Compare(input.text,"BUGReportSEP6") == 0) && (PlayerPrefs.GetFloat("HasClaimedBugCode") == 0)){
            moneyScript.totalCash += 5000;
            claimed.Play();
            delay = 0.5f;
            PlayerPrefs.SetFloat("HasClaimedBugCode", 1.0f);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }if((Input.GetKey("return")) && (delay <= 0) && (String.Compare(input.text,"Plinko1.4!") == 0) && (PlayerPrefs.GetFloat("HasClaimed1.4Code") == 0)){
            moneyScript.totalCash += 2500;
            delay = 0.5f;
            claimed.Play();
            storeScript.item = codeTheme.GetComponent<StoreItem>();
            storeScript.BuyBall();
            PlayerPrefs.SetFloat("HasClaimed1.4Code", 1.0f);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }if((Input.GetKey("return")) && (delay <= 0) && (String.Compare(input.text,"2415914") == 0)){
            moneyScript.totalCash += 9999999;
            delay = 0.5f;
        }if((Input.GetKey("return")) && (delay <= 0) && (String.Compare(input.text,"1kBonus!") == 0) && (PlayerPrefs.GetFloat("ClaimedBonus") == 0)){
            moneyScript.totalCash += 1000;
            claimed.Play();
            delay = 0.5f;
            PlayerPrefs.SetFloat("ClaimedBonus", 1.0f);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if(Input.GetKey("return") && (delay <= 0)){
            delay = 0.5f;
            invalid.Play();
            invalidCode.gameObject.SetActive(true);
            StartCoroutine(InvalidCoroutine());
        }
        */
    }
    public void CheckCode(){
        if((String.Compare(input.text,"BUGReportSEP6") == 0) && (PlayerPrefs.GetFloat("HasClaimedBugCode") == 0) && (delay <= 0)){
            moneyScript.totalCash += 5000;
            claimed.Play();
            delay = 0.5f;
            PlayerPrefs.SetFloat("HasClaimedBugCode", 1.0f);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }/*else if((String.Compare(input.text,"Plinko1.4!") == 0) && (PlayerPrefs.GetFloat("HasClaimed1.4Code") == 0) && (delay <= 0)){
            moneyScript.totalCash += 2500;
            delay = 0.5f;
            claimed.Play();
            PlayerPrefs.SetFloat("HasClaimed1.4Code", 1.0f);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"HawkTuah!") == 0) && (PlayerPrefs.GetFloat("HasClaimedHawkTuahCode") == 0) && (delay <= 0) && ((String.Compare(PlayerPrefs.GetString("UserID"), "Hawk Tuah")) == 0)){
            moneyScript.totalCash += 10000;
            delay = 0.5f;
            claimed.Play();
            PlayerPrefs.SetFloat("HasClaimedHawkTuahCode", 1.0f);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        */else if((String.Compare(input.text,"2415914") == 0) && (delay <= 0)){
            moneyScript.totalCash += 9999999;
            delay = 0.5f;
            levelScript.rebirthTokens += 999;
            traitScript.rerollShards += 999;
        }/*else if((String.Compare(input.text,"1kBonus!") == 0) && (PlayerPrefs.GetFloat("ClaimedBonus") == 0) && (delay <= 0)){
            moneyScript.totalCash += 1000;
            claimed.Play();
            delay = 0.5f;
            PlayerPrefs.SetFloat("ClaimedBonus", 1.0f);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"RIPCodeTheme!") == 0) && (PlayerPrefs.GetFloat("ClaimedRIPCode") == 0) && (delay <= 0)){
            moneyScript.totalCash += 10000;
            claimed.Play();
            delay = 0.5f;
            PlayerPrefs.SetFloat("ClaimedRIPCode", 1.0f);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"UnityPlayIsBroken!") == 0) && (PlayerPrefs.GetFloat("HasClaimedUPBugCode") == 0) && (delay <= 0) && ((String.Compare(PlayerPrefs.GetString("UserID"), "Cood")) == 0)){
            moneyScript.totalCash += 100000;
            delay = 0.5f;
            claimed.Play();
            PlayerPrefs.SetFloat("HasClaimedUPBugCode", 1.0f);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"Rebirth1.5!") == 0) && (PlayerPrefs.GetFloat("ClaimedRebirthCode") == 0) && (delay <= 0)){
            moneyScript.totalCash += 10000;
            claimed.Play();
            delay = 0.5f;
            levelScript.rebirthTokens++;
            storeScript.item = codeTheme.GetComponent<StoreItem>();
            storeScript.BuyBall();
            PlayerPrefs.SetFloat("ClaimedRebirthCode", 1.0f);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }*//*else if((String.Compare(input.text,"ICantCode!") == 0) && (PlayerPrefs.GetFloat("ClaimedRebirthCOMPCode") == 0) && (delay <= 0)){
            levelScript.rebirthTokens++;
            claimed.Play();
            delay = 0.5f;
            iCantCode++;
            PlayerPrefs.SetFloat("ClaimedRebirthCOMPCode", iCantCode);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"RIPBusta!") == 0) && (PlayerPrefs.GetFloat("ClaimedBustaCode") == 0) && (delay <= 0)){
            moneyScript.totalCash += 5000;
            levelScript.rebirthTokens++;
            claimed.Play();
            delay = 0.5f;
            bustaCode++;
            PlayerPrefs.SetFloat("ClaimedBustaCode", bustaCode);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"Visual1.6!") == 0) && (PlayerPrefs.GetFloat("Claimed1.6Code") == 0) && (delay <= 0)){
            moneyScript.totalCash += moneyScript.totalCash * 0.33f;
            levelScript.rebirthTokens++;
            claimed.Play();
            delay = 0.5f;
            infoText.text = "+ 33% of money, 1 Rebirth Token, Code Theme 2";
            infoText.gameObject.SetActive(true);
            storeScript.item = codeTheme1.GetComponent<StoreItem>();
            storeScript.BuyBall();
            visualCode++;
            PlayerPrefs.SetFloat("Claimed1.6Code", visualCode);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }*/else if((String.Compare(input.text,"SorryXavier!") == 0) && (PlayerPrefs.GetFloat("HasClaimedSorryCode") == 0) && (delay <= 0) && ((String.Compare(PlayerPrefs.GetString("UserID"), "DarthXayy")) == 0)){
            levelScript.rebirthCounter++;
            levelScript.rebirthTokens++;
            delay = 0.5f;
            claimed.Play();
            PlayerPrefs.SetFloat("HasClaimedSorryCode", 1.0f);
            infoText.text = "+ 1 Rebirth, 1 Rebirth Token";
            infoText.gameObject.SetActive(true);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"WGameDev!") == 0) && (PlayerPrefs.GetFloat("ClaimedGameDevCode") == 0) && (delay <= 0)){
            moneyScript.totalCash += moneyScript.totalCash * 0.33f;
            claimed.Play();
            delay = 0.5f;
            infoText.text = "+ 25% of money";
            infoText.gameObject.SetActive(true);
            PlayerPrefs.SetFloat("ClaimedGameDevCode", 1.0f);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"Traits1.7!") == 0) && (PlayerPrefs.GetFloat("Claimed1.7Code") == 0) && (delay <= 0)){
            moneyScript.totalCash += moneyScript.totalCash * 0.33f;
            traitScript.rerollShards += 15;
            levelScript.rebirthTokens++;
            claimed.Play();
            delay = 0.5f;
            infoText.text = "+ 33% of money, 15 Reroll Shards, 1 Rebirth Token";
            infoText.gameObject.SetActive(true);
            traitCode++;
            PlayerPrefs.SetFloat("Claimed1.7Code", traitCode);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"Traits1.7!") == 0) && (PlayerPrefs.GetFloat("Claimed1.7Code") == 0) && (delay <= 0)){
            moneyScript.totalCash += moneyScript.totalCash * 0.33f;
            traitScript.rerollShards += 15;
            levelScript.rebirthTokens++;
            claimed.Play();
            delay = 0.5f;
            infoText.text = "+ 33% of money, 15 Reroll Shards, 1 Rebirth Token";
            infoText.gameObject.SetActive(true);
            traitCode++;
            PlayerPrefs.SetFloat("Claimed1.7Code", traitCode);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"SavingisFixed!") == 0) && (PlayerPrefs.GetFloat("ClaimedFixSavingCode") == 0) && (delay <= 0)){
            traitScript.rerollShards += 20;
            claimed.Play();
            delay = 0.5f;
            saveCode++;
            PlayerPrefs.SetFloat("ClaimedFixSavingCode", saveCode);
            infoText.text = "+ 20 Reroll Shards";
            infoText.gameObject.SetActive(true);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"Banner1.8!") == 0) && (PlayerPrefs.GetFloat("Claimed1.8Code") == 0) && (delay <= 0)){
            moneyScript.totalCash += moneyScript.totalCash * 0.25f;
            traitScript.rerollShards += 10;
            levelScript.rebirthTokens++;
            storeScript.themeItem = codeTheme2.GetComponent<StoreItem>();
            storeScript.BuyTheme();
            claimed.Play();
            delay = 0.5f;
            infoText.text = "+ 25% of money, 10 Reroll Shards, 1 Rebirth Token";
            infoText.gameObject.SetActive(true);
            bannerCode++;
            PlayerPrefs.SetFloat("Claimed1.8Code", bannerCode);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"1kPlays!") == 0) && (PlayerPrefs.GetFloat("Claimed1kPlaysCode") == 0) && (delay <= 0)){
            moneyScript.totalCash += moneyScript.totalCash * 0.5f;
            traitScript.rerollShards += 15;
            levelScript.rebirthTokens++;
            claimed.Play();
            delay = 0.5f;
            infoText.text = "+ 50% of money, 15 Reroll Shards, 1 Rebirth Token";
            infoText.gameObject.SetActive(true);
            playsCode++;
            PlayerPrefs.SetFloat("Claimed1kPlaysCode", playsCode);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"2kPlays!") == 0) && (PlayerPrefs.GetFloat("Claimed2kPlaysCode") == 0) && (delay <= 0)){
            moneyScript.totalCash += moneyScript.totalCash * 0.5f;
            traitScript.rerollShards += 20;
            levelScript.rebirthTokens += 2;
            claimed.Play();
            delay = 0.5f;
            infoText.text = "+ 50% of money, 20 Reroll Shards, 2 Rebirth Tokens";
            infoText.gameObject.SetActive(true);
            Twokplayscode++;
            PlayerPrefs.SetFloat("Claimed2kPlaysCode", Twokplayscode);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"5kPlays!") == 0) && (PlayerPrefs.GetFloat("Claimed5kPlaysCode") == 0) && (delay <= 0)){
            moneyScript.totalCash += moneyScript.totalCash;
            traitScript.rerollShards += 50;
            levelScript.rebirthTokens += 5;
            claimed.Play();
            delay = 0.5f;
            infoText.text = "+ 100% of money, 50 Reroll Shards, 5 Rebirth Tokens";
            infoText.gameObject.SetActive(true);
            Fivekplayscode++;
            PlayerPrefs.SetFloat("Claimed5kPlaysCode", Fivekplayscode);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }
        else if((String.Compare(input.text,"10kPlays!") == 0) && (PlayerPrefs.GetFloat("Claimed10kPlaysCode") == 0) && (delay <= 0)){
            moneyScript.totalCash += moneyScript.totalCash;
            traitScript.rerollShards += 100;
            levelScript.rebirthTokens += 10;
            claimed.Play();
            delay = 0.5f;
            infoText.text = "+ 100% of money, 100 Reroll Shards, 10 Rebirth Tokens";
            infoText.gameObject.SetActive(true);
            Tenkplayscode++;
            PlayerPrefs.SetFloat("Claimed10kPlaysCode", Tenkplayscode);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else if((String.Compare(input.text,"25kPlays!") == 0) && (PlayerPrefs.GetFloat("Claimed25kPlaysCode") == 0) && (delay <= 0)){
            moneyScript.totalCash += moneyScript.totalCash * 2.5f;
            traitScript.rerollShards += 250;
            levelScript.rebirthTokens += 25;
            claimed.Play();
            delay = 0.5f;
            infoText.text = "+ 250% of money, 250 Reroll Shards, 25 Rebirth Tokens";
            infoText.gameObject.SetActive(true);
            TwentyFivekplayscode++;
            PlayerPrefs.SetFloat("Claimed25kPlaysCode", TwentyFivekplayscode);
            validCode.gameObject.SetActive(true);
            StartCoroutine(ValidCoroutine());
        }else{
            delay = 0.5f;
            invalid.Play();
            invalidCode.gameObject.SetActive(true);
            StartCoroutine(InvalidCoroutine());
        }
    }
    IEnumerator ValidCoroutine()
    {
        yield return new WaitForSeconds(3);
        infoText.gameObject.SetActive(false);
        validCode.gameObject.SetActive(false);
}
IEnumerator InvalidCoroutine()
    {
        yield return new WaitForSeconds(1);
        invalidCode.gameObject.SetActive(false);
}
}
