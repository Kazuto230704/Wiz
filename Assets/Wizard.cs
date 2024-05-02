using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public GameObject fireballPrefab;
    private float counter = 5;
    private Vector3 lastMovement = Vector3.right;
    public static Vector3 movement;

    //private float mptimer = 4;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        movement = new Vector3(0,0,0);
        if (Input.GetKey("w"))
        {
            movement = movement + new Vector3(0f,1f,0f);
        }
        if (Input.GetKey("s"))
        {
            movement = movement + new Vector3(0f,-1f,0f);
        }
        if (Input.GetKey("a"))
        {
            movement = movement + new Vector3(-1f,0,0f);
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        if (Input.GetKey("d"))
        {
            movement = movement + new Vector3(1f,0,0f);
            transform.rotation = Quaternion.Euler(0f,0f,0f);
        }

        movement = movement.normalized;

        transform.position = transform.position + movement * Time.deltaTime * 2;

        if (movement.y != 0 || movement.x != 0)
        {
            lastMovement=movement;
            animator.SetBool("Walking", true);
        } else animator.SetBool("Walking", false);
        

        //GetKomponent<Fireball>().
        // Casting
        counter += Time.deltaTime;
        if (counter > 1 && Input.GetKeyDown(KeyCode.Space) && Hud.mp != 0)
        {
            GameObject obj = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            obj.GetComponent<Fireball>().direction = lastMovement;
            counter = 0;
            animator.SetBool("Attack", true);

            Hud.mp -= 10;
        } else if(Input.GetKeyUp(KeyCode.Space)) animator.SetBool("Attack", false);



    
    }
}