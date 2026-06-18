using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public bool alive = true;
    public float speed = 5;
    public float maxSpeed = 5;
    public float dodgeDistance = 10;

    [SerializeField]
    private GameObject DeathScreen;

    private CharacterController characterController;

    public bool dodging=false, jumping=false;

    public AudioSource source;

    float x, y;

    [SerializeField]
    float grav = 0;


    public AudioClip jump;
    public List<AudioClip> attacks;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (!dodging && alive)
        {
            characterController.Move((transform.forward * y + transform.right * x) * speed * Time.deltaTime);
        }
        if(dodging && alive)
        {
            characterController.Move((transform.forward * y + transform.right * x) * speed * 4 * Time.deltaTime);
        }
        Gravity();
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("weapon") == "big")
        {
            speed = 10;
        }
        if (PlayerPrefs.GetString("weapon")=="small")
        {
            speed = 20;
        }

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        DeathScreen.SetActive(!alive);
        GetComponent<Animator>().SetBool("Death", !alive);
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, 2 * Time.deltaTime);
        if (alive)
        {

            
            if (Input.GetKeyDown(KeyCode.LeftShift) && !dodging)
            {
                StartCoroutine(dodge());
                dodging = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) && !jumping)
            {
                StartCoroutine(Jump());
            }
            
            if (IsGrounded())
            {
                Debug.Log("sigma");
                grav = 0;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(1);
        
    }

    void Gravity()
    {
        grav += 3.9f;
        grav = Mathf.Clamp(grav, 0, 90);
        characterController.Move(Vector3.up*-grav * Time.deltaTime);
    }
 
    bool IsGrounded(float distance = 2f)
    {
        return Physics.Raycast(transform.position, Vector3.down, distance);
    }
    IEnumerator dodge()
    {
        /*int i = 0;
        float prevSpeed = speed;
        
        while (i < 10)
        {
            speed = dodgeDistance*50;
            if (y != 0)
            {
                if (y != 1)
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 90, 40 * Time.deltaTime);
                else
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 30, 40 * Time.deltaTime);
            }
            characterController.Move((transform.forward * y + transform.right * x) * speed * Time.deltaTime);
            i++;
           
        }*/
        source.PlayOneShot(jump);
        yield return new WaitForSeconds(0.2f);
        dodging = false;
        //speed = prevSpeed;  
    }
}
