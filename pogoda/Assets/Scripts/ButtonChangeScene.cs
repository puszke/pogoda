using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonChangeScene : MonoBehaviour
{
    public string scene = "SampleScene";
    public void Change()
    {
        SceneManager.LoadScene(scene);
    }
}
