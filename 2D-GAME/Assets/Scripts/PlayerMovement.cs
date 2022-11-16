using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sprint;
    [SerializeField] private float Jump;
    [SerializeField] private float passive;
    private Rigidbody2D body;
    private Animator anim;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius ;
    public LayerMask whatIsGround;
    public LayerMask PLAYER;

    private int extraJumps;
    public int extraJumpsValue;

    float MovementX;
    float MovementY;
    
    private void Start()
    {
        extraJumps = extraJumpsValue;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius,whatIsGround);
    }
 
    private void Update() //MOVEMENT + ANIMATIONS
    {
        body.velocity = new Vector2(MovementX * speed, body.velocity.y);   
        
            if (Input.GetKeyDown (KeyCode.A))
        {
            MovementX = -speed;
        }
            if (Input.GetKeyDown (KeyCode.D))
        {
            MovementX = speed;
        }

        if(isGrounded == true){
            extraJumps = extraJumpsValue;
        }
            if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0){
                body.velocity = new Vector2(body.velocity.x, Jump);
                extraJumps--;
            }
            else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true){
                body.velocity = new Vector2(body.velocity.x, Jump);
            }

                        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0){
                body.velocity = new Vector2(body.velocity.x, Jump);
                extraJumps--;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true){
                body.velocity = new Vector2(body.velocity.x, Jump);
            }
            
            
            if (Input.GetKeyUp (KeyCode.A))
        {
            MovementX = passive;
        }
            if (Input.GetKeyUp (KeyCode.D))
        {
            MovementX = passive;
        }
            if (Input.GetKey(KeyCode.LeftShift))
            body.velocity = new Vector2(MovementX * sprint, body.velocity.y);

            if (Input.GetKey(KeyCode.S))
            body.velocity = new Vector2(MovementX * sprint, body.velocity.y);

        if (Input.GetKeyUp(KeyCode.W))
            body.velocity = new Vector2(body.velocity.x, passive);
        if (Input.GetKeyUp(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, passive);

                    //Flip player when facing left/right.
        if (MovementX > 0.01f)
            transform.localScale = new Vector3(2, 2, 1);
        else if (MovementX >  -0.01f)
            transform.localScale = new Vector3(-2, 2, 1);

                anim.SetBool("Walk", MovementX != 0);
    }
}