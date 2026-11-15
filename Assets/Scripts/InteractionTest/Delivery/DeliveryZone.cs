using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CarryItem item = other.GetComponentInChildren<CarryItem>();

            if(item != null)
            {
                item.Deliver();
            }
        }
    }
}
