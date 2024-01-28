using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeObject;
    private Animator fadeAnimation;

    [SerializeField]
    private Image blurImage;

    private bool isStarting;
    private bool isQuitting;
    private bool isTeaching;
    private bool isGoingBack;

    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (currentScene.name != "EndScene")
        {
            fadeAnimation = fadeObject.GetComponent<Animator>();
            fadeObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene.name != "EndScene")
        {
            if (blurImage.color.a == 1)
            {
                //print("Change scene");
                if (isStarting)
                    SceneManager.LoadScene("Elevator 1");
                else if (isQuitting)
                    Application.Quit();
                else if (isTeaching)
                { SceneManager.LoadScene("HowToPlay"); print("Yes"); }
                else if (isGoingBack)
                    SceneManager.LoadScene("TitleScreen");
            }
        }
    }

    public void StartGame()
    {
        isStarting = true;
        fadeObject.SetActive(true);
        fadeAnimation.Play("blur");
    }

    public void HowToPlay()
    {
        isTeaching = true;
        fadeObject.SetActive(true);
        fadeAnimation.Play("blur");
    }

    public void Back()
    {
        isGoingBack = true;
        fadeObject.SetActive(true);
        fadeAnimation.Play("blur");
    }

    public void QuitGame()
    {
        if (currentScene.name != "EndScene")
        {
            fadeObject.SetActive(true);
            fadeAnimation.Play("blur");
            isQuitting = true;
        }
        else
            Application.Quit(); print("Quit");
    }
}
