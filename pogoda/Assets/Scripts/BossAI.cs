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

    [SerializeField] private GameObject piorun;

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
    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if(distance<2f && charge)
        {
            player.GetComponent<PlayerMovement>().alive = false;
        }

        if(distance>minDistanceToPlayer)
        {
            rb.AddForce(transform.forward*moveSpeed*Time.deltaTime, ForceMode.Impulse);  
        }
        else
        {
            if (!charge)
            {
                animator.SetTrigger("Charge");
                StartCoroutine(Charge());
                charge = true;
                minDistanceToPlayer = 0;
            }
        }
        if(distance>6*minDistanceToPlayer && !charge) 
        {
            animator.SetTrigger("FarAttack");
            minDistanceToPlayer += 2;
            StartCoroutine(SpawnPiorun());
        }
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
