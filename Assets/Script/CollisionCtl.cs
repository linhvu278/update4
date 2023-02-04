using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionCtl : MonoBehaviour
{
    public static CollisionCtl collisionCtl;
    [SerializeField] private AudioClip finishAudio;
    [SerializeField] private AudioClip deathAudio;
    [SerializeField] private ParticleSystem finishParticle;
    [SerializeField] private ParticleSystem deathParticle;
    private float scaleUpDuration, scaleDownDuration, shieldDuration;
    Rigidbody rb;
    private Vector3 ogScale;
    public bool isScaleUp { get; set; }
    public bool isScaleDown { get; set; }
    private float powerupCounter;
    

    private AudioSource audioSource;
    private bool isCollision = false;
    
    void Awake(){
        if (collisionCtl != null){
            Debug.Log("More than 1 instance of CollisionCtl found.");
        }
        collisionCtl = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        ogScale = transform.localScale;
        isScaleUp = false;
        isScaleDown = false;
        powerupCounter = 0;
    }

    private void Update()
    {
        if (powerupCounter > 0){
            powerupCounter -= Time.deltaTime;
        }
        if (powerupCounter < 0){
            powerupCounter = 0;
            ReturnScale();
        }
    }

    private void ReponNextLevel()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            nextScene();
        }
    }


    //chuyen scene khong dung so
    void nextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }

    void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if(isCollision)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Finish":                  
                audioSource.Stop();
                audioSource.PlayOneShot(finishAudio);
                finishParticle.Play();
                GetComponent<MoveCtl>().enabled = false;
                Invoke("nextScene", 1f);                
                break;          
            case "Start":                
                break;
            case "Chuongngai":
                Die();
                break;
            default:               
                Die();
                break;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag){
            case "ScaleUp":
                isScaleUp = true;
                RocketScaleUp();
                break;
            case "ScaleDown":
                isScaleDown = true;
                RocketScaleDown();
                break;
            case "Khien":
                ReponNoCollision();
                //sau 5s ket thuc trang thai khien
                Invoke(nameof(NoReponNoCollision), shieldDuration);
                break;
            case "Destructable":
                if (!isScaleUp){
                    Die();
                    break;
                }
                else break;
        }
    }
    private void ReponNoCollision()
    {
        isCollision = !isCollision;
    }

    private void NoReponNoCollision()
    {
        isCollision = false; 
    }
    private void RocketScaleUp(){
        if (powerupCounter > 0){
            gameObject.transform.localScale = ogScale * 1.5f;
        }
    }
    private void RocketScaleDown(){
        if (powerupCounter > 0){
            gameObject.transform.localScale = ogScale * 0.5f;
        }
    }
    private void ReturnScale()
    {
        transform.localScale = ogScale;
    }
    public void SetPowerupTimer(float time){
        powerupCounter = time;
    }

    // public void SetScaleUpTimer(float time){
    //     scaleUpDuration = time;
    // }
    // public void SetScaleDownTimer(float time){
    //     scaleDownDuration = time;
    // }
    // public void SetShieldTimer(float time){
    //     shieldDuration = time;
    // }
    private void Die(){
        audioSource.Stop();
        audioSource.PlayOneShot(deathAudio);
        deathParticle.Play();
        GetComponent<MoveCtl>().enabled = false;
        rb.isKinematic = true;
        GetComponent<MeshRenderer>().enabled = false;
        Invoke("resetScene", 1f);
    }
}
