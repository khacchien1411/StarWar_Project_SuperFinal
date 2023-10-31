using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public bool roaming = true;

    public float moveSpeed;
    public float nextWPDistance;

    public Seeker seeker;

    public SpriteRenderer spriteRenderer;

    public bool updateContinuesPath;

    //shoot

    public bool isShootable = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCooldown;


    bool reachDestination = false; 

    Path path;

    Coroutine moveCoroutine;
    private void Start()
    {
        InvokeRepeating("CalculatePath", 0f,  0.5f);
        reachDestination = true;
    }
    private void Update()
    {
        if (isShootable) {
            fireCooldown -= Time.deltaTime;
            if (fireCooldown < 0)
            {
                fireCooldown = timeBtwFire;
                //func shot
                EnemyFireBullet();
            }
        }
    }
    void EnemyFireBullet()
    {
        var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        // find target
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;
        Vector3 direction = playerPos - transform.position;
        rb.AddForce(direction.normalized * bulletSpeed , ForceMode2D.Impulse );
    }

    void CalculatePath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone() && (reachDestination || updateContinuesPath)) 
            seeker.StartPath(transform.position, target, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (p.error) return;
        path = p;
        // move to target
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if(moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }
    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;

        reachDestination = false;

        while(currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position +=(Vector3) force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
            {
                currentWP++;

            }
            if (force.x != 0)
                if (force.x < 0) 
                    spriteRenderer.transform.localScale =new Vector3(-1,1,0);
                else 
                    spriteRenderer.transform.localScale = new Vector3(1, 1, 0);
            yield return null;

        }
        reachDestination = true;

        
    }

    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<Player>().transform.position; 

        if (roaming == true)
        {
            return (Vector2) playerPos + (Random.RandomRange(5f, 10f) * new Vector2(Random.Range(-1,1), Random.Range(-1,1)).normalized);
        }else
        {
            return playerPos;        
        }
        
    }
}
