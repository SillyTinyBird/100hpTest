using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshPro;

    [SerializeField] Button button;
    [SerializeField] Image attachedImage;
    [SerializeField] QuestionAnswerState questionAnswerState;

    public bool IsRightAnswer { get; set; }
    public string Text { 
        get
        {
            return m_TextMeshPro.text;
        }
        set
        {
            m_TextMeshPro.text = value;
        }
    }
    public Color Color
    {
        get
        {
            return attachedImage.color;
        }
        set
        {
            attachedImage.color = value;
        }
    }

    private void Awake()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    public void SetButton(string text, bool isRightAnswer)
    {
        this.IsRightAnswer = isRightAnswer;
        Text = text;
        Color = Color.white;
    }
    void TaskOnClick()
    {
        if(IsRightAnswer)
        { 
            Color = Color.green; 
        }
        else 
        { 
            Color = Color.red;
        }
        questionAnswerState.GetButtonPressAnswer(IsRightAnswer);
    }

}
