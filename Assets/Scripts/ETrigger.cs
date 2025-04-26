using UnityEngine;
using UnityEngine.UI;

public class ShowImageOnTrigger : MonoBehaviour
{
    [SerializeField] private Image imageToShow;

    private void Start()
    {
        if (imageToShow != null)
            imageToShow.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && imageToShow != null)
            imageToShow.enabled = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && imageToShow != null)
            imageToShow.enabled = false;
        
    }
}