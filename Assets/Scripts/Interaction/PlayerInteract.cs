using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera _cameraMain;
    [SerializeField] private float _maxDistance = 0.5f;
    [SerializeField] private GameObject _interactButton;

    private IInteractable _currentInteractable;
    void Update()
    {
        InteractionRay();
    }
    public void InteractionRay()
    {
        _currentInteractable = null;
        _interactButton.SetActive(false);
        Ray ray = _cameraMain.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;



        if (Physics.Raycast(ray, out hit, _maxDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null && interactable.CanInteract == true)
            { 
                _currentInteractable = interactable;
               _interactButton.SetActive(true);
                Debug.Log($"{Physics.Raycast(ray, out hit, _maxDistance)}");
                Debug.Log(_currentInteractable);
                Debug.Log(interactable);
                float distance = Vector3.Distance(transform.position, hit.collider.transform.position);
                Debug.Log(distance);
                Debug.Log(hit.distance);


            }
        }
    }

    public void InteractWithObject()
    {
        if( _currentInteractable != null)
        {
            _currentInteractable.Interact();
        }
    }


}
