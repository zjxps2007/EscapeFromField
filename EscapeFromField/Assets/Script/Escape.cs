using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Escape : MonoBehaviour
{
    [SerializeField] private Text _text;
    
    private float Timer = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _text.gameObject.SetActive(true);
            Timer += Time.deltaTime;
            _text.text = string.Format("탈출까지 남은시간 : {0:0.0}", 15 - Mathf.Floor(Timer * 10) / 10);
            if (Timer >= 15)
            {
                _text.gameObject.SetActive(false);
                SceneManager.LoadScene("End");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Timer = 0;
            _text.gameObject.SetActive(false);
        }
    }
}
