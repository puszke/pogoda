using UnityEngine;

public class weaponswitch : MonoBehaviour
{
    public string weaponName = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            PlayerPrefs.SetString("weapon",weaponName);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
