using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField] private Camera _cameraMain;
    [SerializeField] private Button _interactionButton;
    [SerializeField] private float _maxDistance = 0.5f;

    private InteractableObject _currentObject;
    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();

        _interactionButton.onClick.AddListener(Interact);

        _interactionButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        CheckObjects();
    }

    private void CheckObjects()
    {
        // Создаём луч из камеры
        Ray ray = new Ray(_cameraMain.transform.position,_cameraMain.transform.forward);

        // Показываем луч в Scene
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red);

        // Ищем все объекты, которых коснулся луч
        RaycastHit[] hits = Physics.RaycastAll(ray, 3f);

        InteractableObject nearestObject = null;

        float nearestDistance = _maxDistance;

        // Перебираем все найденные объекты
        foreach (RaycastHit hit in hits)
        {
            // Пропускаем самого игрока
            if (hit.collider.transform == transform ||
                hit.collider.transform.IsChildOf(transform))
            {
                continue;
            }

            
            InteractableObject obj =
                hit.collider.GetComponentInParent<InteractableObject>();

            if (obj == null)
            {
                continue;
            }

            // Проверяем, можно ли взаимодействовать
            if (!obj.CanInteract())
            {
                continue;
            }

            // Находим ближайшую точку персонажа
            Vector3 playerPoint = _controller.bounds.ClosestPoint(hit.point);

            // Вычисляем расстояние
            float distance = Vector3.Distance(playerPoint, hit.point);

            Debug.Log("Объект: " + obj.name +  " Расстояние: " + distance);

            // Проверяем расстояние и выбираем ближайший объект
            if (distance <= _maxDistance &&
                distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestObject = obj;
            }
        }

        // Если объект изменился, обновляем подсветку
        if (_currentObject != nearestObject)
        {
            if (_currentObject != null)
            {
                _currentObject.Highlight(false);
            }

            _currentObject = nearestObject;

            if (_currentObject != null)
            {
                _currentObject.Highlight(true);
            }
        }

        // Показываем кнопку, если объект найден
        _interactionButton.gameObject.SetActive(
            _currentObject != null
        );
    }

    // Метод вызывается при нажатии кнопки
    private void Interact()
    {
        if (_currentObject != null)
        {
            _currentObject.Interact();
        }
    }
}




        
    

