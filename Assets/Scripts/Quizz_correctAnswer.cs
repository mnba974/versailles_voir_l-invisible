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
        // if(ce bouton = bonne r�ponse)...
        tiroirAnim.SetTrigger("openTiroir");
        Instantiate(prefabToSpawn, tiroirTransf);
    }
}
