using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : MonoBehaviour{
    
    [SerializeField] KeyCode rotateLeft = KeyCode.A;
    [SerializeField] KeyCode rotateRight = KeyCode.D;
    [SerializeField] KeyCode thrustKey = KeyCode.Space;
    [SerializeField] float thrustForce;
    [SerializeField] float rotateSpeed;

    Rigidbody rigidBody;
    AudioSource audioSource;

    private void Start() {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate(){
        ProcessInput();
    }

    void ProcessInput(){
        if (Input.GetKey(thrustKey)){
            rigidBody.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
            if (!audioSource.isPlaying) audioSource.Play();
        } else {
            audioSource.Stop();
        }

        if (Input.GetKey(rotateLeft)) transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        if (Input.GetKey(rotateRight)) transform.Rotate(-Vector3.forward * rotateSpeed * Time.deltaTime);
        
    }

}
