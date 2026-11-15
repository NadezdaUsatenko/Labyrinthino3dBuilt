using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Pickup : MonoBehaviour, IInteractable
{
    private Rigidbody rb;

    public InteractableType Type => InteractableType.Pickup;

    public bool CanInteract => true;

    public void Interact()
    {
       
    }
}
