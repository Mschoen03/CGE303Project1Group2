using UnityEngine;

public class StickManCombat : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Punch
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("Punch");
        }

        // Kick
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Kick");
        }

        // Block
        if (Input.GetKey(KeyCode.K))
        {
            animator.SetBool("Block", true);
        }
        else
        {
            animator.SetBool("Block", false);
        }
    }
}