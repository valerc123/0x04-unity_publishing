using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    void Start()
    {
        
    }
    public void PlayMaze(){
        SceneManager.LoadScene("maze");
        if(colorblindMode.GetComponent<Toggle>().isOn == true){
            trapMat.color = new Color(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }else{
            trapMat.color = Color.red;//new Color(255, 112, 0, 1);
            goalMat.color = Color.green;
        }
    }
    public void QuitMaze(){
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Quit Game");
       // Application.Quit();
    }
}
