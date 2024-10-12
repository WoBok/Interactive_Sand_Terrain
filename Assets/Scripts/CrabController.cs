using System.Collections;
using UnityEngine;

public class CrabController : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public float animspeed;
    bool state = false;
    Animator animator;
    Rigidbody rb;
    Vector3 angularVelocity;
    int direction;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        StartCoroutine(Timer());
        StartCoroutine(StateChanger());
    }
    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));
            state = !state;
            direction = Random.Range(0, 101) > 50 ? 1 : -1;
            angularVelocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1, 1f), Random.Range(-1, 1f));
            angularVelocity.Normalize();
            angularVelocity.y = 0f;
            angularVelocity *= rotationSpeed;
        }
    }
    IEnumerator StateChanger()
    {
        while (true)
        {
            if (state)
                Crawl();
            else
                Idel();
            yield return new WaitForFixedUpdate();
        }
    }
    void Idel()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        animator.SetFloat("Speed", 0);
    }
    void Crawl()
    {
        rb.velocity = transform.right * movementSpeed * direction;
        rb.angularVelocity = angularVelocity;
        animator.SetFloat("Speed", rb.velocity.magnitude * animspeed);
    }
}