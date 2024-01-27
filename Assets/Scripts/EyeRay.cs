using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EyeRay : MonoBehaviour
{
    [SerializeField]
    private bool debugging;
    [SerializeField]
    private float distance;

    private bool eyeContact;

    private float timer;

    [SerializeField]
    private float FailCondition;

    private GameObject PlayerEyes;

    private GameObject Player;

    [SerializeField]
    private float minDistanceToPlayer;

    private bool TooClose;

    [SerializeField]
    private Slider mainSlider;

    private GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        eyeContact = false;
        PlayerEyes = GameObject.FindWithTag("PlayerEyes");
        Player = GameObject.FindWithTag("Player");
        mainSlider = GameObject.FindWithTag("Slider").GetComponent<Slider>();
        gameOverText = GameObject.Find("GameOver");
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        EyeSight();

        if(eyeContact == true)
        {
            TooClose = true;

            if(debugging == true)
            {
                Debug.Log("EyeContact" + ", Timer: " + timer);
            }
            
        }

        else
        {
            TooClose = false;
        }

        if(timer > FailCondition)
        {
            Debug.Log("GameOver");
            gameOverText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Scene thisScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(thisScene.name);
            }
        }

        if(Vector3.Distance(Player.transform.position, transform.position) < minDistanceToPlayer)
        {
            TooClose = true;
            Debug.Log("TooClose" + ", Timer: " + timer);
            
        }

        else if(Vector3.Distance(Player.transform.position, transform.position) > minDistanceToPlayer && eyeContact == false)
        {
            TooClose = false;
        }

        if (TooClose == true) { 
        
            timer += Time.deltaTime;

        }

        else
        {
            timer = 0;
        }

        mainSlider.value = timer;
        
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
}
