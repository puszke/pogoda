
using UnityEngine;

public class parasolkozmieniacz : MonoBehaviour
{
    public static parasolkozmieniacz instance;


    public GameObject big, small;

    private void Awake()
    {
        instance = this; 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.GetString("weapon")=="")
        {
            PlayerPrefs.SetString("weapon","big");
        }
    }

    // Update is called once per frame
    void Update()
    {
        big.SetActive(PlayerPrefs.GetString("weapon") == "big");
        small.SetActive(PlayerPrefs.GetString("weapon") == "small");
    }
}
