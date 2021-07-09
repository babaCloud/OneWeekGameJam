namespace sakuGame.BGM
{
    public delegate void NowRhythmStrage();
    interface IWhen_SlowTiming
    {
        event NowRhythmStrage NowRhythmEvent;
    }

}
