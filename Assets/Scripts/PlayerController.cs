using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;

    Rigidbody playerRB;
    public float jumpForce;
    public float gravityMultiplier;
    bool isOnGround = true;
    public bool gameOver;
    Animator playerAnim;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip crash;
    public AudioClip jump;
    public AudioSource playerAudio;
    public int jumpCount = 0;

    public MoverLeft[] _moAlt;

    public bool entry;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(this.transform.position.x - 5, this.transform.position.y, this.transform.position.z);
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Invoke("Entry", -transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || jumpCount < 2) && !gameOver && entry)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirt.Stop();
            playerAudio.PlayOneShot(jump,1f);
            jumpCount++;
        }
        //boost
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerAnim.SetFloat("New Float", 2.5f);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerAnim.SetFloat("New Float", 1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirt.Play();
            jumpCount = 0;
        }else if (collision.gameObject.CompareTag("Obsticle"))
        {
            gameOver = true;
            Debug.Log("Game over");
            playerAnim.SetBool("Death_b", true);
            explosion.Play();
            dirt.Stop();
            playerAudio.PlayOneShot(crash,1f);
            //stop music
            cam.GetComponent<AudioSource>().enabled = false;
        }
        
    }
    void Entry()
    {
        entry = true;
        playerRB.constraints = RigidbodyConstraints.FreezePositionX;
        playerAnim.SetFloat("Speed_f", 2);
    }
}