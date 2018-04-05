using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{

    public class PlayerController : MonoBehaviour
    {

        public float speed = 5f;
        public int health = 100;
        public int damage = 50;
        public float hitForce = 4f;
        public float damageForce = 4f;
        public float maxVelocity = 4f;
        public float maxSlopeAngle = 45f;
        [Header("Grounding")]
        public float rayDistance = 0.5f;
        public bool isGrounded = false;
        public bool isOnSlope = false;
        [Header("Crouch")]
        public bool isCrouching = false;

        [Header("Jump")]
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public bool isJumping = false;

        private Vector3 groundNormal = Vector3.up;
        private int currentJump = 0;
        private float inputH, inputV;

        //Refernces
        private SpriteRenderer rend;
        private Animator anim;
        private Rigidbody2D rigid;

        #region Unity Functions
        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody2D>();
        }


        void Update()
        {
            PerformMove();
            PerformJump();
        }

        void FixedUpdate()
        {
            DetectGround();

        }

        private void OnDrawGizmos()
        {
            //Draw ground ray
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
            //Draw direction of movement
            Vector3 right = Vector3.Cross(groundNormal, Vector3.back);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position - right * 1f, transform.position + right * 1f);
        }

        #endregion

        #region Custom Functions
        public void Jump()
        {
            isJumping = true;
        }
        public void Crouch()
        {

        }
        public void UnCrouch()
        {

        }
        public void Move(float horizontal)
        {
            // If there is horizontal input
            if (horizontal != 0)
            {
                //Flip the sprite in the correct direction
                rend.flipX = horizontal < 0;

            }

            //Store input horizontal for performing move later
            inputH = horizontal;
        }
        public void Hurt(int damage)
        {

        }

        private void PerformClimb()
        {

        }
        private void PerformMove()
        {
            //If the player is on a slope, not pressing anything and is grounded
            if (isOnSlope && isGrounded)
            {
                rigid.drag = 5f;
            }
            else
            {
                rigid.drag = 0f;
            }

            // Vector3.cross give it 2 vector3 arrows and it will draw the last one.
            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);
            // Add force in a direction of horizontal movement
            rigid.AddForce(right * inputH * speed);
            //Limit the velocity
            LimitVelocity();

        }
        private void PerformJump()
        {
            //Check if jumping is supposed to happen
            if (isJumping)
            {
                //If current jump is less than max jump count
                if (currentJump < maxJumpCount)
                {
                    //Increment jump by 1
                    currentJump++;
                    rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                }
                //Reset jump
                isJumping = false;
            }
        }

        private bool CheckGround(RaycastHit2D hit)
        {
            // If hit collider is not null AND
            // hit isn't self AND
            // hit isn't a trigger
            if (hit.collider != null && hit.collider.name != name && hit.collider.isTrigger == false)
            {

                // Reset jump
                currentJump = 1;

                // isGrounded is true
                isGrounded = true;

                // update ground normal (for slopes)
                groundNormal = hit.normal;

                //Calculate slope angle
                float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);

                //Check if slope is within range of parameters
                if (Mathf.Abs(slopeAngle) > 0 && Mathf.Abs(slopeAngle) < maxSlopeAngle)
                {
                    isOnSlope = true;
                }
                else
                {
                    isOnSlope = false;
                }

                //Check if i've reached the maximum slope angle
                if (Mathf.Abs(slopeAngle) >= maxSlopeAngle)
                {
                    //Use gravity to push it down
                    rigid.AddForce(Physics2D.gravity);
                }

                return true;
            }
            return false;
        }
        private void CheckEnemy(RaycastHit2D hit)
        {

        }
        private void DetectClimbable()
        {

        }
        private void DetectGround()
        {
            // Create a ray going in the direction of down
            Ray groundRay = new Ray(transform.position, Vector3.down);

            // Get all the hit objects (perform RayCastAll)
            RaycastHit2D[] hits = Physics2D.RaycastAll(groundRay.origin, groundRay.direction, rayDistance);

            //Foreach hit in the list
            foreach (var hit in hits)
            {
                CheckEnemy(hit);
                //Detect slopes
                if (Mathf.Abs(hit.normal.x) > 0.1f)
                {
                    rigid.gravityScale = 0;
                }
                else
                {
                    rigid.gravityScale = 1;
                }
                
                //CheckGround(hit)
                if (CheckGround(hit))
                {
                    return;
                }
                //CheckEnemy(hit)

            }
        }
        private void LimitVelocity()
        {
            Vector3 vel = rigid.velocity;
            if (vel.magnitude >= maxVelocity)
            {
                vel = vel.normalized * maxVelocity;
            }
            rigid.velocity = vel;
        }

        private void StopClimbing()
        {

        }
        private void EnablePhysics()
        {
            rigid.simulated = true;
            rigid.gravityScale = 1;
        }
        private void DisablePhysics()
        {
            rigid.simulated = false;
            rigid.gravityScale = 0;
        }

        #endregion
    }
}