using UnityEngine;

public class Komar : MonoBehaviour
{
    public float speed = 5;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 6);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward*speed);
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        
    }
}
