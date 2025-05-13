using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Traits : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] rows;
    public Inventory inventoryScript;
    public int rowIndex;
    public int columnIndex;
    public GameObject ballInstance;
    public int debug;
    public GameObject tcamera;
    public GameObject chancesCanvas;
    public List<GameObject> ballObjects; 
    public float delay = 1.0f;
    public List<Material> ballMaterials;
    public GameObject ballSelected;
    public TMP_Text ballName;
    public TMP_Text shardCounter;
    public GameObject ballPreview;
    public GameObject[] traitIcons;
    public GameObject traitIcon;
    public int rerollShards;
    public float traitNumber;
    public TMP_Text neShards;
    public TMP_FontAsset[] fonts; 
    public TMP_Text ballTrait;
    public AudioSource traitSound;
    public Material beachBall;
    public spawnBallYes spawnScript;
    public int pageCount;
    public TMP_Text pageCounter;
    public TMP_Text traitInfo;
    void Start()
    {
        PopulateRows();
        rerollShards = (int)PlayerPrefs.GetFloat("RerollShards");
    }
    public void SelectBall(int tile){
        ballSelected = inventoryScript.ballInventory[tile + (12 * pageCount)];
        if(ballSelected != null){
            if(PlayerPrefs.GetString("BallTrait" + ballSelected.name) == ""){
                ballSelected.GetComponent<BallValue>().trait = "None";
            }else{
                ballSelected.GetComponent<BallValue>().trait = PlayerPrefs.GetString("BallTrait" + ballSelected.name);
            }
            ballName.text = ballSelected.name;
            traitIcon.GetComponent<RawImage>().texture = BallIcon().GetComponent<RawImage>().texture;
            if(ballSelected.name == "Beach Plinko"){
                ballPreview.GetComponent<MeshRenderer>().material = beachBall;
            }else{
            ballPreview.GetComponent<MeshRenderer>().material = ballMaterials[tile];
            }
        }
        EquipBall(ballSelected);
    }

    // Update is called once per frame
    void Update()
    {
        shardCounter.text = rerollShards.ToString();
        if(delay > 0){
            delay -= Time.deltaTime;
        }
        if(delay <= 0){
            PopulateRows();
        }
        PlayerPrefs.SetFloat("RerollShards", rerollShards);
        pageCounter.text = (pageCount + 1).ToString();
    }
    public void EquipBall(GameObject ball){
        spawnScript.ball = ball;
        PlayerPrefs.SetFloat("ballEquipped", ball.GetComponent<BallValue>().ballID);
    }
    public void GoToTraits(){
        tcamera.transform.position = new Vector3(223,19.33f,-9);
    }
    public void BackToStore(){
        tcamera.transform.position = new Vector3(-235,19.33f,-9);
    }
    public void PopulateRows(){
    for (int i = ballObjects.Count - 1; i >=0; i--)
        {
            Destroy(ballObjects[i]);
            ballObjects.Remove(ballObjects[i]);
        }
    int columnIndex = 0;
    int rowIndex = 0;
    int columns = 4;
    ballMaterials = new List<Material>();
    try{
    for(int i = 0 + (12 * pageCount); i < 12 + (12 * pageCount); i++){
        if(PlayerPrefs.GetString("BallTrait" + inventoryScript.ballInventory[i].name) == ""){
                inventoryScript.ballInventory[i].GetComponent<BallValue>().trait = "None";
            }else{
                inventoryScript.ballInventory[i].GetComponent<BallValue>().trait = PlayerPrefs.GetString("BallTrait" + inventoryScript.ballInventory[i].name);
            }
        ballInstance = (GameObject)Instantiate(inventoryScript.ballInventory[i], new Vector3(220 + (8.25f * columnIndex), 31 - (8 * rowIndex), 23.5f), Quaternion.identity);
        ballInstance.name = (inventoryScript.ballInventory[i].name + "(StoreItem)");
        if(inventoryScript.ballInventory[i].name == "Beach Plinko"){
            ballInstance.transform.localScale = new Vector3(5 * 1.44f,5 * 1.44f,5 * 1.44f);
        }else{
            ballInstance.transform.localScale = new Vector3(5,5,5);
        }
        ballInstance.GetComponent<Rigidbody>().detectCollisions = false;
        ballInstance.GetComponent<Rigidbody>().useGravity = false;
        ballObjects.Add(ballInstance);
        ballMaterials.Add(ballInstance.GetComponent<MeshRenderer>().material);

        columnIndex++;
        if (columnIndex >= columns) {
            columnIndex = 0;
            rowIndex++;
        }
    }
    }catch(System.ArgumentOutOfRangeException){
    }
    delay = 1.0f;
}
    public void NextPage(){
        pageCount++;
        PopulateRows();
    }
    public void PreviousPage(){
        if(pageCount >= 1){
            pageCount--;
            PopulateRows();
        }
    }
    public GameObject BallIcon(){
        switch(ballSelected.GetComponent<BallValue>().trait){
            case "Nimble":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(-10% of drop delay, allowing for a 0.09 drop rate)";
                ballTrait.font = fonts[0];
                return traitIcons[0];
            case "Valuable":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(+ 15% ball value)";
                ballTrait.font = fonts[0];
                return traitIcons[1];
            case "Small":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(balls are reduced size, and more likely to go to the middle)";
                ballTrait.font = fonts[0];
                return traitIcons[2];
            case "Expensive":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(+ 30% Ball value)";
                ballTrait.font = fonts[1];
            Debug.Log("Expensive");
                return traitIcons[3];
            case "Speedy":
            Debug.Log("Nimble");
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "( - 33% of ball delay, allowing for a 0.066 drop rate)";
                ballTrait.font = fonts[1];
                return traitIcons[4];
            case "Tiny":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(balls are smaller and even more likely to go to the middle)";
                ballTrait.font = fonts[1];
                return traitIcons[5];
            case "Doubled":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(Drops 2 Balls on each drop)";
                ballTrait.font = fonts[1];
                return traitIcons[6];
            case "Godspeed":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(+ 15% Ball value, - 75% ball delay time allowing for a 0.025 drop rate)";
                ballTrait.font = fonts[2];
                return traitIcons[7];
            case "Micro":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(+ 25% Ball value,  balls are extremely small and are most likely to go down the middle)";
                ballTrait.font = fonts[2];
                return traitIcons[8];
            case "Golden":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(Drops 2 Balls on each drop, + 150 % Ball value)";
                ballTrait.font = fonts[2];
                return traitIcons[9];
            case "Adept":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(Drops 2 Balls on each drop, + 50% Ball value, x2 experience points)";
                ballTrait.font = fonts[2];
                return traitIcons[10];
            case "Divine":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(Drops 3 Balls on each drop, + 50% Ball Value, -25% ball delay allowing for a 0.075 drop rate)";
                ballTrait.font = fonts[2];
                return traitIcons[11];
            case "Glitched":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "(Drops 5 Balls on each drop, + 50% Ball Value, -50% ball delay allowing for a 0.05 drop rate)";
                ballTrait.font = fonts[3];
                return traitIcons[12];
            case "None":
                ballTrait.text = ballSelected.GetComponent<BallValue>().trait;
                traitInfo.text = "";
                ballTrait.font = fonts[4];
            Debug.Log("None");
                return traitIcons[13];
            default:
            Debug.Log("Default");
                return traitIcons[13];
        }
    }
    public void OpenChances(){
        chancesCanvas.SetActive(!chancesCanvas.activeSelf);
    }
    public void AssignTrait(){
        traitNumber = Random.Range(0.0f, 100.0f);
        if(traitNumber >= 0.0f && traitNumber < 23.94f){
            ballSelected.GetComponent<BallValue>().trait = "Nimble";
        }else if(traitNumber >= 23.94f && traitNumber < 54.92f){
            ballSelected.GetComponent<BallValue>().trait = "Valuable";
        }else if(traitNumber >= 54.92f && traitNumber < 79.90f){
            ballSelected.GetComponent<BallValue>().trait = "Small";
        }else if(traitNumber >= 79.90f && traitNumber < 89.89f){
            ballSelected.GetComponent<BallValue>().trait = "Expensive";
        }else if(traitNumber >= 89.89f && traitNumber < 94.88f){
            ballSelected.GetComponent<BallValue>().trait = "Speedy";
        }else if(traitNumber >= 94.88f && traitNumber < 97.39f){
            ballSelected.GetComponent<BallValue>().trait = "Tiny";
        }else if(traitNumber >= 97.39f && traitNumber < 98.39f){
            ballSelected.GetComponent<BallValue>().trait = "Doubled";
        }else if(traitNumber >= 98.39f && traitNumber < 99.18f){
            ballSelected.GetComponent<BallValue>().trait = "Godspeed";
        }else if(traitNumber >= 99.18f && traitNumber < 99.55f){
            ballSelected.GetComponent<BallValue>().trait = "Micro";
        }else if(traitNumber >= 99.68f && traitNumber < 99.75f){
            ballSelected.GetComponent<BallValue>().trait = "Golden";
        }else if(traitNumber >= 99.75f && traitNumber < 99.9f){
            ballSelected.GetComponent<BallValue>().trait = "Adept";
        }else if(traitNumber >= 99.9f && traitNumber < 100.0f){
            ballSelected.GetComponent<BallValue>().trait = "Divine";
        }else if(traitNumber == 100.0f){
            ballSelected.GetComponent<BallValue>().trait = "Glitched";
        }
        traitIcon.GetComponent<RawImage>().texture = BallIcon().GetComponent<RawImage>().texture;
        PlayerPrefs.SetString(("BallTrait" + ballSelected.name), ballSelected.GetComponent<BallValue>().trait);
    }
    public void Reroll(){
        if(ballSelected != null){
        if(rerollShards >= 1){
            rerollShards -= 1;
            traitSound.Play();
            AssignTrait();
        }else{
            neShards.gameObject.SetActive(true);
            StartCoroutine(ExampleCoroutine());
        }
    }
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        neShards.gameObject.SetActive(false);
    }
}