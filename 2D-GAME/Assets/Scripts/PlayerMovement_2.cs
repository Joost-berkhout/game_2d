
using UnityEngine;
 
public class PlayerMovement_2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sprint;
    [SerializeField] private float Jump;
    [SerializeField] private float passive;
    private Rigidbody2D body;
    private Animator anim;

    float MovementX;
    float MovementY;
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
 
    private void Update()
    {
        body.velocity = new Vector2(MovementX * speed, body.velocity.y);   
        
        Debug.Log(MovementX + " " + MovementY);

            if (Input.GetKeyDown (KeyCode.LeftArrow))
        {
            MovementX = -speed;
        }
            if (Input.GetKeyDown (KeyCode.RightArrow))
        {
            MovementX = speed;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
            body.velocity = new Vector2(body.velocity.x, Jump);  
        

            if (Input.GetKeyUp (KeyCode.LeftArrow))
        {
            MovementX = passive;
        }
            if (Input.GetKeyUp (KeyCode.RightArrow))
        {
            MovementX = passive;
        }
        if (Input.GetKey(KeyCode.DownArrow))
            body.velocity = new Vector2(MovementX * sprint, body.velocity.y);

        if (Input.GetKeyUp(KeyCode.UpArrow))
            body.velocity = new Vector2(body.velocity.x, passive);

                    //Flip player when facing left/right.
        if (MovementX > 0.01f)
            transform.localScale = new Vector3(2, 2, 1);
        else if (MovementX >  -0.01f)
            transform.localScale = new Vector3(-2, 2, 1);

                anim.SetBool("Walk", MovementX != 0);
    }
    

    
}