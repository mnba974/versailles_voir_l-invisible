using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandorAnim : MonoBehaviour
{
    public Animator animator;
    public float start;
    // Start is called before the first frame update
    void OnEnable()
    {
       start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - start> 1.0f)
        {
            animator.Play("Base Layer.anim",0,0.0f);
            this.enabled = false;
        }
    }
}
