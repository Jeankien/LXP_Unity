using UnityEngine;

public class IAennemies : MonoBehaviour
{
    public Transform player; 
    public float speed = 3f;   
    public float chaseRange = 5f;  
    public float wanderTime = 2f;  

    private Vector3 randomTarget;
    private float wanderTimer;

    void Start()
    {
        ChooseRandomTarget();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            Vector3 dir = (player.position - transform.position);
            dir.y = 0;
            dir = dir.normalized;

            transform.position += dir * speed * Time.deltaTime;
        }
        else
        {
            Wander();
        }
    }

    void Wander()
    {
        wanderTimer += Time.deltaTime;

        if (Vector3.Distance(transform.position, randomTarget) < 0.5f || wanderTimer > wanderTime)
        {
            ChooseRandomTarget();
            wanderTimer = 0f;
        }

        Vector3 dir = (randomTarget - transform.position);
        dir.y = 0;
        dir = dir.normalized;

        transform.position += dir * speed * Time.deltaTime;
    }

    void ChooseRandomTarget()
    {
        Camera cam = Camera.main;

        
        float camDistance = Mathf.Abs(cam.transform.position.y - transform.position.y);

        Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        randomTarget = new Vector3(
            Random.Range(min.x, max.x),
            transform.position.y,
            Random.Range(min.z, max.z)
        );
    }
}

