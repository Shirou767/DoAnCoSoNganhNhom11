using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    public string abilityName; // Tên kỹ năng tương ứng

    private void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(() => AbilityManager.Instance.SelectAbility(abilityName));
        }
        else
        {
            Debug.LogError("Không tìm thấy Button trên " + gameObject.name);
        }
    }
}
