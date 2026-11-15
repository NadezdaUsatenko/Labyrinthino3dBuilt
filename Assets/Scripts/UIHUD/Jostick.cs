using UnityEngine;
using UnityEngine.EventSystems;

public class Jostick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{

   
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }


        public RectTransform mushroom;//гриб джойстика

        private bool _onScreen = false; //проверка нажали ли на экран

        private Vector2 _startPoint;

        public void OnPointerDown(PointerEventData data)//произошло нажатие
        {
            _startPoint = data.position;
            _onScreen = true;
        }

        public void OnPointerUp(PointerEventData data)
        {
            _onScreen = false;
            Horizontal = Vertical = 0;
            mushroom.localPosition = Vector2.zero;
        }
        public void OnPointerMove(PointerEventData eventData)//обработчмк перемещения
        {
            if (_onScreen)//если на экран нажали
            {
                mushroom.localPosition = eventData.position - _startPoint; //грибок джостика появится по направлению к нажатию
                mushroom.localPosition = Vector3.ClampMagnitude(mushroom.localPosition, 200f);

                Horizontal = mushroom.localPosition.x / 200f;
                Vertical = mushroom.localPosition.y / 200f;

            }

        }
}



    

