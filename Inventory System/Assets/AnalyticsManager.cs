using System;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        SendAnalyticsMessage("Build startup on " + Application.platform + " at " + System.DateTime.Now.ToLocalTime() + ".");
    }

    public void SendAnalyticsMessage(string message)
    {
        Analytics.CustomEvent(message);
    }
}
