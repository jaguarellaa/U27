using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialEnemyController : MonoBehaviour
{
    GameObject player;
    Transform playerTransform;
    Rigidbody rb;

    [SerializeField] int minTimeCost;
    [SerializeField] int maxTimeCost;

    [SerializeField] float minLifeTime;
    [SerializeField] float maxLifeTime;

    [SerializeField] float speed;
    [SerializeField] float accSpeed;



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
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;

        if (rb.velocity.magnitude < speed)
        {
            rb.AddForce(direction * accSpeed, ForceMode.Force);
        }

    }

    void MoveTowardsPlayerWithTransform()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance > 0.1f)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            transform.Translate(direction * speed * Time.deltaTime);

        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        //if the collision is player, run a function in player script that causes to lose time

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControllerForSocialEnemies>().GetDamage(Random.Range(minTimeCost, maxTimeCost));
            Destroy(this.gameObject);
        }
    }

    IEnumerator WillBeDestroyedAfterCountdown(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
