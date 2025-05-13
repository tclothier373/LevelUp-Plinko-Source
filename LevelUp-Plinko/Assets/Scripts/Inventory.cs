using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> ballInventory;
    public spawnBallYes spawnScript;
    public GameObject debug;
    public Traits traitScript;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("HasEmojiBall") > 0.0f){
            ballInventory.Add(spawnScript.ballArray[1]);
        }
        if(PlayerPrefs.GetFloat("HasDGamblerBall") > 0.0f){
            ballInventory.Add(spawnScript.ballArray[2]);
        }
        if((PlayerPrefs.GetFloat("HasBustaBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[3]);
        }
        if((PlayerPrefs.GetFloat("HasHackerBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[4]);
        }
        if((PlayerPrefs.GetFloat("HasEyeBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[5]);  
        }
        if((PlayerPrefs.GetFloat("HasJoyousBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[6]);
        }
        if((PlayerPrefs.GetFloat("HasHorseBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[7]);
        }
        if((PlayerPrefs.GetFloat("HasRickBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[8]);
        }
        if((PlayerPrefs.GetFloat("HasJavaBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[9]);
        }
        if((PlayerPrefs.GetFloat("HasRainbowBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[10]);
        }
        if((PlayerPrefs.GetFloat("HasMysteryBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[11]);
        }
        if((PlayerPrefs.GetFloat("HasRedBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[12]);
        }
        if((PlayerPrefs.GetFloat("HasOrangeBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[13]);
        }
        if((PlayerPrefs.GetFloat("HasYellowBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[14]);
        }
        if((PlayerPrefs.GetFloat("HasGreenBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[15]);
        }
        if((PlayerPrefs.GetFloat("HasBlueBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[16]);
        }
        if((PlayerPrefs.GetFloat("HasPurpleBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[17]);
        }
        if((PlayerPrefs.GetFloat("HasPinkBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[18]);
        }
        if((PlayerPrefs.GetFloat("HasGalaxyBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[19]);
        }
        if((PlayerPrefs.GetFloat("HasLavaBall") > 0.0f)){
            ballInventory.Add(spawnScript.ballArray[20]);
        }
    }
    public void AddBall(int ballID){
        ballInventory.Add(spawnScript.ballArray[ballID]);
        traitScript.PopulateRows();
    }

    // Update is called once per frame
    void Update()
    {
    }
        
}
