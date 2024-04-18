using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        // Load the next scene (assuming it's the game scene)
        SceneManager.LoadScene("Main");
    }
}



