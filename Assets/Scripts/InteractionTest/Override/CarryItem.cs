using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public class CarryItem : InteractableObject
{
    public static bool IsCarrying = false;
    [SerializeField] private Transform _holdPoint;
    [SerializeField] private UnityEvent _onDelivered;

    private Collider _collider;

    void Start()
    {
        _collider = GetComponent<Collider>();
    }
    public override bool CanInteract()
    {
        return !IsCarrying;
    }

    public override void Interact()
    {
        IsCarrying = true;
        transform.SetParent(_holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        _collider.enabled = false;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
    public void Deliver()
    {
        IsCarrying = false;
        _onDelivered.Invoke();
        Destroy(gameObject);
    }
    



}
