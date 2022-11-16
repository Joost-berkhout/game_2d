
using UnityEngine;
 
public class PlayerMovement_2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sprint;
    [SerializeField] private float Jump;
    private Rigidbody2D body;

    float MovementX;
    float MovementY;
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

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
        if (Input.GetKey(KeyCode.UpArrow))
            body.velocity = new Vector2(body.velocity.x, Jump);
            
    }

    
}