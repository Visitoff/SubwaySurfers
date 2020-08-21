using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float jumpHeight = 3f;
    [SerializeField]
    float leftDir = -180f;
    [SerializeField]
    float rightDir = 180f;
    [SerializeField]
    float speed = 10f;

    Vector3 velocity;

    [SerializeField]
    float gravity = -9.81f;

    [SerializeField]
    CharacterController controller;

    float localScaleBefore = 0.6f;
    float localSceleAfter = 0.7f;
    float timeToJump;

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        timeToJump += Time.deltaTime;
        float movement = Input.GetAxis("Horizontal") * speed;
        movement *= Time.deltaTime;
        Vector3 playerMove = new Vector3(movement, 0f, 0f);
        controller.Move(playerMove);

        if (Input.GetButtonDown("Jump") && timeToJump >= 0.7f)//прыжок и изменение размера игрока
        {
            velocity.y = -2f;
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            timeToJump = 0f;
            if (localSceleAfter <= localScaleBefore)// проверка на размер для того что бы не увиличивать игрока в 2 раза
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                localSceleAfter = 1f;
            }
        }

        if (Input.GetButtonDown("Crouch") && localSceleAfter >= localScaleBefore)// присест и изменение размера игрока
        {
            transform.localScale = new Vector3(1f, 0.6f, 1f);
            localSceleAfter = 0.3f;
        }
        velocity.y += gravity * Time.deltaTime;//для прыжка 
        controller.Move(velocity * Time.deltaTime);
    }
}
