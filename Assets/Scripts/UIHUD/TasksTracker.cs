using UnityEngine;
using TMPro;

public class TasksTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTask;
    [SerializeField] private string[] _currentTask;
    private int _currentTaskIndex = 0;

    void Start()
    { 
        ShowTask();
    }

    void ShowTask()
    {
        if(_currentTaskIndex > _currentTask.Length)
        {
            _textTask.text ="Локация завершена";
        }
        _textTask.text = _currentTask[_currentTaskIndex];

    }
   public void CompletedTask()
    {
        if(_currentTaskIndex > _currentTask.Length)
        {
            return;
        }
        _currentTaskIndex++;
        ShowTask();
    }

   public void UpgradeProgress(int current,int target)
    {
        if(_currentTaskIndex > _currentTask.Length)
        {
            return;
        }
        _textTask.text = $"{_currentTask[_currentTaskIndex]}({current} / {target} )";
    }

}
