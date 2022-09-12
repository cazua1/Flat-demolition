using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _joystickArea;
    [SerializeField] private Image _joystickBackground;
    [SerializeField] private Image _joystick;
    
    protected Vector2 InputVector;
    private Vector2 _joystickStartPosition;
    
    private void Start()
    {        
        _joystickStartPosition = _joystickBackground.rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform, eventData.position, null, out Vector2 joystickPosition))
        {
            joystickPosition.x = joystickPosition.x * 2 / _joystickBackground.rectTransform.sizeDelta.x;
            joystickPosition.y = joystickPosition.y * 2 / _joystickBackground.rectTransform.sizeDelta.y;
            InputVector = new Vector2(joystickPosition.x, joystickPosition.y);
            InputVector = (InputVector.magnitude > 1f) ? InputVector.normalized : InputVector;
            _joystick.rectTransform.anchoredPosition = new Vector2(InputVector.x * (_joystickBackground.rectTransform.sizeDelta.x / 2), InputVector.y * (_joystickBackground.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickArea.rectTransform, eventData.position, null, out Vector2 joystickPosition))
        {
            _joystickBackground.rectTransform.anchoredPosition = new Vector2(joystickPosition.x, joystickPosition.y);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joystickBackground.rectTransform.anchoredPosition = _joystickStartPosition;        
        InputVector = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }    
}