using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Transform Begin;
    public Transform End;
    public Vector2 direction;
    private float moveSpeed;

    public float baseSpeed;

    public float dashPower;
    public float dashTime;

    bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isDashing)
            {
                StartCoroutine(Dash());
            }
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;

        moveSpeed *= dashPower;

        yield return new WaitForSeconds(dashTime);

        moveSpeed = baseSpeed;

        isDashing = false;
    }
}
