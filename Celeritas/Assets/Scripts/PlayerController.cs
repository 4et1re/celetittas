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
    private bool isJumping = false;
    private bool isPodkat = false;
    private double maxPosY = 0;

    [Space]

    private Vector2 swipeDir;

    [Space]

    private float podkatSpeed;
    public BoxCollider2D stayCol;
    public BoxCollider2D sitCol;
    public float podkatPower;
    public float podkatTime;
    public Transform playerSprite;
    // public Transform playerSprite;

    [Space]

    [SerializeField] Animator animator;
 
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
        print(isPodkat);

        if(isPodkat == true)
        {
            animator.SetTrigger("isPodkat");
        }else
        {
            animator.SetInteger("VelocityY", Mathf.RoundToInt(_rb.velocity.y));
        }
       
        movementLogic();
        
        void movementLogic()
        {
            _rb.velocity = new Vector2(1f * moveSpeed, _rb.velocity.y); // постійний рух вправо
            

        }

        TestSpeed();
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

            animator.SetTrigger("Jump");
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

            maxPosY = 0;
            animator.SetBool("Running", true);

            
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            if (maxPosY <= transform.position.y)
            {
                maxPosY = transform.position.y;
            }

            else
            { 
                print(maxPosY);
                animator.SetBool("AfterJump", true);
            }
               

        }
    }

    #endregion
    // перевірка на тег землі

    #region jumpingLogic
    private void jumpingLogic()
    {
        isJumping = true;
       
        if (DoubleJump > 0)
        {
            _rb.velocity = Vector2.up * jumpForce;
            DoubleJump--;
        }
        

        isJumping = false;
        
    }



    #endregion
    // логіка стрибка

    #region podkat

    IEnumerator PodkatLogic()
    {
        isPodkat = true;
        

        moveSpeed = (10f - moveSpeed) * 0.5f;

        stayCol.enabled = false;
        sitCol.enabled = true;

 //       stayCol.size = new Vector2(1f, 0.5f);

        yield return new WaitForSeconds(podkatTime);

        sitCol.enabled = false;
        stayCol.enabled = true;
  //      stayCol.size = new Vector2(1f, 2f);


        moveSpeed = baseSpeed;

        
        isPodkat = false;

    }

    IEnumerator TestSpeed()
    {
        for (int i = 5; i < 0; i--)
        {
            yield return new WaitForSeconds(2);
            print(i);
        }
    }

    #endregion

}
