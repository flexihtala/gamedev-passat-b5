using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("MoveX", moveX);
        float moveY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("MoveY", moveY);
    }
}