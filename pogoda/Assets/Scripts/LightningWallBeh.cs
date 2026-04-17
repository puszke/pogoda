using UnityEngine;

public class LightningWallBeh : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward*55*Time.deltaTime, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.tag=="Player")
        {
            other.GetComponent<PlayerMovement>().alive = false;
        }
    }
}
