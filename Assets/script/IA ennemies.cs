using UnityEngine;

public class IAennemies : MonoBehaviour
{
    public Transform player; 
    public float speed = 3f;   
    public float chaseRange = 5f;  
    public float wanderTime = 2f;  

    private Vector3 randomTarget;
    private float wanderTimer;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChooseRandomTarget();
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Vector3 dir;

        if (distanceToPlayer < chaseRange)
        {
            dir = (player.position - transform.position);
            dir.y = 0;
            dir = dir.normalized;
        }
        else
        {
            Wander();
            dir = (randomTarget - transform.position);
            dir.y = 0;
            dir = dir.normalized;
        }

        rb.MovePosition(transform.position + dir * speed * Time.fixedDeltaTime);
    }

    void Wander()
    {
        wanderTimer += Time.deltaTime;

        if (Vector3.Distance(transform.position, randomTarget) < 0.5f || wanderTimer > wanderTime)
        {
            ChooseRandomTarget();
            wanderTimer = 0f;
        }
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
