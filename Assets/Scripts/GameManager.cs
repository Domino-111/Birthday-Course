using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText, fallsText;
    public float time = 0f;
    public int falls;
    public GameObject instructions;
    public bool isPlaying;

    void Awake()
    {
        instructions.SetActive(false);
        isPlaying = false;
    }

    void Start()
    {

    }

    void Update()
    {
        // Close the instructions to return to main menu
        if (Input.GetKeyDown(KeyCode.Tab) && isPlaying == false)
        {
            instructions.SetActive(false);
        }

        // Close the game back to desktop
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            print("Game Closed");
        }

        // Start timer once the game begins
        if (isPlaying == true)
        {
            time = Time.deltaTime;
        }


    }

    // On UI button push bring up the instructions text
    public void InstructionsOn()
    {
        instructions.SetActive(true);
    }

    // On UI button push begin the game
    public void StartGame()
    {
        isPlaying = true;

    }
}
