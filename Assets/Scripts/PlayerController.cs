using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの操作に関するスクリプトです。
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject cameraHolder;
    [SerializeField] Vector3 velocity;
    [SerializeField] float mouseSensitivity, walkSpeed, jumpForce, smoothTime;

    float verticalLookRotation;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    Rigidbody rb;

    bool esc;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

//各メソッドに統合
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            esc = !esc;
        }

        if (esc)
        {
            Cursor.lockState = CursorLockMode.None;
            float mouseSensitivity = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Look();
            Move();
            Jump();
        }
    }

//視点
    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

//進行方向と歩幅
    void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * walkSpeed, ref smoothMoveVelocity, smoothTime);
    }

//ジャンプ
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }

//プレイヤーの動き
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
