using UnityEngine;

public class StickmanCombat : MonoBehaviour
{
    private Animator animator;
    private bool isBlocking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Punch logic
        if (Input.GetKeyDown(KeyCode.H)) // Press 'H' for Punch
        {
            animator.SetTrigger("Punch"); // Trigger Punch animation
        }

        // Kick logic
        if (Input.GetKeyDown(KeyCode.J)) // Press 'J' for Kick
        {
            animator.SetTrigger("Kick"); // Trigger Kick animation
        }

        // Block logic
        if (Input.GetKey(KeyCode.K)) // Hold 'K' for Block
        {
            if (!isBlocking)
            {
                isBlocking = true;
                animator.SetBool("Block", true); // Set Block to true when blocking
            }
        }
        else if (isBlocking) // Stop blocking when key is released
        {
            isBlocking = false;
            animator.SetBool("Block", false); // Set Block to false when not blocking
        }
    }
}