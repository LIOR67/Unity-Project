using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    [Header("Movment Settings")]
    [Tooltip("Movment speed from side to side while using input")][SerializeField] float speed = 1f;
    [Tooltip("The range the ship can move on the X axis")] [SerializeField] float Xbound = 5f;
    [Tooltip("The range the ship can move on the Y axis")] [SerializeField] float Ybound = 3.5f;
    float Ythrow;
    float Xthrow;
    [Tooltip("Lasers Array")] [SerializeField] GameObject[] lasers;
    [Header("Rotation Settings")]
    [SerializeField] float InputPitchFactor = -10f;
    [SerializeField] float InputRollFactor = 2f;
    [SerializeField] float PitchFactor = -2f;
    [SerializeField] float YawFactor = -2f;
    [SerializeField] InputAction Shooting;
    // Update is called once per frame


    void Update()
    {
        ProcessMovment();
        ProcessRotation();
        ProcessShoting();
    }
    private void OnEnable()
    {
        Shooting.Enable();
    }
    private void OnDisable()
    {
        Shooting.Disable();
    }

    void ProcessShoting()
    {
        if (Shooting.ReadValue<float>()>0.5f)
        {
            Isshooting(true);
        }
       else
        {
           Isshooting(false);
         }

    }

    void Isshooting(bool a)
    {
        if (a==true)
        {
            foreach (GameObject Laser in lasers)
            {
                var EmissionActivation = Laser.GetComponent<ParticleSystem>().emission;
                EmissionActivation.enabled = true;
               
            }
        }
        else
        {
            foreach(GameObject Laser in lasers)
            {
                var EmissionActivation = Laser.GetComponent<ParticleSystem>().emission;
                EmissionActivation.enabled = false;
            }
        }
    }

    void ProcessRotation()
    {
        float Pitch = Ythrow* InputPitchFactor + transform.localRotation.y*PitchFactor;
        float Yaw = transform.localPosition.x * YawFactor;
        float Roll = Xthrow * InputRollFactor;
        transform.localRotation=Quaternion.Euler(Pitch, Yaw, Roll);
    }

     void ProcessMovment()
    {
        Xthrow = Input.GetAxis("Horizontal");
        Ythrow = Input.GetAxis("Vertical");

        float Xoffset = Xthrow * speed * Time.deltaTime;
        float Yoffset = Ythrow * speed * Time.deltaTime;

        float NewX = transform.localPosition.x + Xoffset;
        float NewY = transform.localPosition.y + Yoffset;

        float ClampedX = Mathf.Clamp(NewX, -Xbound, Xbound);
        float ClampedY = Mathf.Clamp(NewY, -Ybound, Ybound);

        transform.localPosition = new Vector3(ClampedX, ClampedY, transform.localPosition.z);
    }

}
