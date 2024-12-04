using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myAudioSource.Play();
        }
    }
 }
