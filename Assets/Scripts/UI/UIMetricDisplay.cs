using TMPro;
using UnityEngine;

public class UIMetricDisplay : MonoBehaviour
{
    [SerializeField] private MetricType type;
    [SerializeField] private TextMeshProUGUI textObject;

    private UserMetricsService userMetricsService;

    private void Start()
    {
        userMetricsService = UserMetricsService.Instance;

        userMetricsService.MetricUpdatedEvent += UpdateText;
        UpdateText();
    }

    private void OnDestroy()
    {
        userMetricsService.MetricUpdatedEvent -= UpdateText;
    }

    private void UpdateText() => textObject.text = userMetricsService.GetMetric(type).ToString();
}