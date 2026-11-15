using UnityEngine;

public class InteractableObject : MonoBehaviour
{
   
    public virtual bool CanInteract()
    {
        return true;
    }

    public virtual void Interact()
    {

    }

    public virtual void Highlight(bool active)
    {

    }

}
