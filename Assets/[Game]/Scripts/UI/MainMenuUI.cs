using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    //private const string GAMESCENE = "GameScene";



    private void Awake()
    {
        playButton.onClick.AddListener(() => //lambda expression
        {
            // Click
            //SceneManager.LoadScene(1);
            Loader.Load(Loader.Scene.GameScene);
        });
        quitButton.onClick.AddListener(() => //lambda expression
        {
            Application.Quit();
        });
    }
    /*
    private void PlayClick()
    {

    }*/

}
