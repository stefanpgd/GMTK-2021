using System;
using UnityEngine;

public class UserMetricsService : MonoBehaviour
{
    public Action MetricUpdatedEvent;

    private int score;
    private int kills;

    #region Singleton
    public static UserMetricsService Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public void AddMetric(MetricType type, int value = 1)
    { 
        switch(type)
        {
            case MetricType.Score:
                score += value;
                break;

            case MetricType.Kills:
                kills += value;
                break;
        }
    }

    public int GetMetric(MetricType type)
    {
        switch(type)
        {
            case MetricType.Score:
                return score;

            case MetricType.Kills:
                return kills;
        }

        Debug.LogError("Metric Type has not been added to the GetMetric() method yet!");
        return 0;
    }
}
