using System.Collections;
using UnityEngine;

public class UmbrellaManager : MonoBehaviour
{
    public float UMB_speed = 0;
    private Animator animator;

    [SerializeField] private UMB umb;

    public float damage = 1;

    public void AttackChangeSpeed()
    {
        StartCoroutine(b(999, 0.1f));
    }


    public IEnumerator b(float speed, float t)
    {
        umb.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        umb.moveToPivot = speed;
        yield return new WaitForSeconds(t);
        umb.moveToPivot = UMB_speed;
        umb.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        Debug.Log(UMB_speed);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        UMB_speed = umb.moveToPivot;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().alive)
        {
            bool lpm = Input.GetMouseButton(0);
            animator.SetBool("lpm", lpm);

            if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "lpmhold" || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "lpmattack")
            {
                damage += 2f;
                damage = Mathf.Clamp(damage, 0, 999);
            }
            else
            {
                damage = Mathf.Lerp(damage, 1, 99 * Time.deltaTime);
            }

        }
    }
}