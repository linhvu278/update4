using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCtl : MonoBehaviour
{
    [SerializeField] private float mainThrust;
    [SerializeField] private float rotateThrust;
    [SerializeField] private AudioClip thrustAudio;
    [SerializeField] private ParticleSystem thrushParticle;
    [SerializeField] private ParticleSystem rotateParticle;

    private Rigidbody rb;
    private AudioSource audioSource;
    //[SerializeField] private float speed, speedA, speedS;
    //[SerializeField] private float fallDownSpeed;
    //[SerializeField] private float rotateZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        addForcePlayer();
        rotatePlayer();
    }

    //cach 2
    //private void Movement()
    //{
    //    //cach cua t
    //    ////rocket bay len
    //    //if (Input.GetKey(KeyCode.W))
    //    //{
    //    //    rb.AddForce(0, speed * Time.deltaTime, 0);
    //    //}

    //    ////rotate
    //    //if (Input.GetKey(KeyCode.A))
    //    //{
    //    //    rb.AddForce(-speedA, 0, 0);
    //    //    transform.Rotate(Vector3.forward * rotateZ * Time.deltaTime);
    //    //}
    //    //else if (Input.GetKey(KeyCode.D))
    //    //{
    //    //    rb.AddForce(speedA, 0, 0);    
    //    //    transform.Rotate(-Vector3.forward * rotateZ * Time.deltaTime);
    //    //}      
    //}     

    private void addForcePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.fixedDeltaTime);
            thrushParticle.Play();
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thrustAudio);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void rotatePlayer()
    {
        rotateParticle.Play();
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotateThrust * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotateThrust * Time.fixedDeltaTime);
        }
    }

    
}

