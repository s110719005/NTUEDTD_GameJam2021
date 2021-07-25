using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void ExitGame(){
        Application.Quit();
        Debug.Log("Exit game!");
    }
    public void ReloadGame(){
        GameObject.DestroyImmediate(MovementManager.Instance.Player1.gameObject);
        GameObject.DestroyImmediate(MovementManager.Instance.Player2.gameObject);
        Scene scene = SceneManager.GetActiveScene(); 
        //SceneManager.LoadScene(0);
        SceneManager.LoadScene(scene.name);
        Debug.Log("Reload game!");

    }
}
