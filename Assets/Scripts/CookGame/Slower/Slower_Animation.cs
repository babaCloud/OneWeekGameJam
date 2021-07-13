using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sakuGame.BGM;
using Zenject;
public class Slower_Animation : MonoBehaviour
{
    //[Inject]
    //IWhen_RhythmTiming when_RhythmTiming;
    //[Inject]
    //IWhen_SlowTiming when_SlowTiming;
    Animator animator;
    void Start()
    {
        //when_RhythmTiming.RhythmTimingEvent += StayAnimaTion;
        //when_SlowTiming.NowSlowEvent += SlowAnimation;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SlowAnimation();
        }
    }
    void StayAnimaTion()
    {

    }
    public void SlowAnimation()
    {
        animator.SetTrigger("Throw");   
    }

}
