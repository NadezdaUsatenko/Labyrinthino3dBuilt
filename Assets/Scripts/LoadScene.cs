using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    [SerializeField] private  TextMeshProUGUI _loadText;
    [SerializeField] private float _fillTime;
    private float _percent;
    

    void Start()
    {
        StartCoroutine(LoadRoutine(_fillTime));
    }

    IEnumerator LoadRoutine(float time)
    {

        float max = _slider.maxValue;
        float min = _slider.minValue;
      
        
        for(float t = 0; t < max; t += Time.deltaTime / time)
        {
            _slider.value = Mathf.Lerp(min, max, t); 
            _percent = Mathf.Lerp(0, 100, t);
            _loadText.text = $"Загрузка...({Mathf.RoundToInt(_percent)}%)"; 
            yield return null;
        }
        _slider.value = max;
        _loadText.text = "Загрузка...(100%)";
        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene(1);

       
    }
}
