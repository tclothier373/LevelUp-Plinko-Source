using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Store : MonoBehaviour
{
    public GameObject scamera;
    public CashMoney moneyScript;
    public TMP_Text naMoneyText;
    public GameObject buyButton;
    public GameObject equipButton;
    public spawnBallYes spawnScript;
    public GameObject item;
    public GameObject ballStore;
    public GameObject themeStore;
    public GameObject theme;
    public Material[] themes;
    public int rouletteNum;
    public StoreItem themeItem;
    GameObject row;
    public AudioSource cheer;
    public AudioSource whomp;
    public AudioSource music;
    public levels levelScript;
    public GameObject storesCamera;
    public GameObject mainsCamera;
    public GameObject settingssCamera;
    public TMP_Text ballIn;
    public Inventory inventoryScript;
    public Traits traitsScript;
    public AudioSource buySound;
    public GameObject ballEffectPrefab;
    public GameObject ballEffectObject;
    public GameObject ballAuraEffect;
    public TMP_Text timeText;
    public GameObject[] commonBalls;
    public GameObject[] rareBalls;
    public GameObject[] mythicBalls;
    public GameObject[] bannerBalls;
    public int firstRareBall;
    public int secondRareBall;
    private int currentHour;
    private int currentDay;
    public GameObject bannerBall1;
    public GameObject bannerBall2;
    public GameObject bannerBall3;
    public List<Material> ballMaterials;
    public Material debug;
    public GameObject effectAttach;
    private int mythicBall;
    public TMP_Text ball1Text;
    public TMP_Text ball2Text;
    public TMP_Text ball3Text;
    private bool isDuplicate;
    public GameObject probabilityMenu;
    public GameObject mysteryBall;
    public GameObject ballInstance;
    public GameObject ballRollMenu;
    public Material mysteryMat;
    public GameObject ballPreview;
    public GameObject ballRevealMenu;
    public TMP_Text ballName;
    private bool rotating;
    public AudioSource rollSound;
    public AudioSource revealSound;
    public TMP_FontAsset commonFont;
    public TMP_FontAsset rareFont;
    public TMP_FontAsset mythicFont;
    public TMP_Text duplicateText;
    public GameObject duplicateUI;
    public GameObject banner;
    // Start is called before the first frame update
    void Start()
    {
        spawnScript.ball = spawnScript.ballArray[(int)PlayerPrefs.GetFloat("ballEquipped")];
        if(PlayerPrefs.GetFloat("themeEquipped") == 0.0f){
            PlayerPrefs.SetFloat("themeEquipped", 1000);
        }
        theme.GetComponent<MeshRenderer>().material = themes[(int)PlayerPrefs.GetFloat("themeEquipped") - 1000];
        currentHour = (int)PlayerPrefs.GetFloat("HourCount");
        currentDay = (int)PlayerPrefs.GetFloat("DayCount");
        LoadBanner();
    }
    public void RollRepeat(int num){
        for(int i = 0; i < num; i++){
            BannerSpin();
            ballRoll();
        }
    }
    public void ballRoll(){
        ballPreview.GetComponent<MeshRenderer>().material = mysteryMat;
        ballPreview.transform.eulerAngles = new Vector3(0,180,0);
        ballRollMenu.SetActive(true);
        rollSound.Play();
    }
    public void Effect(GameObject effectAttach, GameObject ballEffectPrefab){
        ballEffectObject = Instantiate(ballEffectPrefab,effectAttach.transform.position, Quaternion.identity);
        ballEffectObject.transform.SetParent(effectAttach.transform);
        ballEffectObject.transform.localPosition = new Vector3(0,0,0);
    }
    // Update is called once per frame
    void Update()
    {
        if(rotating){
            ballPreview.transform.Rotate(0,0.05f,0);
        }
    System.DateTime now = System.DateTime.Now;
    System.DateTime nextHour = now.AddHours(1).Date.AddHours(now.Hour + 1);
    System.TimeSpan timeUntilNextHour = nextHour - now;
    string timeRemaining = ("Resets in " + string.Format("{0:D2}:{1:D2}:{2:D2}", 
                                            timeUntilNextHour.Hours, 
                                            timeUntilNextHour.Minutes, 
                                            timeUntilNextHour.Seconds));
    timeText.text = timeRemaining;
    if(PlayerPrefs.GetFloat("HasABanner") == 0.0f){
        RefreshBanner();
        PlayerPrefs.SetFloat("HasABanner", 1.0f);
    }
    if((currentHour != now.Hour) || (currentDay != now.Day)){
        RefreshBanner();
    }
    currentHour = now.Hour;
    currentDay = now.Day;
    PlayerPrefs.SetFloat("HourCount", (float)currentHour);
    PlayerPrefs.SetFloat("DayCount", (float)currentDay);
    }
    public void BuyRerollShards(){
        if(levelScript.rebirthTokens < 1){
            naMoneyText.gameObject.SetActive(true);
            StartCoroutine(TimerCoroutine());
        }else{
            buySound.Play();
            levelScript.rebirthTokens -= 1;
            traitsScript.rerollShards += 10;
        }
    }
    public void RevealBall(){
        ballRollMenu.SetActive(false);
        Effect(effectAttach, ballEffectPrefab);
        StartCoroutine(RevealCoroutine());
        rotating = true;
        rollSound.Play();
    }
    IEnumerator RevealCoroutine()
    {   
    yield return new WaitForSeconds(0.5f);

    if (item != null)
    {
        MeshRenderer itemRenderer = item.GetComponent<MeshRenderer>();
        if (itemRenderer != null)
        {
            ballPreview.GetComponent<MeshRenderer>().material = itemRenderer.sharedMaterial;
            switch(item.GetComponent<BallValue>().rarity){
                case "common":
                    ballName.font = commonFont;
                    break;
                case "rare":
                    ballName.font = rareFont;
                    break;
                case "mythic":
                    ballName.font = mythicFont;
                    break;
                default:
                    ballName.font = commonFont;
                    break;
            }
            ballName.text = item.name;
        }
        else
        {
            Debug.LogWarning("Item does not have a MeshRenderer component.");
        }
    }
    else
    {
        Debug.LogWarning("Item is not assigned.");
        }
        if(isDuplicate == true){
            isDuplicate = false;
            Duplicate();
        }
        ballRevealMenu.SetActive(true);
        Destroy(ballEffectObject);
        ballAuraEffect.SetActive(true);
        revealSound.Play();
    }
    public void CloseReveal(){
        rollSound.Play();
        revealSound.Stop();
        duplicateUI.SetActive(false);
        rotating = false;
        ballAuraEffect.SetActive(false);
        ballRevealMenu.SetActive(false);
    }
    public void toggleProbabilities(){
        probabilityMenu.SetActive(!probabilityMenu.activeSelf);
    }
    public void GoToStore(){
        scamera.transform.position = new Vector3(-235,19.33f,-9);
        music.Play();
    }
    public void BackToGambling(){
        scamera.transform.position = new Vector3(-2,19.33f,-9);
        music.Stop();
    }
    public void GoToSettings(){
        scamera.transform.position = new Vector3(-115,19.33f,-9);
        music.Stop();
    }
    public void BuyBall(){
        if(levelScript.rebirthTokens >= themeItem.cost){
            levelScript.rebirthTokens -= themeItem.cost;
            themeItem.isBought = true;
            buySound.Play();
            BallAssign();
        }else{
            naMoneyText.gameObject.SetActive(true);
            StartCoroutine(TimerCoroutine());
        }
    }
    public void BuyTheme(){
        if(levelScript.rebirthTokens >= themeItem.cost){
            levelScript.rebirthTokens -= themeItem.cost;
            themeItem.isBought = true;
            buySound.Play();
            ThemeAssign();
        }else{
            naMoneyText.gameObject.SetActive(true);
            StartCoroutine(TimerCoroutine());
        }
    }
    public void BallAssign(){
        if(item.GetComponent<BallValue>().ballID == 1){
            PlayerPrefs.SetFloat("HasEmojiBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 2){
            PlayerPrefs.SetFloat("HasDGamblerBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 3){
            PlayerPrefs.SetFloat("HasBustaBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 4){
            PlayerPrefs.SetFloat("HasHackerBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 5){
            PlayerPrefs.SetFloat("HasEyeBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 6){
            PlayerPrefs.SetFloat("HasJoyousBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 7){
            PlayerPrefs.SetFloat("HasHorseBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 8){
            PlayerPrefs.SetFloat("HasRickBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 9){
            PlayerPrefs.SetFloat("HasJavaBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 10){
            PlayerPrefs.SetFloat("HasRainbowBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 11){
            PlayerPrefs.SetFloat("HasMysteryBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 12){
            PlayerPrefs.SetFloat("HasRedBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 13){
            PlayerPrefs.SetFloat("HasOrangeBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 14){
            PlayerPrefs.SetFloat("HasYellowBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 15){
            PlayerPrefs.SetFloat("HasGreenBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 16){
            PlayerPrefs.SetFloat("HasBlueBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 17){
            PlayerPrefs.SetFloat("HasPurpleBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 18){
            PlayerPrefs.SetFloat("HasPinkBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 19){
            PlayerPrefs.SetFloat("HasGalaxyBall", 1.0f);
        }
        if(item.GetComponent<BallValue>().ballID == 20){
            PlayerPrefs.SetFloat("HasLavaBall", 1.0f);
        }
    }
    public void ThemeAssign(){
        if(themeItem.ballID == 1001){
            PlayerPrefs.SetFloat("HasRedTheme", 1.0f);
            ButtonSwap();
        }
        if(themeItem.ballID == 1002){
            PlayerPrefs.SetFloat("HasCodeTheme", 1.0f);
            ButtonSwap();
        }
        if(themeItem.ballID == 1003){
            PlayerPrefs.SetFloat("HasCode2Theme", 1.0f);
            ButtonSwap();
        }
        if(themeItem.ballID == 1004){
            PlayerPrefs.SetFloat("HasDGamblerTheme", 1.0f);
            ButtonSwap();
        }
        if(themeItem.ballID == 1005){
            PlayerPrefs.SetFloat("HasSynthTheme", 1.0f);
            ButtonSwap();
        }
        if(themeItem.ballID == 1006){
            PlayerPrefs.SetFloat("HasFortniteTheme", 1.0f);
            ButtonSwap();
        }
        if(themeItem.ballID == 1007){
            PlayerPrefs.SetFloat("HasSpongebobTheme", 1.0f);
            ButtonSwap();
        }
        if(themeItem.ballID == 1008){
            PlayerPrefs.SetFloat("HasLightTheme", 1.0f);
            ButtonSwap();
        }
        if(themeItem.ballID == 1009){
            PlayerPrefs.SetFloat("HasCode3Theme", 1.0f);
            ButtonSwap();
        }
        if(themeItem.ballID == 1010){
            PlayerPrefs.SetFloat("HasNightOwlTheme", 1.0f);
            ButtonSwap();
        }
    }
    public void ButtonSwap(){
        themeItem.buyButton.SetActive(false);
        themeItem.equipButton.SetActive(true);
    }
    public void EquipTheme(){
            theme.GetComponent<MeshRenderer>().material = themes[themeItem.ballID - 1000];
            PlayerPrefs.SetFloat("themeEquipped", themeItem.ballID);
    }
    public void LoadBanner(){
        bannerBalls[0] = mythicBalls[(int)PlayerPrefs.GetFloat("BannerBallOne")];
        bannerBalls[1] = rareBalls[(int)PlayerPrefs.GetFloat("BannerBallTwo")];
        bannerBalls[2] = rareBalls[(int)PlayerPrefs.GetFloat("BannerBallThree")];
        Destroy(bannerBall1);
        bannerBall1 = Instantiate(bannerBalls[0], bannerBall1.transform.position, Quaternion.identity);
        bannerBall1.GetComponent<Rigidbody>().detectCollisions = false;
        bannerBall1.GetComponent<Rigidbody>().useGravity = false;
        bannerBall1.transform.localScale = new Vector3(4,4,4);
        bannerBall1.name = "Banner Ball1";
        Destroy(bannerBall2);
        bannerBall2 = Instantiate(bannerBalls[1], bannerBall2.transform.position, Quaternion.identity);
        bannerBall2.GetComponent<Rigidbody>().detectCollisions = false;
        bannerBall2.GetComponent<Rigidbody>().useGravity = false;
        bannerBall2.name = "Banner Ball2";
        if(bannerBalls[1].name == "Beach Plinko"){
            bannerBall2.transform.localScale = new Vector3(3f * 1.44f,3f * 1.44f,3f * 1.44f);
        }else{
            bannerBall2.transform.localScale = new Vector3(3f,3f,3f);
        }
        Destroy(bannerBall3);
        bannerBall3 = Instantiate(bannerBalls[2], bannerBall3.transform.position, Quaternion.identity);
        bannerBall3.GetComponent<Rigidbody>().detectCollisions = false;
        bannerBall3.GetComponent<Rigidbody>().useGravity = false;
        bannerBall3.name = "Banner Ball3";
        if(bannerBalls[2].name == "Beach Plinko"){
            bannerBall3.transform.localScale = new Vector3(3f * 1.44f,3f * 1.44f,3f * 1.44f);
        }else{
            bannerBall3.transform.localScale = new Vector3(3f,3f,3f);
        }
        ball1Text.text = bannerBalls[0].name;
        ball2Text.text = bannerBalls[1].name;
        ball3Text.text = bannerBalls[2].name;
        Debug.Log("Banner has been successfully loaded!");
    }
    public void RefreshBanner(){
        ballMaterials = new List<Material>();
        mythicBall = Random.Range(0,mythicBalls.Length);
        bannerBalls[0] = mythicBalls[mythicBall];
        firstRareBall = Random.Range(0,rareBalls.Length);
        bannerBalls[1]  = rareBalls[firstRareBall];
        secondRareBall = Random.Range(0,rareBalls.Length);
        while(secondRareBall == firstRareBall){
            secondRareBall = Random.Range(0,rareBalls.Length);
        }
        bannerBalls[2] = rareBalls[secondRareBall];
        PlayerPrefs.SetFloat("BannerBallOne", (float)mythicBall);
        PlayerPrefs.SetFloat("BannerBallTwo", (float)firstRareBall);
        PlayerPrefs.SetFloat("BannerBallThree", (float)secondRareBall);
        Debug.Log("Banner Data has been successfully refreshed!");
        LoadBanner();
    }
    public void BannerSpin(){
        if(levelScript.rebirthTokens >= 1){
            levelScript.rebirthTokens -= 1;
            float ballNumber = Random.Range(0.0f, 100.0f);
            if(ballNumber >= 0.0f && ballNumber < 52.49f){
                int randomCommon = Random.Range(0, commonBalls.Length);
                item = commonBalls[randomCommon];
            }else if(ballNumber >= 52.5f && ballNumber < 84.49f){
                int randomRare = Random.Range(0, rareBalls.Length);
                item = rareBalls[randomRare];
            }else if(ballNumber >= 84.5 && ballNumber < 96.99f){
                int randomMythic = Random.Range(0, mythicBalls.Length);
                item = mythicBalls[randomMythic];
            }else if(ballNumber >= 97.0f && ballNumber <= 100.0f){
                float randomBanner = Random.Range(0, 9.5f);
                if(randomBanner >= 0.0f && randomBanner < 6.49f){
                    item = bannerBalls[0];
                }else if(randomBanner >= 6.5f && randomBanner < 7.99f){
                    item = bannerBalls[1];
                }else if(randomBanner >= 8.0f && randomBanner <= 9.5f){
                    item = bannerBalls[2];
                }
        }
        BallAssign();
        for(int i = 0; i < inventoryScript.ballInventory.Count; i++){
            if(inventoryScript.ballInventory[i].name == item.name){
                isDuplicate = true;
            }
        }
        if(isDuplicate == false){
            inventoryScript.AddBall(item.GetComponent<BallValue>().ballID);
        }
        ballRoll();
    }else{
        naMoneyText.gameObject.SetActive(true);
        StartCoroutine(TimerCoroutine());
    }
    }
    public void GoToThemes(){
        banner.SetActive(false);
        bannerBall1.SetActive(false);
        bannerBall2.SetActive(false);
        bannerBall3.SetActive(false);
        themeStore.SetActive(true);
    }
    private void Duplicate(){
        duplicateUI.SetActive(true);
        switch(item.GetComponent<BallValue>().rarity){
            case "common":
                moneyScript.totalCash += moneyScript.totalCash * 0.25f;
                duplicateText.text = "Common Duplicate: + 25% of cash";
                break;
            case "rare":
                moneyScript.totalCash += moneyScript.totalCash * 0.5f;
                duplicateText.text = "Rare Duplicate: + 50% of cash";
                break;
            case "mythic":
                moneyScript.totalCash += moneyScript.totalCash * 0.75f;
                duplicateText.text = "Mythic Duplicate: + 75% of cash";
                break;
            default:
                break;
        }
    }
    public void GoToBalls(){
        banner.SetActive(true);
        bannerBall1.SetActive(true);
        bannerBall2.SetActive(true);
        bannerBall3.SetActive(true);
        themeStore.SetActive(false);
    }
    IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("disable attempted");
        naMoneyText.gameObject.SetActive(false);
    }
    private void FadeText(){
    }
}
