using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameTutorial : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadSceneAsync(4);
    }
}
