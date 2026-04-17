using UnityEngine;
using UnityEngine.UI;
public class BossHealthUI : MonoBehaviour
{
    public BossHealth health;

    public Image ui1, ui2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ui1.fillAmount = health.bossHP / 23000;
        ui2.fillAmount = Mathf.Lerp(ui2.fillAmount, ui1.fillAmount, 10*Time.deltaTime);
    }
}
