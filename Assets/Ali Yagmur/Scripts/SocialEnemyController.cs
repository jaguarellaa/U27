using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SocialEnemyController : MonoBehaviour
{
    GameObject player;
    Transform playerTransform;
    Rigidbody rb;

    [SerializeField] GameObject objectMesh;

    [SerializeField] bool isPositive;

    [SerializeField] int minTimeCost;
    [SerializeField] int maxTimeCost;

    [SerializeField] float minLifeTime;
    [SerializeField] float maxLifeTime;

    [SerializeField] float speed;
    [SerializeField] float accSpeed;

    [SerializeField] GameObject particleRed;
    [SerializeField] GameObject particleBlue;

    [SerializeField] TextMeshPro textOnTop;

    [SerializeField] int type;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();

        rb = gameObject.GetComponent<Rigidbody>();

        float countdown = Random.Range(minLifeTime, maxLifeTime);
        StartCoroutine(WillBeDestroyedAfterCountdown(countdown));

        /*
        int randomNumberA = Random.Range(1, 11);

        if (type == 1)
        {
            switch (randomNumberA)
            {
                case 1:
                    textOnTop.text = "Want to grab some coffee?";
                    break;
                case 2:
                    textOnTop.text = "Let's go for a walk.";
                    break;
                case 3:
                    textOnTop.text = "How about a movie night?";
                    break;
                case 4:
                    textOnTop.text = "Let's try a new restaurant.";
                    break;
                case 5:
                    textOnTop.text = "Want to go hiking together?";
                    break;
                case 6:
                    textOnTop.text = "How about a game night?";
                    break;
                case 7:
                    textOnTop.text = "Let's go to the beach.";
                    break;
                case 8:
                    textOnTop.text = "Want to go shopping together?";
                    break;
                case 9:
                    textOnTop.text = "Let's have a picnic outside.";
                    break;
                case 10:
                    textOnTop.text = "How about a bike ride?";
                    break;
                default:
                    textOnTop.text = "How about a game night?";
                    break;
            }
        }
        else if (type == 2)
        {
            switch (randomNumberA)
            {
                case 1:
                    textOnTop.text = "Play Minecraft without building anything.";
                    break;
                case 2:
                    textOnTop.text = "Try playing a racing game blindfolded.";
                    break;
                case 3:
                    textOnTop.text = "Complete Dark Souls using only dance pads.";
                    break;
                case 4:
                    textOnTop.text = "Play Mario Kart with your feet.";
                    break;
                case 5:
                    textOnTop.text = "Try playing Call of Duty upside down.";
                    break;
                case 6:
                    textOnTop.text = "Complete a puzzle game using only your nose.";
                    break;
                case 7:
                    textOnTop.text = "Play a horror game with the sound off.";
                    break;
                case 8:
                    textOnTop.text = "Complete a platformer game without jumping.";
                    break;
                case 9:
                    textOnTop.text = "Try playing a sports game with no hands.";
                    break;
                case 10:
                    textOnTop.text = "Play a strategy game blindfolded with random clicks.";
                    break;
                default:
                    textOnTop.text = "Complete Dark Souls using only dance pads.";
                    break;
            }
        }
        else
        {
            switch (randomNumberA)
            {
                case 1:
                    textOnTop.text = "Study Game Design.";
                    break;
                case 2:
                    textOnTop.text = "Study C#.";
                    break;
                case 3:
                    textOnTop.text = "Study Unity 3D.";
                    break;
                case 4:
                    textOnTop.text = "Study Project Management.";
                    break;
                case 5:
                    textOnTop.text = "Study English.";
                    break;
                case 6:
                    textOnTop.text = "Study entrepreneurship.";
                    break;
                case 7:
                    textOnTop.text = "Study Unity 2D.";
                    break;
                case 8:
                    textOnTop.text = "Study Flutter.";
                    break;
                case 9:
                    textOnTop.text = "Make a game demo.";
                    break;
                case 10:
                    textOnTop.text = "Make an app demo.";
                    break;
                default:
                    textOnTop.text = "Study.";
                    break;
            }
        }

        */

    }

    void FixedUpdate()
    {
        MoveTowardsPlayer();
        LookAtPlayer();
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (new Vector3(playerTransform.position.x, 0, playerTransform.position.z) - transform.position).normalized;

        if (rb.velocity.magnitude < speed)
        {
            rb.AddForce(direction * accSpeed, ForceMode.Force);
        }

    }

    void LookAtPlayer()
    {
        objectMesh.transform.LookAt(playerTransform);
    }




    private void OnCollisionEnter(Collision collision)
    {
        //if the collision is player, run a function in player script that causes to lose time

        if (collision.gameObject.CompareTag("Player"))
        {
            if (isPositive)
            {
                Instantiate(particleRed, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                collision.gameObject.GetComponent<PlayerControllerForSocialEnemies>().GetAcademyPoints(Random.Range(minTimeCost, maxTimeCost));
            }
            else
            {
                Instantiate(particleRed, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                collision.gameObject.GetComponent<PlayerControllerForSocialEnemies>().GetDamage(Random.Range(minTimeCost, maxTimeCost));
            }
            Destroy(this.gameObject);

        }
    }

    IEnumerator WillBeDestroyedAfterCountdown(float time)
    {
        yield return new WaitForSeconds(time);

        Instantiate(particleBlue, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
