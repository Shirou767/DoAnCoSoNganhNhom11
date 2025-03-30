using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager Instance;

    private string selectedAbility = null; // Lưu kỹ năng đã chọn

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Gọi khi ấn vào một kỹ năng
    public void SelectAbility(string abilityName)
    {
        selectedAbility = abilityName;
        Debug.Log("Đã chọn kỹ năng: " + selectedAbility);
    }

    // Gọi khi bấm vào map
    public void ActivateAbility(Vector2 position)
    {
        if (selectedAbility != null)
        {
            Debug.Log("Kích hoạt " + selectedAbility + " tại " + position);

            // Hiển thị hoạt ảnh kỹ năng tại vị trí bấm
            GameObject effect = Instantiate(Resources.Load<GameObject>("Effects/" + selectedAbility), position, Quaternion.identity);
            
            // Sau khi kích hoạt, reset lại kỹ năng
            selectedAbility = null;
        }
    }
}
