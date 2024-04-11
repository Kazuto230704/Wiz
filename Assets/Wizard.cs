using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Fireballprefab;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movment = new Vector3(0,0,0);
        if(Input.GetKey("w")){
            movment += new Vector3(0f, 1f, 0f);
        }if(Input.GetKey("a")){
            movment -= new Vector3(1f, 0f, 0f);
        }if(Input.GetKey("d")){
            movment += new Vector3(1f, 0f, 0f);
        }if(Input.GetKey("s")){
            movment -= new Vector3(0f, 1f, 0f);
        }if(Input.GetKeyDown("e")){
            GameObject fireball = Instantiate(Fireballprefab, transform.position, Quaternion.identity);
            Destroy(fireball, 5);
        }

        movment = movment.normalized;

        movment = movment * 5 * Time.deltaTime;
        transform.Translate(movment);
    
    }
}