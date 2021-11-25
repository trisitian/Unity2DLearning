using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float dealay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip effect;
    bool hasCrashed;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Ground" && !hasCrashed){
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(effect);
            hasCrashed = true;
        }
        Invoke("reloadScene", dealay);
    }
    void reloadScene(){
        SceneManager.LoadScene(0);
    }
}
