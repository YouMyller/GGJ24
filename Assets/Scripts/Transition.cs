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

    // Start is called before the first frame update
    void Start()
    {
        fadeAnimation = fadeObject.GetComponent<Animator>();
        fadeObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene("Transit");
        }

        //print(blurImage.color.a);

        if (blurImage.color.a == 1)
        {
            //print("Change scene");
            SceneManager.LoadScene("Elevator");
        }
    }

    public void StartGame()
    {
        fadeObject.SetActive(true);
        print("play");
        fadeAnimation.Play("blur");
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Quit!");
    }
}
