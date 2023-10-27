using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quizz_Answers : MonoBehaviour
{
    public Animator tiroirAnim;

    public GameObject QAPanel;
    public GameObject CAPanel;
    public GameObject WAPanel;

    public void CorrrectAnswer()
    {
        tiroirAnim.SetTrigger("openTiroir");

        QAPanel.SetActive(false);
        CAPanel.SetActive(true);
    }

    public void WrongAnswer()
    {
        QAPanel.SetActive(false);
        WAPanel.SetActive(true);
    }
}
