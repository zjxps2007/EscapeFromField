using UnityEngine;
using UnityEngine.UI;

public class QuitMeue : MonoBehaviour
{
    [SerializeField] private Image mene;
    private bool istr;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mene.gameObject.SetActive(true);
            
        }
    }
}
