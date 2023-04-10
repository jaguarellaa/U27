using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControllerForSocialEnemies : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject characterModel;
    [SerializeField] SocialEnemySpawner enemySpawner;
    [SerializeField] GameObject endObject;
    [SerializeField] GameObject endText;
    GameObject sceneManager;

    [SerializeField] float gameTime;
    private float academyPoints = 0;

    private bool keepCounting = true;
    private bool gameIsOver = false;

    public Image social;
    public float maxTime;
    public float lastTime;

    private void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
    }

    private void Update()
    {
        Movement();
        if(keepCounting == true)
        {
            gameTime -= Time.deltaTime;
            social.fillAmount = gameTime / maxTime;
        }
        
        
        if (academyPoints > 20 && gameIsOver == false)
        {
            //end the game
            enemySpawner.StopSpawningEnemies();
            endObject.SetActive(true);
            endText.SetActive(true);
            keepCounting = false;
            if (gameTime > 75)
            {
                academyPoints *= 4;
            }
            else if (gameTime > 50)
            {
                academyPoints *= 3;
            }
            else if (gameTime > 25)
            {
                academyPoints *= 2;
            }
            if (academyPoints > 100)
            {
                academyPoints = 100;
            }
            sceneManager.GetComponent<SceneManagerScript>().SetAcademyPoints(academyPoints);
            sceneManager.GetComponent<SceneManagerScript>().SocialTime = gameTime;
            gameIsOver = true;
        }
    }

    void FixedUpdate()
    {
        float horizontalInputRB = Input.GetAxis("Horizontal");
        float verticalInputRB = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInputRB, 0f, verticalInputRB).normalized;
        if (moveDirection.magnitude != 0f)
        {
            rb.velocity = moveDirection * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        

        characterModel.transform.localPosition = Vector3.zero;

        if (movementDirection.magnitude != 0)
        {
            animator.SetBool("Move", true);
            float angle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }
        else
        {
            animator.SetBool("Move", false);
        }

        movementDirection.Normalize();

        Vector3 movementAmount = movementDirection * speed * Time.deltaTime;

        //transform.position += new Vector3(movementAmount.x, 0, movementAmount.z);
    }

    public void GetDamage(int timeLost)
    {
        gameTime -= timeLost;
        Debug.Log("You have lost " + timeLost + " seconds!");
    }

    public void GetAcademyPoints(int points)
    {
        academyPoints += points;
        Debug.Log("You have gained " + points + " points!");
    }
}
