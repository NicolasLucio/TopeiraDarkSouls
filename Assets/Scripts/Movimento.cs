using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float inputx, inputy, rotationSpeed, jumpingForce;
    public Camera cam;
    public Rigidbody rigid;
    public Animator anin;
    public bool jump = false;
    //public NavSystem navEnemyScript;
    
    public MelleAtackSystem swordScript;
    public GameObject spellObj;
    public GameObject spellOrigin;

    private bool canCastAgain = true;

    public AudioSource stepSound;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        bool spell = Input.GetKeyDown(KeyCode.Mouse1);
        bool firing = Input.GetKeyDown(KeyCode.Mouse0);
        bool jumping = (Input.GetAxis("Jump") == 1) ? true : false;

        inputx = Input.GetAxis("Horizontal");
        inputy = Input.GetAxis("Vertical");

        if (firing)
        {            
            anin.SetTrigger("attacking");
            swordScript.AttackMade();
        }

        if (spell)
        {            
            CastingSpell();
        }

        if (jumping && !jump)
        {
            jump = true;
            anin.SetBool("jump", true);
            rigid.AddForce(new Vector3((jumpingForce * 3) *inputx ,jumpingForce, (jumpingForce * 3)), ForceMode.Force);
        }

        if (inputy != 0 || inputx != 0)
        {
            anin.SetBool("run",true);
            Rotation();
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anin.SetBool("running", true);
            }
            else
            {
                anin.SetBool("running", false);
            }
        }
        else
        {
            
            anin.SetBool("run", false);
            transform.rotation.Normalize();            
        }
    }

    private void Rotation()
    {
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = forward * inputy + right * inputx;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSpeed);
    }

    void CastingSpell()
    {
        if (canCastAgain == true)
        {
            anin.SetTrigger("spellcasting");
            StartCoroutine(CastingTimer());
        }        
    }

    void OnCollisionEnter (Collision collision)
    {
        StartCoroutine("Jumptimer");        
    }

    IEnumerator Jumptimer()
    {
        anin.SetBool("jump", false);
        rigid.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.5f);
        jump = false;     
    }    

    IEnumerator CastingTimer()
    {
        canCastAgain = false;
        yield return new WaitForSecondsRealtime(0.5f);
        GameObject tempSpell = Instantiate(spellObj, spellOrigin.transform.position, Quaternion.Euler(Vector3.zero));
        tempSpell.GetComponent<Rigidbody>().AddForce(this.transform.forward * 2000.0f, ForceMode.Force);
        yield return new WaitForSecondsRealtime(2.5f);
        canCastAgain = true;
    }

    public void PlayStep()
    {
        stepSound.Play();
    }
}
