namespace sakuGame.BGM
{
    public delegate void RhythmTimingStorage();
    interface IWhen_RhythmTiming
    {
        event RhythmTimingStorage RhythmTimingEvent;
    }

}

