using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPlateController : MonoBehaviour
{
    [SerializeField] Image plate;

    public bool IsRightAnswer { get; set; }

    public Color Color
    {
        get
        {
            return plate.color;
        }
        set
        {
            plate.color = value;
        }
    }



    public void SetEnemyAnswer(bool isRightAnswer)
    {
        IsRightAnswer = isRightAnswer;
        Color = Color.white;
    }

    public bool ShowEnemyResult()
    {
        if (IsRightAnswer)
        {
            Color = Color.green;
        }
        else
        {
            Color = Color.red;
        }

        return IsRightAnswer;
    }
}
            
