using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float laneDistance;
    public float sideTime;
    public int lane = 1;
    public bool isSiding;
    public bool isJumping;
    public float jumpForce;
    private bool detectFloor = true;
    public float gravity;
    public bool forceFalling;
    public Animator anim;
    public RagDoll ragd;

    public bool dead;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        if(!dead){
            if(Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight && !isSiding){
            if(lane <2){
                iTween.MoveAdd(gameObject, new Vector3(laneDistance, 0, 0), sideTime);
                lane++;
                StartCoroutine(WaitSide(sideTime, 1));
            }           
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft && !isSiding){
                if(lane >0){
                    iTween.MoveAdd(gameObject, new Vector3(-laneDistance, 0, 0), sideTime);
                    lane--;
                    StartCoroutine(WaitSide(sideTime, 0));
                }      
            }else if(!isSiding){
                switch(lane){
                    case 0:
                        transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);
                        break;

                    case 1:
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                        break;

                    case 2:
                        transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);
                        break;
                        
                }
            }

            
            if((Input.GetKeyDown(KeyCode.UpArrow) || SwipeManager.swipeUp) && !isJumping){
                rb.AddForce(Vector3.up * jumpForce);
                StartCoroutine(StartJump());
                isJumping = true;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                anim.SetBool("Jumping", true);
            }
        }                        
    }
    
    void FixedUpdate()
    {
        if(!dead){
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);

                
            
            if((Input.GetKeyDown(KeyCode.DownArrow) || SwipeManager.swipeDown) && isJumping && !forceFalling){
                    forceFalling = true;
                } else if(rb.velocity.y < 0 && isJumping && !forceFalling){
                    rb.AddForce(new Vector3(0, -gravity, 0));
                }

                if(forceFalling){
                    rb.AddForce(new Vector3(0, -gravity*2, 0));
                }
        }
    }

    private IEnumerator WaitSide(float time, int dir){
        isSiding = true;
        yield return new WaitForSeconds(time);
        isSiding = false;
        
    }

    private void OnCollisionEnter(Collision other) {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ground") && detectFloor){
            isJumping = false;
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            anim.SetBool("Jumping", false);
            forceFalling = false;
            transform.position = new Vector3(transform.position.x, 1.7f, transform.position.z);
        }

        if(other.gameObject.CompareTag("Obstacle") && detectFloor){
            ragd.SetEnabled(true);
            dead = true;
            rb.velocity = Vector3.zero;
        }
    }

    private IEnumerator StartJump(){
        detectFloor = false;
        yield return new WaitForSeconds(0.1f);
        detectFloor = true;
    }
}
