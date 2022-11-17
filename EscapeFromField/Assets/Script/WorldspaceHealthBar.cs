using System;
using UnityEngine;
using UnityEngine.UI;

public class WorldspaceHealthBar : MonoBehaviour
{
    //플레이어 체력 및 마나 텍스트
    [SerializeField] 
    private Text hpText;
    [SerializeField] 
    private Text mpText;

    //플레이어 체력 및 마나 이미지
    [SerializeField] 
    private Image hpImage;
    [SerializeField] 
    private Image mpImage;
    
    private float hpPoint = 50; // 현제 체력
    private float maxHpPoint = 100;

    private float mpPoint = 10;
    private float maxMpPoint = 100;
    
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayHealthUI();
        PlayManaUI();
    }

    void PlayHealthUI()
    {
        float ratio = hpPoint / maxHpPoint;
        hpImage.rectTransform.localPosition = new Vector3(hpImage.rectTransform.rect.width * ratio - hpImage.rectTransform.rect.width, 0, 0);
        hpText.text = hpPoint.ToString("0") + "/" + maxHpPoint.ToString("0");
    }

    void PlayManaUI()
    {
        float ratio = mpPoint / maxHpPoint;
        mpImage.rectTransform.localPosition = new Vector3(mpImage.rectTransform.rect.width * ratio - mpImage.rectTransform.rect.width, 0, 0);
        mpText.text = mpPoint.ToString("0") + "/" + maxMpPoint.ToString("0");
    }
}
