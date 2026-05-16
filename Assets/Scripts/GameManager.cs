using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Establish variables
    public TMP_Text timerText, fallsText;
    public float time = 0f;
    public int falls;

    public GameObject instructions, title, playButton, instructionsButton, timer, fallsCounter;
    public float speed;

    public bool isPlaying;

    // Ensures values are set before game loads
    void Awake()
    {
        instructions.SetActive(false);
        isPlaying = false;
        Time.timeScale = 0f;

        timer.SetActive(false);
        fallsCounter.SetActive(false);
    }

    void Update()
    {
        // Close the game back to desktop
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            print("Game Closed");
        }

        // Start timer once the game begins
        if (isPlaying == true)
        {
            Timer();
        }

        fallsText.text = "Falls : " + falls;

        // Press enter to start the game
        if (Input.GetKeyDown(KeyCode.Return) && isPlaying == false)
        {
            StartGame();
        }
    }

    // On UI button push bring up the instructions text
    public void InstructionsOn()
    {
        instructions.SetActive(true);
    }

    // On UI button push close the instructions
    public void InstructionsOff()
    {
        instructions.SetActive(false);
    }

    // Begin the game
    public void StartGame()
    {
        title.SetActive(false); // Hide the title when the game begins

        isPlaying = true;

        Time.timeScale = 1f;

        // Hide the buttons from the player when the game begins
        playButton.SetActive(false);
        instructionsButton.SetActive(false);

        // Show score trackers
        timer.SetActive(true);
        fallsCounter.SetActive(true);
    }

    // Time how long the player has been playing
    private void Timer()
    {
        time = Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        timerText.text = "Time : " + timeSpan + "s";
    }
}
