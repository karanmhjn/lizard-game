using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    // Goes back to main meunu
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
}
