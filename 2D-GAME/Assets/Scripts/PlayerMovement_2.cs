
using UnityEngine;
 
public class PlayerMovement_2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sprint;

    float MovementX;
    float MovementY;
    
    Rigidbody2D body;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        MovementX = 0;
        MovementY = 0;
    }
 
    private void Update()
    {

        body.velocity = new Vector2(MovementX * speed * Time.deltaTime, MovementY * speed * Time.deltaTime);
        Debug.Log(MovementX + " " + MovementY);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MovementY = 15;
        }
            if (Input.GetKey(KeyCode.DownArrow))
        {
            MovementY = -15;
        }
            if (Input.GetKey(KeyCode.LeftArrow))
        {
            MovementX = -15;
        }
            if (Input.GetKey(KeyCode.RightArrow))
        {
            MovementX = 15;
        }

    }
}