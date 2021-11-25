using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem trailEffect;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag == "Ground"){
            trailEffect.Play();
        }
    }

    void OnCollisionExit2D(Collision2D coll){
        if(coll.gameObject.tag == "Ground"){
            trailEffect.Stop();
        }
    }
}
