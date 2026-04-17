using UnityEngine;

public class UMB : MonoBehaviour
{
    public float moveToPivot = 2;
    public Transform pivot;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, pivot.position, moveToPivot*Time.deltaTime);
        transform.rotation = pivot.rotation;
    }
}
