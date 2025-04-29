using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class levels : MonoBehaviour
{
    public float xp;
    public float xpNeeded;
    public int level; 
    public multiplier multiplierScript;
    public float thisMultiplier;
    public float ballValue; 
    public TMP_Text currentXP;
    public TMP_Text currentLevel;
    public float nextLevelXp;
    public GameObject rebirthButton;
    public int rebirthCounter = 1;
    public TMP_Text rebirthModText; 
    public CashMoney moneyScript;
    public float rebirthTokens; 
    public TMP_Text tokenText;
    public TMP_Text ballIn;
    public TMP_Text rebirthInfo;
    public LeaderboardManager leaderboardScript;
    // Start is called before the first frame update
    void Start()
    {
        xp = PlayerPrefs.GetFloat("XP");
        level = (int)PlayerPrefs.GetFloat("Level");
        xpNeeded = PlayerPrefs.GetFloat("XPNeeded");
        rebirthTokens = PlayerPrefs.GetFloat("RebirthTokens");
        if(PlayerPrefs.GetFloat("Rebirths") == 0.0f){
            PlayerPrefs.SetFloat("Rebirths", 1);
        }
        rebirthCounter = (int)PlayerPrefs.GetFloat("Rebirths");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("RebirthTokens", rebirthTokens);
        tokenText.text = rebirthTokens.ToString();
        nextLevelXp = Mathf.Pow(xpNeeded, 1.1f);
        nextLevelXp = (float)System.Math.Round(nextLevelXp, 0);
        if(level == 0){
            level++;
            xpNeeded = level * (1000 * (rebirthCounter)) / 2;
            PlayerPrefs.SetFloat("XPNeeded", xpNeeded);
            PlayerPrefs.SetFloat("Level", (float)level);
        }
        if(xp >= xpNeeded){
            level++;
            xpNeeded = nextLevelXp;
            PlayerPrefs.SetFloat("XPNeeded", xpNeeded);
            PlayerPrefs.SetFloat("Level", (float)level);
        }
        if(level >= 10){
            rebirthButton.SetActive(true);
        }
        currentXP.text = (xp.ToString("n") + "/" + xpNeeded.ToString("n"));
        currentLevel.text = ("Level: " + level.ToString());
    }
    public void Rebirth(){
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
            rebirthCounter++;
            rebirthTokens++;
            rebirthInfo.gameObject.SetActive(false);
            PlayerPrefs.SetFloat("Level", 1);
            PlayerPrefs.SetFloat("RebirthTokens", rebirthTokens);
            level = (int)PlayerPrefs.GetFloat("Level");
            PlayerPrefs.SetFloat("XP", 0);
            xp = PlayerPrefs.GetFloat("XP");
            PlayerPrefs.SetFloat("XPNeeded", 1000 * rebirthCounter);
            xpNeeded = PlayerPrefs.GetFloat("XPNeeded");
            rebirthButton.SetActive(false);
            PlayerPrefs.SetFloat("Rebirths", (float)rebirthCounter);
            moneyScript.totalCash = 500;
            PlayerPrefs.SetFloat("Total Cash", 500);
            leaderboardScript.UploadEntry();
            leaderboardScript.LoadEntries();
        }
    }
    public void BallHit(){
        thisMultiplier = multiplierScript.mult;
        ballValue = multiplierScript.ballValue;
        xp += (thisMultiplier * ballValue) / 2;
        PlayerPrefs.SetFloat("XP", xp);
    }
    IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(1);
        ballIn.gameObject.SetActive(false);
}
}
