using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControls : MonoBehaviour
{
    public GameObject laserPrefab;
    public PlayerActionInputs playerMovement;
    public Rigidbody2D rb;

    Vector2 moveDirection;
    private InputAction move;
    private InputAction fire;
    private float speed = 6f;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;
    AudioSource audioSource;

    void Awake()
    {
        playerMovement = new PlayerActionInputs();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

     private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    private void OnEnable()
    {
        move = playerMovement.Player.Move;
        move.Enable();

        fire = playerMovement.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    void Fire(InputAction.CallbackContext context)
    {
        Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        audioSource.Play();
    }
}