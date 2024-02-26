using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public void ClickStart() {
        SceneManager.LoadScene("MacoTestInventaire2");
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }
}
