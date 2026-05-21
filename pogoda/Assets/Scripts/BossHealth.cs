using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float bossHP = 23000;
    private float startingHp = 23000;
    public UmbrellaManager manager;

    public bool secondPhase=false;

    public static BossHealth instance;


    public AudioSource source;
    private void Awake()
    {
        instance = this; 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        startingHp = bossHP;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
        if(collision.transform.tag=="umb")
        {
            source.Play();
            source.pitch = Random.Range(0.5f, 1.3f);
            bossHP -= manager.damage;
            TimeManager.instance.slowmo();

        }

        if(bossHP<=startingHp/2)
        {
            secondPhase = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
