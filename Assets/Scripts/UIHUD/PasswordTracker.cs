using UnityEngine;
using TMPro;

public class PasswordTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _cells;
    public static PasswordTracker instance;
    private void Awake()
    {
        instance = this;
    }
    public void CollectFragment(int digit)
    {
        int count = PlayerPrefs.GetInt("PasswordCount", 0);
        if(count >= _cells.Length)
        {
            return;
        }
        PlayerPrefs.SetInt("PasswordDigit" + count,digit);
        count++;
        PlayerPrefs.SetInt("PasswordCount", count);
        PlayerPrefs.Save();
        UpdateCells();
    }
    public void UpdateCells()
    {
        int count = PlayerPrefs.GetInt("PasswordCount", 0);

        for (int i = 0; i < _cells.Length; i++)
        {
            if (i < count)
            {
                int digit = PlayerPrefs.GetInt("PasswordDigit" + i);
                _cells[i].text = digit.ToString();
            }
            else
            {
                _cells[i].text = "";
            }
        }

    }


}