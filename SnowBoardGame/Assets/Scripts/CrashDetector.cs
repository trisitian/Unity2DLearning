using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float dealay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip effect;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Ground"){
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(effect);
            Invoke("reloadScene", dealay);
        }
    }
    void reloadScene(){
        SceneManager.LoadScene(0);
    }
}
