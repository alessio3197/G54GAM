using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 2.0f;

    public float fireRate = 0.5F;
    public Text ammoText;
    private float nextFire = 0.0F;

    private int bullets = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
     
    }

    float verticalVelocity = 0;
    float yRotate;
    bool jumped = false;
    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotation*rotationSpeed, 0);
        yRotate = Mathf.Min(90, Mathf.Max(-90, (yRotate + (2*Input.GetAxis("Mouse Y")))));
        Camera.main.transform.localRotation = Quaternion.Euler(-yRotate, 0, 0);

        float forwardSpeed = Input.GetAxis("Vertical");
        float lateralSpeed = Input.GetAxis("Horizontal");
        CharacterController characterController = GetComponent<CharacterController>();

        if (characterController.isGrounded)
        {
            if (Input.GetButton("Jump")){
                jumped = true;
                verticalVelocity = 5;
            }
            else
            {
                jumped = false;
            }
        }
        else
        {
            if (jumped)
            {
                verticalVelocity += Physics.gravity.y * Time.deltaTime;
            }
            else
            {
                verticalVelocity += Physics.gravity.y * Time.fixedDeltaTime;
            }
        }

        Vector3 speed = new Vector3(lateralSpeed*moveSpeed, verticalVelocity, forwardSpeed*moveSpeed);
        speed = transform.rotation * speed;
        characterController.Move(speed * Time.deltaTime);

        if (bullets >= 0 && Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            bullets--;
        }
    }

    public void SetBulletsActive(int ammo)
    {
        bullets = ammo;
        ammoText.text = "Ammo: " + bullets;
        if (ammo > 0)
        {
            ammoText.enabled = true;
        }
        else
        {
            ammoText.enabled = false;
        }
    }

    public int GetBullets()
    {
        return bullets;
    }
}
