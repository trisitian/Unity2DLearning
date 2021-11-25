using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float dealay = 1f;
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Ground"){
            Invoke("reloadScene", dealay);
        }
    }
    void reloadScene(){
        SceneManager.LoadScene(0);
    }
}
