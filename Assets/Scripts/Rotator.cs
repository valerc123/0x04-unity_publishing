using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float degreesPerSecond = 45f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate( degreesPerSecond * Time.deltaTime, 0, 0);
    }
    void OnTriggerEnter(){
        gameObject.SetActive(false);
    }
}
