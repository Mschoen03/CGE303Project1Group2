namespace MyGame.Combat
{
    using UnityEngine;

    public class PlayerCombat : MonoBehaviour
    {
        private Animator animator;

        void Start()
        {
            // Get the Animator component attached to this GameObject
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            // Punching (J Key)
            if (Input.GetKeyDown(KeyCode.J))
            {
                // Trigger the "Punch" animation
                animator.SetTrigger("Punch");
            }

            // Check if the "Punch" animation has finished playing
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Punch") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                // Reset the "Punch" trigger to prevent looping
                animator.ResetTrigger("Punch");
            }

            // Kicking (K Key)
            if (Input.GetKeyDown(KeyCode.K))
            {
                // Trigger the "Kick" animation
                animator.SetTrigger("Kick");
            }

            // Check if the "Kick" animation has finished playing
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Kick") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                // Reset the "Kick" trigger to prevent looping
                animator.ResetTrigger("Kick");
            }

            // Blocking (L Key)
            if (Input.GetKey(KeyCode.L))
            {
                // Set the "IsBlocking" boolean to true, activating the block animation
                animator.SetBool("IsBlocking", true);
            }
            else
            {
                // Set the "IsBlocking" boolean to false, deactivating the block animation
                animator.SetBool("IsBlocking", false);
            }
        }
    }
}