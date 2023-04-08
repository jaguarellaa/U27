using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialEnemyController : MonoBehaviour
{
    GameObject player;
    Transform playerTransform;
    Rigidbody rb;

    [SerializeField] bool isPositive;

    [SerializeField] int minTimeCost;
    [SerializeField] int maxTimeCost;

    [SerializeField] float minLifeTime;
    [SerializeField] float maxLifeTime;

    [SerializeField] float speed;
    [SerializeField] float accSpeed;

    [SerializeField] GameObject particleRed;
    [SerializeField] GameObject particleBlue;



    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();

        rb = gameObject.GetComponent<Rigidbody>();

        float countdown = Random.Range(minLifeTime, maxLifeTime);
        StartCoroutine(WillBeDestroyedAfterCountdown(countdown));

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
        transform.LookAt(playerTransform);
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
