using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO curentQuestion; 

    [Header("Answers")]
    [SerializeField] GameObject[] answers;
    bool hasAnsweredEarly;
    [Header("Buttons")]
    [SerializeField] Sprite defaulAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer t;
    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI score;
    ScoreKeeper s;



    // Start is called before the first frame update
    void Start()
    {
        t = FindObjectOfType<Timer>();
        s = FindObjectOfType<ScoreKeeper>();
        score.text = "";
    }

    void Update(){
        timerImage.fillAmount = t.fillFraction;
        if(t.LoadNext){
            hasAnsweredEarly = false;
            GetNextQuestion();
            t.LoadNext = false;
        }else if(!hasAnsweredEarly && !t.isAnswering){
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    void SetButtonState(bool state){
        for(int i = 0; i <answers.Length; i++){
            Button b = answers[i].GetComponent<Button>();
            b.interactable = state;
        }
    }

    void GetNextQuestion(){
        if(questions.Count > 0){
            SetButtonState(true);
            SetDefault();
            GetRandomQuestion();
            PopulateQuestions();
            s.setQuestionsSeen();
        }
    }

    void GetRandomQuestion(){
        int index = Random.Range(0,questions.Count);
        curentQuestion = questions[index];
        if(questions.Contains(curentQuestion)){
            questions.Remove(curentQuestion);
        }
    }

    public void OnAnswerSelect(int index){
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        t.CancelTimer();
        score.text = "Score " + s.CalculateCorrectAnswers() + "%";
    }

    void PopulateQuestions(){

        for(int i = 0; i < answers.Length; i++){
            questionText.text = curentQuestion.GetQuestion();
            TextMeshProUGUI buttonTest = answers[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonTest.text = curentQuestion.getAnswer(i);
        }
    }

    void SetDefault(){
        Image buttonImage;
        for(int i = 0; i < answers.Length; i++){
            buttonImage = answers[i].GetComponentInChildren<Image>();
            buttonImage.sprite = defaulAnswerSprite;
        }
    }

    void DisplayAnswer(int index){
        if(index == curentQuestion.getAnswerIndex()){
            questionText.text = "Correct!";
            s.setCorrectAnswers();
        }else if(index == -1){
            questionText.text = "We all get stuck sometimes, thats ok the correct answer was \n" + curentQuestion.getAnswer();
        }else{
            questionText.text = "That's unfortunately the incorrect answer, the correct answer is \n" + curentQuestion.getAnswer();
        }
        Image buttonImage = answers[curentQuestion.getAnswerIndex()].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
    }

}
