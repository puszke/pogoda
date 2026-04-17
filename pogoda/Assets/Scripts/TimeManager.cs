using UnityEngine;
using System.Collections;
public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
    private void Start()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
    public void slowmo()
    {
        StartCoroutine(slow());
    }

    IEnumerator slow()
    {
        Time.timeScale = 0.2f; // jak bardzo zwalniasz (0.1–0.3 fajnie wygl¹da)
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        yield return new WaitForSecondsRealtime(0.5f); // 0.1s REAL TIME

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}
