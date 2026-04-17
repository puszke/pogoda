using UnityEngine;

public class LimbController : MonoBehaviour
{
    public Transform targetLimb;
   
    void Update()
    {
        transform.localPosition = targetLimb.localPosition;
        transform.localRotation = targetLimb.localRotation;
    }
}
