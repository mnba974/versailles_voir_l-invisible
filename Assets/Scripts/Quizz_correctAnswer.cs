using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quizz_correctAnswer : MonoBehaviour
{
    public Animator tiroirAnim;
    public Transform tiroirTransf;
    public GameObject prefabToSpawn;

    public void CorrrectAnswer()
    {
        tiroirAnim.SetTrigger("openTiroir");
        Instantiate(prefabToSpawn, tiroirTransf);

        // + anim, �cran "Bonne r�ponse"
    }

    public void WrongAnswer()
    {
        // Do something
    }
}
