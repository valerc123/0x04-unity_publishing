using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllerAndroid : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;
    private Vector3 move;
    public Text scoreText;
    public Text healthText;
    public Text winLostText;
    public GameObject winLostImage;
    private bool moveLeft;
    private bool moveRight;
    private bool moveForward;
    private bool moveBack;
    void Start()
    {
        winLostImage = GameObject.Find("WinLoseBG");
        winLostImage.SetActive(false);
        rb = GetComponent<Rigidbody>();
        speed = 1000f;
    }
    void SetScoreText(){
        scoreText.text = "Score: " + score.ToString();
    }
    void SetHealthText(){
        healthText.text = "Health: " + health.ToString();
    }
    void Update(){
        move =  new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        
        rb.AddForce(move * speed);
        if(health == 0){
            score = 0;
            health = 5;
            winLostText.text = "Game Over!";
            winLostImage.SetActive(true);
            winLostImage.GetComponent<Image>().color = new Color(255,0,0,200);
            winLostText.color = new Color(255,255,255);
            StartCoroutine(LoadScene(3));
        }

        

    }
    IEnumerator LoadScene(float seconds){
       yield return new WaitForSeconds(seconds);
         SceneManager.LoadScene("mazeAndroid");
    }
   
            public void escapebutton (int escape){
            if(escape == 4){
            SceneManager.LoadScene("menu");
        }

}
    public void movebuttos (int button){
        if(button == 0){
            rb.AddForce(Vector3.left*10);
            Debug.Log ("left");
        }
        else if(button == 1){
            rb.AddForce(Vector3.forward*10);
        }
        else if(button == 2){
            rb.AddForce(Vector3.back*10);
        }
        else if(button == 3){
            rb.AddForce(Vector3.right*10);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Pickup"){
            score++;
            SetScoreText();
            //Debug.Log("Score: " + score);
        }
        if (other.tag == "Trap"){
            health--;
            SetHealthText();
           // Debug.Log("Health: " + health);
        }
        if(other.tag == "Goal"){
            StartCoroutine(LoadScene(3));
            winLostText.text = "You win!";
            winLostImage.SetActive(true);
            winLostImage.GetComponent<Image>().color = new Color(0,255,0,200);
            winLostText.color = new Color(0,0,0);
            //Debug.Log("You win!");
        }
    }
}
