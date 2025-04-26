using UnityEngine;

public class CharacterSpriteController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite walkLeftSprite;
    public Sprite walkRightSprite;

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        if (moveX > 0)
        {
            spriteRenderer.sprite = walkRightSprite;
        }
        else if (moveX < 0)
        {
            spriteRenderer.sprite = walkLeftSprite;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }
    }
}