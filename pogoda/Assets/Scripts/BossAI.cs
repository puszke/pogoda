using System.Collections;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private GameObject player;

    float minDistanceToPlayer=5;

    private Rigidbody rb;

    public float moveSpeed = 5;

    public Animator animator;

    private bool charge=false;

    private bool firstEncounter = true;

    [SerializeField] private GameObject piorun, komarObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        RandomDistance();
    }

    void RandomDistance()
    {
        minDistanceToPlayer = Random.Range(1, 5);
    }
    
    IEnumerator waitForKill()
    {
        yield return new WaitForSeconds(1);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 1 && charge)
        {
            player.GetComponent<PlayerMovement>().alive = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if(distance<2f && charge)
        {
            StartCoroutine(waitForKill());
        }

        if(distance>minDistanceToPlayer && !firstEncounter)
        {
            rb.AddForce(transform.forward*moveSpeed*Time.deltaTime, ForceMode.Impulse);  
        }
        else
        {
            if (!charge)
            {
                firstEncounter = false;
                animator.SetTrigger("Charge");
                StartCoroutine(Charge());
                charge = true;
                minDistanceToPlayer = 0;
            }
        }
        if(distance>6*minDistanceToPlayer && !charge) 
        {
            if (BossHealth.instance.secondPhase)
                StartCoroutine(komar());
            else
                animator.SetTrigger("FarAttack");
            minDistanceToPlayer += 2;
            StartCoroutine(SpawnPiorun());
        }
    }

    IEnumerator komar()
    {
        animator.SetTrigger("Komar");
        yield return new WaitForSeconds(0.4f);
        GameObject newKomar = Instantiate(komarObj, transform.position, Quaternion.identity);
    }

    IEnumerator SpawnPiorun()
    {
        yield return new WaitForSeconds(1);
        GameObject newP = Instantiate(piorun,transform.position,Quaternion.identity);
        Destroy(newP, 10);
    }

    IEnumerator Charge()
    {
        float pSpeed = moveSpeed;
        yield return new WaitForSeconds(0.5f);
        moveSpeed = 122;
        yield return new WaitForSeconds(5);
        moveSpeed = pSpeed;
        RandomDistance();
        charge = false;
    }
}
