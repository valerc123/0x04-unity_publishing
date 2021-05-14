using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
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
    void Start()
    {
        winLostImage = GameObject.Find("WinLoseBG");
        winLostImage.SetActive(false);
        rb = GetComponent<Rigidbody>();
        speed = 10f;
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

        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("menu");
        }
    }
    IEnumerator LoadScene(float seconds){
       yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("maze");
    }
    public void FixedUpdate(){
        if(Input.GetKey(KeyCode.A)){
            rb.AddForce(Vector3.left);
        }
        else if(Input.GetKey(KeyCode.W)){
            rb.AddForce(Vector3.forward);
        }
        else if(Input.GetKey(KeyCode.S)){
            rb.AddForce(Vector3.back);
        }
        else if(Input.GetKey(KeyCode.D)){
            rb.AddForce(Vector3.right);
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
