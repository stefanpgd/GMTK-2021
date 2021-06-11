using TMPro;
using UnityEngine;

public class UI_ScoreDisplay : MonoBehaviour
{
    [SerializeField] private MetricType type;
    [SerializeField] private TextMeshProUGUI textObject;

    private UserMetricsService userMetricService;

    private void Start()
    {
        userMetricService = UserMetricsService.Instance;

        userMetricService.MetricUpdatedEvent += UpdateText;
        UpdateText();
    }

    private void OnDestroy()
    {
        userMetricService.MetricUpdatedEvent -= UpdateText;
    }

    private void UpdateText() => textObject.text = userMetricService.GetMetric(type).ToString();
}
