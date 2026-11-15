using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isLocked = true;//закрыта 
    [SerializeField] private string _nextScene;
    public InteractableType Type => InteractableType.Door;

    public bool CanInteract => !_isLocked;

    public void UnLocked()
    {
        _isLocked = false;
    }

    public void Interact()
    {
        if (!CanInteract) return;

        SceneManager.LoadScene(_nextScene);
    }
}
