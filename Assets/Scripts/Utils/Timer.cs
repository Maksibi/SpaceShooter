public class Timer
{
    private float currentTime;

    public bool IsFinished => currentTime <= 0;

    public Timer(float startTIme)
    {
        Start(startTIme);
    }

    public void Start(float startTime)
    {
        currentTime = startTime;
    }

    public void DecreaseTime(float deltaTime)
    {
        if (currentTime <= 0) return;

        currentTime -= deltaTime;
    }
}
