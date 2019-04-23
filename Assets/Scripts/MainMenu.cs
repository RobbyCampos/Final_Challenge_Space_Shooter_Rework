using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    public void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Final_Base");
    }

    public void PlayTimeAttack()
    {
        SceneManager.LoadScene("Final_Base");
        StaticTimeCheck.timeAttackCheck = true;
    }
}
