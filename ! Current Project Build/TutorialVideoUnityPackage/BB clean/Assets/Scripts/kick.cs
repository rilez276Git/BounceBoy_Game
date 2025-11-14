using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kick : MonoBehaviour
{

    public GameObject Kick;

    public float kickTime;
    public bool kickOn;

    public Image cooldownBar;

    public float kickCooldown;
    public float maxKickCooldown;

    public AudioSource audioSrc;
    public AudioClip kicksound;

    private Animator _movementAnimator;
    
    void Start()
    {
        Kick.SetActive(false);
        kickTime = 1.0f;
        kickOn = false;
        kickCooldown = 0.0f;
        _movementAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        kickCooldown -= Time.deltaTime;

         if (kickCooldown < 0.0f)
			{
				kickCooldown = 0.0f;
			}

        cooldownBar.fillAmount = (float)kickCooldown / (float)maxKickCooldown;

        if(Input.GetMouseButton(1) && kickCooldown == 0.0f) 
        {
            block();
            audioSrc.clip = kicksound;
			audioSrc.Play();    
        }

        if(kickOn == true)
        {
            kickTime -= Time.deltaTime;
        }

        if (kickTime < 0.0f)
			{
				kickTime = 0.0f;
			}

        if(kickTime == 0.0f)
        {
            kickOn = false;
            Kick.SetActive(false);
        }
    }

    private void block()
    {
        Kick.SetActive(true);
        kickOn = true;
        kickTime = 1.0f;
        kickCooldown = maxKickCooldown;
    }
}
