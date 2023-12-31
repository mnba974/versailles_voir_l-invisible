using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quizz_Answers : MonoBehaviour
{
    public Animator tiroirAnim;
    public string animName;
    public GameObject QAPanel;
    public GameObject CAPanel;
    public GameObject WAPanel;
    public ItemSO item;

    public void CorrrectAnswer()
    {
        QAPanel.SetActive(false);
        CAPanel.SetActive(true);

        item.correctAnswer = true;

        tiroirAnim.SetTrigger(animName);
    }

    public void WrongAnswer()
    {
        QAPanel.SetActive(false);
        WAPanel.SetActive(true);
    }
}
