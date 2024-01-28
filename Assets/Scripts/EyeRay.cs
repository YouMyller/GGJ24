using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EyeRay : MonoBehaviour
{
    [SerializeField]
    private bool debugging;
    [SerializeField]
    private float distance;

    private static bool eyeContact;

    private float timer;

    [SerializeField]
    private float FailCondition;

    private GameObject PlayerEyes;

    private GameObject Player;

    [SerializeField]
    private float minDistanceToPlayer;

    [SerializeField]
    private Slider mainSlider;

    private GameObject gameOverText;

    private bool isGameOver;

    private GameObject fadeObject;
    private Animator fadeAnimation;

    private AudioSource levelTheme;
    private AudioSource deathTheme;

    private bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        eyeContact = false;
        PlayerEyes = GameObject.FindWithTag("PlayerEyes");
        Player = GameObject.FindWithTag("Player");
        mainSlider = GameObject.FindWithTag("Slider").GetComponent<Slider>();
        gameOverText = GameObject.Find("GameOver");
        gameOverText.GetComponent<TextMeshProUGUI>().enabled = false;
        fadeObject = GameObject.Find("FadeOut");
        fadeAnimation = fadeObject.GetComponent<Animator>();
        fadeAnimation.enabled = false;
        levelTheme = GameObject.Find("SoundPlayer").GetComponent<AudioSource>();
        deathTheme = GameObject.Find("SoundPlayer GameOver").GetComponent<AudioSource>();
        //gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        EyeSight();

        if(eyeContact == true && isGameOver == false)
        {
            mainSlider.GetComponent<SliderValue>().seen = true;
            if (debugging == true)
            {
                //Debug.Log("EyeContact" + ", Timer: " + timer);
            }
            
        }

        else
        {
            //mainSlider.GetComponent<SliderValue>().active = false;
            mainSlider.GetComponent<SliderValue>().seen = false;
        }

        if(mainSlider.value >= FailCondition)
        {
            isGameOver = true;
            gameOverText.GetComponent<TextMeshProUGUI>().enabled = true;
            Player.transform.GetChild(0).GetComponent<Camera>().enabled = false;
            fadeAnimation.enabled = true;

            fadeAnimation.Play("blur");

            levelTheme.Stop();

            if (!isPlaying)
            {
                deathTheme.Play();
                isPlaying = true;
            }

            if (Input.GetMouseButtonDown(1))
            {
                Scene thisScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(thisScene.name);
            }
        }

        /*if(Vector3.Distance(Player.transform.position, transform.position) < minDistanceToPlayer)
        {
            TooClose = true;
            print("Too close");
            //Debug.Log("TooClose" + ", Timer: " + timer);
            
        }*/


        else if (!isGameOver)
        {
            //mainSlider.value = 0;
        }

        if(isGameOver == true)
        {
            mainSlider.GetComponent<SliderValue>().dead = true;
        }

        //mainSlider.value = timer;
        //Debug.Log(mainSlider.value);
        
    }

    private RaycastHit EyeSight()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;



        Vector3 endPos = transform.position + (distance * transform.forward);
        if (Physics.Raycast(ray, out hit, distance))
        {

            endPos = hit.point;



            if (Physics.Raycast(ray, out hit, distance))
            {
                endPos = hit.point;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "PlayerEyes")
                    {
                        eyeContact = true;
                    }
                }
            }
            else
            {
                Debug.Log("No Hit");
                eyeContact = false;
                //timer = 0;
            }

            

            
        }

        else
        {
            eyeContact = false;
            //timer = 0;
        }

        if (debugging)
        {
            Debug.DrawLine(transform.position, endPos, Color.green);
        }

        

        return hit;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isGameOver == false)
        {
            mainSlider.GetComponent<SliderValue>().active = true;
            //Debug.Log("Active");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainSlider.GetComponent<SliderValue>().active = false;
        }
    }
}
