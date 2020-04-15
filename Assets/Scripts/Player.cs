using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float xSpeed = 4f;
    [SerializeField] float ySpeed = 4f;
    [SerializeField] float positionPitchFactor = .16f;
    [SerializeField] float controlPitchFactor = -22f;
    [SerializeField] float positionYawFactor = .16f;
    [SerializeField] float controlRollFactor = -22f;
    float xThrow, yThrow, zThrow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation() {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation () {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawNewXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -18.5f, 18.5f);
        float rawNewYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -14f, 14.8f);


        transform.localPosition = new Vector3(rawNewXPos, rawNewYPos, transform.localPosition.z);
    }
}
