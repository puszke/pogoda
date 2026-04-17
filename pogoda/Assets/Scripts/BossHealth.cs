using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float bossHP = 23000;
    public UmbrellaManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
        if(collision.transform.tag=="umb")
        {
            bossHP -= manager.damage;
            TimeManager.instance.slowmo();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
