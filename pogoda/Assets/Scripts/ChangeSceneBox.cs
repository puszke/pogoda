using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneBox : MonoBehaviour
{
    public string scen = "SampleScene";
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.transform.tag);
        if(collision.transform.tag == "Player")
        {
            SceneManager.LoadScene(scen);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
