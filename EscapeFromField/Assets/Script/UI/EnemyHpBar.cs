using UnityEngine;

public class EnemyHpBar : MonoBehaviour
{
    private Camera uiCamera;
    private Canvas _canvas;
    private RectTransform rectParent;
    private RectTransform rectHp;

    [HideInInspector] public Vector3 offset = Vector3.zero;
    [HideInInspector] public Transform target;

    private void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();

        rectParent = _canvas.GetComponent<RectTransform>();
        rectHp = gameObject.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        uiCamera = _canvas.worldCamera;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        var screenPos = Camera.main.WorldToScreenPoint(target.position + offset);

        if (screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
        }

        var localPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, uiCamera, out localPos);

        rectHp.localPosition = localPos;
    }
}
