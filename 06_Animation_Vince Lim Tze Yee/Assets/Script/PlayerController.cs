using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator PlayerAnimin;
    public Rigidbody playerRb;
    public float speed = 5.0f;
    float Health = 100.0f;
    float DamageRate = 10.0f;
    bool Death;
    public GameObject HealthText;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerAnimin = GetComponent<Animator>();
        //playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) && Death == false) //go forward and face forward
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            PlayerAnimin.SetBool("IsStrafe", true);
        }
        if (Input.GetKey(KeyCode.S) && Death == false) //go backwards and face backwards
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            PlayerAnimin.SetBool("IsStrafe", true);
        }
        if (Input.GetKey(KeyCode.A) && Death == false) //go left and face left
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            PlayerAnimin.SetBool("IsStrafe", true);
        }
        if (Input.GetKey(KeyCode.D) && Death == false) //go right and face right
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            PlayerAnimin.SetBool("IsStrafe", true);
        }
        if (Input.GetKeyUp(KeyCode.W) && Death == false || Input.GetKeyUp(KeyCode.S) && Death == false || Input.GetKeyUp(KeyCode.A) && Death == false || Input.GetKeyUp(KeyCode.D) && Death == false)
        {
            PlayerAnimin.SetBool("IsStrafe", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Death == false)
        {
            PlayerAnimin.SetTrigger("TriggerAttack");
        }

        HealthText.GetComponent<Text>().text = "Health : " + Health.ToString();

    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Fire" && Health >= 0)
        {
            Health -= DamageRate * Time.deltaTime;

        }
        if (Health <= 0 && Death == false)
        {
            PlayerAnimin.SetTrigger("Death");
            Death = true;
        }

    }


}
