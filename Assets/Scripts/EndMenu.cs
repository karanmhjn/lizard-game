using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private FloatSO scoreSO;

    // Start is called before the first frame update
    void Awake()
    {
        scoreText.text = "Your Score: " + scoreSO.Value;
    }

    // Goes back to main meunu
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
}
