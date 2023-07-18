using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    AudioSource animationSoundPlayer;
    public AudioSource[] audioSources;
    public float footstepCooldown = 0.5f; 
    private float nextFootstepTime; 
    public float normalSpeed = 1f; 
    public float sprintSpeed = 2f; 


    void Start()
    {
        animationSoundPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        float footstepSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : normalSpeed;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Time.time >= nextFootstepTime)
            {
                PlayerFootstepSound(footstepSpeed);
                nextFootstepTime = Time.time + footstepCooldown / footstepSpeed;
            }
        }
    }

    private void PlayerFootstepSound(float speed)
    {
        int randomIndex = Random.Range(0, audioSources.Length);
        AudioSource randomSource = audioSources[randomIndex];

        animationSoundPlayer.clip = randomSource.clip;
        animationSoundPlayer.pitch = speed;
        animationSoundPlayer.Play();
    }
}
