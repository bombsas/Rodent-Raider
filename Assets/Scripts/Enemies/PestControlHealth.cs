using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestControlHealth : MonoBehaviour
{
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriterend;
    private float currentMashNumber;
    public float timeLimit = 10f;      // Time limit in seconds
    //private bool gameOver = false;     // Flag to check if the game is over

    public bool gothit = false;

    public bool gothitcheck
    {
        get
        {
            return gothit;
        }

        set
        {
            if (gothit != value)
            { //check if the value actually changes
                gothit = value;
                Debug.Log("Hit status changed to: " + gothit);
            }
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
