using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Establish variables
    public TMP_Text timerText, fallsText;
    public float time = 0f;
    public int falls;

    public GameObject instructions, title;
    public float speed;

    public bool isPlaying;

    // Ensures values are set before game loads
    void Awake()
    {
        instructions.SetActive(false);
        isPlaying = false;
        Time.timeScale = 0f;
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
            timerText.text = "Time : " + time.ToString("#.00") + "s";
        }

        fallsText.text = "Falls : " + falls;
    }

    // On UI button push bring up the instructions text
    public void InstructionsOn()
    {
        instructions.SetActive(true);
    }

    // On UI button push begin the game
    public void StartGame()
    {
        title.SetActive(false);
        isPlaying = true;
        Time.timeScale = 1f;
    }
}
