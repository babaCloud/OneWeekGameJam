namespace sakuGame.BGM
{
    public delegate void NowSlowStorage(GuzaiEnum guzaiEnum);
    interface IWhen_SlowTiming
    {
        event NowSlowStorage NowSlowEvent;
    }
    public enum GuzaiEnum
    {
        Carrot,other
    }
}
