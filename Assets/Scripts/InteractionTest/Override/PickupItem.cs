using UnityEngine;
using UnityEngine.Events;

public class PickupItem : InteractableObject
{
    [SerializeField] private UnityEvent _onPickedUp;

    public override void Interact()
    {
        _onPickedUp.Invoke();
        Destroy(gameObject);
    }
}
