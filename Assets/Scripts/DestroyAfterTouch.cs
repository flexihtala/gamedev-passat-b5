using UnityEngine;

public class DestroyAfterTouch : MonoBehaviour
{
    
    private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            Destroy(gameObject);
        }
}
