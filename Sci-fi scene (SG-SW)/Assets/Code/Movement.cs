using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed, jumpSpeed;
    public Rigidbody rb;
    private bool isGrounded;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    float xPrev = Input.mousePosition.x;
    float yPrev = Input.mousePosition.y;
    float zPrev = Input.mousePosition.z;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(this.transform.worldToLocalMatrix * this.transform.forward * speed);
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(this.transform.worldToLocalMatrix * -this.transform.forward * speed);
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(this.transform.worldToLocalMatrix * -this.transform.right * speed);
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(this.transform.worldToLocalMatrix * this.transform.right * speed);
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //this.transform.Translate(this.transform.worldToLocalMatrix * this.transform.up * speed);
            rb.AddForce(transform.up * jumpSpeed);
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if(gameObject.CompareTag("Corridor"))
        {
            rb.velocity = Vector3.zero;
        }
    }*/

    void OnCollisionStay(Collision coll)
    {
        rb.velocity = Vector3.zero;
        isGrounded = true;
    }
    void OnCollisionExit(Collision coll)
    {
        if (isGrounded)
        {
            isGrounded = false;
        }
    }

    Vector3 lastPosition = new Vector3(); 

    /*void FixedUpdate()
    {
        Vector3 direction = new Vector3(transform.position - lastPosition);
        Ray ray = new Ray(lastPosition, direction);
        RaycastHit hit;
        /*if (Physics.Raycast(ray, hit, direction.magnitude))
        {
            // Do something if hit
        }*//*

        this.lastPosition = transform.position;
    }*/
}
