using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToComplete = 30f;
    [SerializeField] float timeToReview = 10f;

    public bool LoadNext;
    public float fillFraction;

    public bool isAnswering;
    float timerValue;
    // Update is called once per frame
    void Update()
    {   
        UpdateTimer();
    }

    public void CancelTimer(){
        timerValue = 0;
    }

    void UpdateTimer(){
        timerValue -= Time.deltaTime;

        if(isAnswering){
            if(timerValue > 0){
                fillFraction = timerValue/timeToComplete;
            }else{
                isAnswering = false;
                timerValue = timeToReview;
            }
        }else{
            if(timerValue > 0){
                fillFraction = timerValue/timeToReview;
            }else{
                isAnswering = true;
                timerValue = timeToComplete;
                LoadNext = true;
            }
        }
    }


}
