using UnityEngine;

public interface IInteractable 
{
    InteractableType Type { get; }
    bool CanInteract {  get; }
    void Interact();
  
}
