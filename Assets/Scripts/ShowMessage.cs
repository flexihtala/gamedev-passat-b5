using UnityEngine;

public class PhoneTrigger : MonoBehaviour
{
    public PhoneController phoneController;
    public string messageText = "Новое сообщение!";

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (!other.CompareTag("AddNewMassage")) return;
        phoneController.ShowMessage(messageText);
        Destroy(gameObject); // Если надо, чтобы триггер исчезал после активации
    }
}