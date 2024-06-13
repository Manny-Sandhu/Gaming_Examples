using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 12f;
    private bool grounded = true;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator anim;
    private bool dead = false;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticles;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Jump") && grounded && !dead)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
            anim.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            audioSrc.PlayOneShot(jumpSound);
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            dirtParticles.Play();
        } else if(collision.gameObject.tag == "Obstacle")
        {
            gameManager.EndGame();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            dead = true;
            explosionParticle.Play();
            dirtParticles.Stop();
            audioSrc.PlayOneShot(crashSound);
        }
    }

    public void Reset()
    {
        dead = false;
        anim.SetBool("Death_b", false);
        anim.Play("Alive", anim.GetLayerIndex("Death"), 0f);
        dirtParticles.Play();
    }
}
