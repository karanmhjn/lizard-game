using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [SerializeField] private IntSO livesSO;
    [SerializeField] private FloatSO scoreSO;



    private void Awake()
    {
        // Setting up initial values of score and lives
        livesSO.Value = 3;
        scoreSO.Value = 0;
    }
    // Starts the game
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
