using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : InteractableObject
{
    [SerializeField] private string _nextScene;
    [SerializeField] private bool _isUnLocked = false;

    public override bool CanInteract()
    {
        return _isUnLocked;
    }

    public override void Interact()
    {
       SceneManager.LoadScene( _nextScene );
    }

    public void UnLockDoor()
    {
        _isUnLocked = true;
    }

    public override void Highlight(bool active)
    {

    }
}
