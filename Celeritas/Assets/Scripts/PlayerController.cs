using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region values
    public float moveSpeed = 10f;
    public Rigidbody2D _rb;
    private float moveX;

    [Space]

    public float baseSpeed = 10f;
    public float dashPower = 5f;
    public float dashTime = 0.2f;
    bool isDashing = false;

    [Space]

    int DoubleJump = 2;
    public float jumpForce = 6f;

    [Space]

    private Vector2 swipeDir;

    [Space]

    public BoxCollider2D stayCol;
    public BoxCollider2D sitCol;
    public float podkatPower;
    public float podkatTime;
    public Transform playerSprite;
   // public Transform playerSprite;
 
    #endregion 
    // змінні

    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();

        baseSpeed = moveSpeed;

    }
    // підписка на код свайпа з інету
    //private void SomeMethodCalledBySwipe(SwipeData data)
    //{
    //    if (data.Direction == SwipeDirection.Right)
    //    {
    //        swipeDir = Vector2.right;
    //    }
    //    else if (data.Direction == SwipeDirection.Left)
    //    {
    //        swipeDir = Vector2.left;
    //    }
    //    else if (data.Direction == SwipeDirection.Up)
    //    {
    //        swipeDir = Vector2.up;
    //    }
    //    else if (data.Direction == SwipeDirection.Down)
    //    {
    //        swipeDir = Vector2.down;
    //    }
    //} 


    void Update()
    {
        movementLogic();
        
        void movementLogic()
        {
            _rb.velocity = new Vector2(1f * moveSpeed, _rb.velocity.y); // постійний рух вправо
        }
    }



    #region Swipe
    public void Swipe(Vector2 dir)
    {

        Debug.LogWarning(dir);

        if (dir == Vector2.right)
        {
            if (!isDashing)
            {
                StartCoroutine(Dash());
            }
        }

        if (dir == Vector2.up)
        {
            jumpingLogic();

        }

        if (dir == Vector2.down)
        {
            StartCoroutine(PodkatLogic());
        }
    }//підписка на код свайпа

    #endregion
    //підписка на код свайпу

    #region Dash
    IEnumerator Dash()
    {
        print("Dash!");

        isDashing = true;


        _rb.gravityScale = 0;
        _rb.velocity = Vector2.zero;
        moveSpeed *= dashPower;

        yield return new WaitForSeconds(dashTime);

        moveSpeed = baseSpeed;

        _rb.gravityScale = 7;

        isDashing = false;


    }

    #endregion
    // логіка деша

    #region CheckGround

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {

            DoubleJump = 2;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {


        }
    }

    #endregion
    // перевірка на тег землі

    #region jumpingLogic
    private void jumpingLogic()
    {
        if (DoubleJump > 0)
        {
            _rb.velocity = Vector2.up * jumpForce;
            DoubleJump--;
        }
    }

    #endregion
    // логіка стрибка

    #region podkat

    IEnumerator PodkatLogic()
    {
        moveSpeed /= podkatPower;

        playerSprite.transform.localScale = new Vector2(1f, 0.5f);
        playerSprite.transform.localPosition = new Vector2(0f, -0.25f);

        sitCol.enabled = true;
        stayCol.enabled = false;

        yield return new WaitForSeconds(podkatTime);

        playerSprite.transform.localScale = new Vector2(1f, 1f);
        playerSprite.transform.localPosition = new Vector2(0f, 0.25f);

        stayCol.enabled = true;
        sitCol.enabled = false;

        moveSpeed = baseSpeed;

    }


    #endregion

}
