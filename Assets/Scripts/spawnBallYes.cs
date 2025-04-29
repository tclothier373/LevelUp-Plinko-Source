using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class spawnBallYes : MonoBehaviour
{
    public float delay;
    public float delayAssign;
    public GameObject ball;
    public GameObject[] ballArray;
    public CashMoney moneyScript;
    public TMP_InputField input;
    public GameObject ballInstance;
    public BallValue ballScript;
    public float ballValue;
    public float testInput;
    public TMP_Text broke;
    public float debug;
    public levels levelScript;
    public List<GameObject> balls;
    public GameObject ballYes;
    public bool ballTrailsOn; 
    public Settings settingsScript;
    // Start is called before the first frame update
    void Start()
    {
        delay = delayAssign;
    }

    // Update is called once per frame
    void Update()
    {
        Unstuck();
        if (delay > 0f){
        delay -= Time.deltaTime;
        }
        if(Input.GetKey(settingsScript.dropKey) && (delay <= 0)){
            float.TryParse(input.text, out testInput);
            if((testInput > moneyScript.totalCash) || (testInput <= 0)){
                broke.gameObject.SetActive(true);
                StartCoroutine(ExampleCoroutine());
            }else{
                switch(ball.GetComponent<BallValue>().trait){
                    
                    case "Nimble":
                        delay = delayAssign * 0.9f;
                        ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                        ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput;
                        if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                        balls.Add(ballInstance.gameObject);
                        break;
                    case "Valuable":
                        delay = delayAssign;
                        ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                        ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput * 1.15f;
                        balls.Add(ballInstance.gameObject);
                        if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                        break;
                    case "Small":
                        delay = delayAssign;
                        ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                        ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput;
                        if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.675f * 1.44f, 0.675f * 1.44f, 0.675f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.675f, 0.675f, 0.675f);
                        }
                        balls.Add(ballInstance.gameObject);
                        break;
                    case "Expensive":
                        delay = delayAssign;
                        ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                        ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput * 1.30f;
                        if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                        balls.Add(ballInstance.gameObject);
                        break;
                    case "Speedy":
                        delay = delayAssign * 0.66f;
                        ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                        ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput;
                        if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                        balls.Add(ballInstance.gameObject);
                        break;
                    case "Tiny":
                        delay = delayAssign;
                        ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                        ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput;
                        if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.6f * 1.44f, 0.6f * 1.44f, 0.6f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                        }
                        balls.Add(ballInstance.gameObject);
                        break;
                    case "Doubled": 
                        delay = delayAssign;
                        for(int x = 2; x > 0; x--){
                            ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                            ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput;
                            if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                            balls.Add(ballInstance.gameObject);
                        }
                        break; 
                    case "Godspeed": 
                        delay = delayAssign * 0.25f;
                        ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                        ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput * 1.15f;
                        if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                        balls.Add(ballInstance.gameObject);
                        break; 
                    case "Micro":
                        delay = delayAssign;
                        ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                        ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput * 1.25f;
                        if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.4f * 1.44f, 0.4f * 1.44f, 0.4f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                        }
                        balls.Add(ballInstance.gameObject);
                        break;
                    case "Golden":
                        delay = delayAssign;
                        for(int x = 2; x > 0; x--){
                            ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                            ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput * 2.50f;
                            if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                            balls.Add(ballInstance.gameObject);
                        }
                        break;
                    case "Adept":
                        delay = delayAssign;
                        for(int x = 2; x > 0; x--){
                            ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                            ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput * 1.50f;
                            if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                            balls.Add(ballInstance.gameObject);
                        }
                        break;
                    case "Divine":
                        delay = delayAssign * 0.75f;
                        for(int x = 3; x > 0; x--){
                            ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                            ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput * 1.50f;
                            if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                            balls.Add(ballInstance.gameObject);
                        }
                        break;
                    case "Glitched":
                        delay = delayAssign * 0.5f;
                        for(int x = 5; x > 0; x--){
                            ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                            ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput * 1.50f;
                            if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                            balls.Add(ballInstance.gameObject);
                        }
                        break;
                    case "None":
                        delay = delayAssign;
                        ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                        ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput;
                        if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                        balls.Add(ballInstance.gameObject);
                        break;
                    case null:
                        delay = delayAssign;
                        ballInstance = (GameObject)Instantiate(ball, new Vector3(Random.Range(-1.5f, 1.5f), 40.0f, 23.3f), Quaternion.identity);
                        ballInstance.gameObject.GetComponent<BallValue>().ballValue = testInput;
                        if(ball.name == "Beach Plinko"){
                            ballInstance.transform.localScale = new Vector3(0.75f * 1.44f, 0.75f * 1.44f, 0.75f * 1.44f);
                        }else{
                        ballInstance.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                        }
                        balls.Add(ballInstance.gameObject);
                        break;
                }
                if(ballTrailsOn == false){
                    ballInstance.gameObject.GetComponent<TrailRenderer>().enabled = false;
                }else{
                    ballInstance.gameObject.GetComponent<TrailRenderer>().enabled = true;
                }
                moneyScript.totalCash -= testInput;
                }
        }
    }
    public void Unstuck(){
        for (int i = balls.Count - 1; i >=0; i--)
        {
            if(balls[i] == null){
                balls.Remove(balls[i]);
            }else{
                ballYes = balls[i];
                Rigidbody rb = ballYes.GetComponent<Rigidbody>();
                float speed = Vector3.Magnitude(rb.velocity);
                if(speed == 0){
                    rb.AddForce(new Vector3(Random.Range(-1.0f,1.0f), 0.0f, 0.0f), ForceMode.Impulse); 
            }
        }
    }
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        broke.gameObject.SetActive(false);
    }
    public void AllIn(){
        input.text = (moneyScript.totalCash).ToString("r");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void halfIn(){
        input.text = (moneyScript.totalCash/2).ToString("r");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void quarterIn(){
        input.text = (moneyScript.totalCash/4).ToString("r");
        EventSystem.current.SetSelectedGameObject(null);
    }
}
