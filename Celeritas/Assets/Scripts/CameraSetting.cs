using UnityEngine;
using System.Collections;

public class CameraSetting : MonoBehaviour
{
    public Transform target;
    public float speed;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.position =  Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }
}