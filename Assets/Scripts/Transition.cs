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

    // Start is called before the first frame update
    void Start()
    {
        fadeAnimation = fadeObject.GetComponent<Animator>();
        fadeObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (blurImage.color.a == 1)
        {
            //print("Change scene");
            if (isStarting)
                SceneManager.LoadScene("Elevator");
            else if (isQuitting)
                Application.Quit();
            else if (isTeaching)
            { SceneManager.LoadScene("HowToPlay"); print("Yes"); }
            else if (isGoingBack)
                SceneManager.LoadScene("TitleScreen");
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
        isQuitting = true;
        fadeObject.SetActive(true);
        fadeAnimation.Play("blur");
    }
}
