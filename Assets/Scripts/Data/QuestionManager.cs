using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    private List<QuestionModel> questions;
    private int currentNextQuestionIndex;

    [SerializeField] private int amountOfQuestions = 5;

    public static QuestionManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        ReloadQuestions();
    }

    public bool TryGetNextQuestion(out QuestionModel question)
    {
        var result = true;
        question = null;



        question = questions[currentNextQuestionIndex];
        currentNextQuestionIndex++;

        if (currentNextQuestionIndex >= questions.Count)
            result = false;

        return result;
    }

    public void ReloadQuestions()
    {
        var questionsData = DataAdapter.GetAllQuestions().questions;
        var rng = new System.Random();
        rng.Shuffle(questionsData);
        this.questions = questionsData.Take(amountOfQuestions).ToList();
        currentNextQuestionIndex = 0;
    }
}
