using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer timerInstance { get; private set; }
    private void Awake()
    {
        if (timerInstance != null && timerInstance != this)
            Destroy(this);
        else
            timerInstance = this;
    }

    
    public float TimeSurvived;
    public bool isTicking = false;
    private void Start()
    {
        StartTimer(); 
    }
    void Update()
    {
        if(isTicking)
        {
            TimeSurvived += Time.deltaTime;
            ControladorUI.uiInstance.UpdateTimerText(TimeSurvived.ToString("F2"));
        }
    }
    public void ResetTimer()
    {
        TimeSurvived = 0;
        isTicking = false;
    }
    public void StartTimer()
    {
        isTicking = true;
    }
}
