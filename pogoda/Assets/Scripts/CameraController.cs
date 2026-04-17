using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    float lookY = 0;

    float tiltZ = 0;

    float vX;

    [SerializeField]
    private float sensitivity = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vX=Input.GetAxisRaw("Horizontal");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        float x = Input.GetAxis("Mouse X")*sensitivity;
        player.transform.Rotate(0, x, 0);

        float y = Input.GetAxis("Mouse Y")*sensitivity;
        lookY -= y;
        lookY = Mathf.Clamp(lookY, -90, 90);

        transform.localRotation = Quaternion.Euler(lookY, 0, tiltZ);

    }

    private void FixedUpdate()
    {
        tiltZ = Mathf.Lerp(tiltZ, -vX*3, 4*Time.deltaTime);
    }
}
