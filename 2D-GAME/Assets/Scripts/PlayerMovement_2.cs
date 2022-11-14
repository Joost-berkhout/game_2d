using UnityEngine;
 
public class PlayerMovement_2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sprint;
    private Rigidbody2D body;
    private Animator anim;
    
    private void Awake()
    {   
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
 
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if (Input.GetKey(KeyCode.LeftShift)) body.velocity = new Vector2(Input.GetAxis("Horizontal") * sprint, body.velocity.y);

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);
 
        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(2, 2, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-2, 2, 1);

                anim.SetBool("Walk", horizontalInput != 0);
 
    }
}