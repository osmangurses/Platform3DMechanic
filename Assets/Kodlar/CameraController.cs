using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    [SerializeField] Vector3 offset; // Karakterle kamera aras�ndaki mesafe
    [SerializeField] float rotationSpeed = 5f; // Kameran�n d�nme h�z�
    [SerializeField] float smoothSpeed = 1f;

    private float mouseX, mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        // Fare hareketleri ile kameray� d�nd�r
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60); // Yukar� ve a�a�� bak�� a��lar�n� s�n�rla

        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Vector3 desiredPosition = target.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target.position);
    }
}
