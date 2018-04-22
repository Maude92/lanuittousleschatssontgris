using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.CharacterController))]
public class PlayerController : MonoBehaviour {
    UnityEngine.CharacterController controller;
    float nspeed; //start speed
    Vector3 movePosition = Vector3.zero;
    public float sensitivity = 5f;

    public float stepSpeed = 10F;
    public float runSpeed = 20F;
    public bool run = true;
    public bool lockCursor = true;
    private bool m_cursorIsLocked = true;

    //jump
    public float power = 8.0F;
    public float gravity = 10.0F;
    private Vector3 moveDirection = Vector3.zero;
	bool isGravity;

    private float minimumY = -70F;
    private float maximumY = 70F;
    private float rotationX = 0F;
    private float rotationY = 0F;
    private float speed = 0F;

    private Transform myCamera;
    private Vector3 movement;

    void Start()
	{
        Cursor.visible = false;
        controller = GetComponent<UnityEngine.CharacterController>();
        
        if (GetComponentInChildren<Camera>())
            myCamera = GetComponentInChildren<Camera>().transform;

        nspeed = speed;
    }
	

	void Update () {
        Look();
        Jump();

        float right = Input.GetAxisRaw("Horizontal");
        float forward = Input.GetAxisRaw("Vertical");

        movement.Set(right, 0f, forward);
        movement = transform.TransformDirection(movement);
        movement *= speed;
        controller.Move(movement * Time.deltaTime);

        //Run
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            speed = run ? stepSpeed : runSpeed;
        else
            speed = run ? runSpeed : stepSpeed;

    }


    void Look()
    {
        if (!myCamera) return;

        //Look
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;

        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(0, rotationX, 0);
        myCamera.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);

        UpdateCursorLock();
    }

    public void UpdateCursorLock()
    {
        //if the user set "lockCursor" we check & properly lock the cursos
        if (lockCursor)
            InternalLockUpdate();
    }

    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            m_cursorIsLocked = true;
        }

        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    void Jump()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(1))
        {
            moveDirection.y = power;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
}
