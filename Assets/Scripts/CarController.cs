// Thanks to the Unity tutorial for the basics of making a car: https://docs.unity3d.com/Manual/WheelColliderTutorial.html

using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody rb;
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    private bool jumping = false;
    private bool rotating = false;
    private float rotateAmount = 0;
    private float prevAngle;

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }

        if (rotating)
        {
            if (System.Math.Abs(transform.localEulerAngles.z - prevAngle) > 300)
            {
                prevAngle += (prevAngle < 180) ? 360 : -360;
            }
            rotateAmount += transform.localEulerAngles.z > prevAngle ?
                (transform.localEulerAngles.z - prevAngle) :
                (prevAngle - transform.localEulerAngles.z);
            prevAngle = transform.localEulerAngles.z;
            if (System.Math.Abs(rotateAmount) >= 330)
            {
                FindObjectOfType<Score>().KickFlip();
                rotateAmount = 0;
            }
        }

        if (Input.GetKey("space") && !jumping)
        {
            rb.velocity += 6 * Vector3.up;
            jumping = true;
        }

        if (Input.GetKey("a") && jumping)
        {
            rb.AddTorque(transform.forward * 3500);

            if (!rotating)
            {
                rotating = true;
                rotateAmount = 0;
                prevAngle = transform.localEulerAngles.z;
            }
        }

        if (Input.GetKey("d") && jumping)
        {
            rb.AddTorque(-transform.forward * 3500);

            if (!rotating)
            {
                rotating = true;
                rotateAmount = 0;
                prevAngle = transform.localEulerAngles.z;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (transform.up.y > 0.8)
            {
                FindObjectOfType<Score>().TrickLanded(true);
            }
            else
            {
                FindObjectOfType<Score>().TrickLanded(false);
            }
            jumping = false;
            rotating = false;
            rotateAmount = 0;
            prevAngle = transform.localEulerAngles.z;
        }
    }
}

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering; 
}