using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quizz_correctAnswer : MonoBehaviour
{
    public Animator tiroirAnim;
    public Transform tiroirTransf;
    public GameObject prefabToSpawn;

    public GameObject QAPanel;
    public GameObject CAPanel;
    public GameObject WAPanel;

    public void CorrrectAnswer()
    {
        tiroirAnim.SetTrigger("openTiroir");
        Instantiate(prefabToSpawn, tiroirTransf);

        QAPanel.SetActive(false);
        CAPanel.SetActive(true);
    }

    public void WrongAnswer()
    {
        QAPanel.SetActive(false);
        WAPanel.SetActive(true);
    }
}
