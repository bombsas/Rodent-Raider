using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            myAudioSource.Play();
        }
    }
}
