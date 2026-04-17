using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class BossAnimations : MonoBehaviour
{
    public GameObject body, animationIndicator;

    public List<GameObject> bodyObjects, animationIndicatorObjects;

   
    void TraverseAllChildren(Transform parent, List<GameObject> obj)
    {
        foreach (Transform child in parent)
        {
            obj.Add(child.gameObject);
            TraverseAllChildren(child, obj);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TraverseAllChildren(body.transform, bodyObjects);
        TraverseAllChildren(animationIndicator.transform, animationIndicatorObjects);

        for(int i = 0; i < bodyObjects.Count; i++)
        {
            bodyObjects[i].gameObject.AddComponent<LimbController>().targetLimb = animationIndicatorObjects[i].transform;
        }
        //StartCoroutine(Anim());
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
