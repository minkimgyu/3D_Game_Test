using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hAxis;
    float vAxis;
    float speed = 1000;
    bool isWalk = false;
    public int runSpeed = 2;

    public Vector3 moveVec;

    Animator anim;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        anim.SetBool("isWalk", moveVec != Vector3.zero);

        if (Input.GetKey(KeyCode.LeftShift) && anim.GetBool("isWalk") && !anim.GetBool("isRun"))
            anim.SetBool("isRun", true);
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            anim.SetBool("isRun", false);

        transform.LookAt(transform.position + moveVec);

        if (isWalk)
        {
            rigid.velocity = moveVec * speed * Time.deltaTime;
        }
        else
        {
            rigid.velocity = moveVec * runSpeed * speed * Time.deltaTime;
        }
    }
}
