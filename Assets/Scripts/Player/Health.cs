using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int MashNumber;
    [SerializeField] private float MashTimer;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriterend;
    private float currentMashNumber;
    public float timeLimit = 10f;      // Time limit in seconds
    //private bool gameOver = false;     // Flag to check if the game is over

    public bool gothit = false;

    public bool gothitcheck{
        get{ 
            return gothit; 
            }

        set{ 
            if(gothit != value){ //check if the value actually changes
                gothit = value;
                Debug.Log("Hit status changed to: "+ gothit);
            } 
            }
    }
    private void Awake()
    {
        spriterend = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

    }
    public void beenDamaged(){
        gothit = true;
        Debug.Log("You got hit!!");
        StartCoroutine(DamagedTaken());
       
    }
    public IEnumerator DamagedTaken(){
        // Reset the counter and timer
        float timer = 0f;
        currentMashNumber = 0;
        // Run the loop until 10 presses or the timer expires
        while (currentMashNumber < MashNumber && timer < timeLimit)
        {
            // Check if the spacebar is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentMashNumber++;
                Debug.Log("Spacebar pressed! Count: " + currentMashNumber);
            }

            // Increment the timer
            timer += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Check if the player won or lost
        if (currentMashNumber >= MashNumber)
        {
            Debug.Log("You pressed the spacebar "+ MashNumber + " times! You Survived!");
            MashNumber = MashNumber * 2;
            StartCoroutine(Invulnerability());
        }
        else
        {
            Debug.Log("Time's up! You lose!");
            //gameOver = true;
            // Add actions for losing here
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriterend.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(1);
            spriterend.color = Color.white;
            yield return new WaitForSeconds(1);
        }
        //Invulnerability
        Physics2D.IgnoreLayerCollision(8, 9, false);
        gothit = false;
    }
}

