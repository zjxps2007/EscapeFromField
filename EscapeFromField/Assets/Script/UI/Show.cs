using UnityEngine.UI;
using UnityEngine;

public class Show : MonoBehaviour
{
    [SerializeField] 
    private Text Kill;
    [SerializeField] 
    private Text count;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Kill.text = PlayerCtrl.score.ToString();
        count.text = PlayerCtrl.cnt.ToString();
    }
}
