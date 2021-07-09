namespace sakuGame.BGM
{
    public delegate void NowRhythmStorage();
    interface IWhen_SlowTiming
    {
        event NowRhythmStorage NowRhythmEvent;
    }

}
