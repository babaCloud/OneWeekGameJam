namespace sakuGame.Guzai
{
    public delegate void NowMeetCut();
    interface IMeetCut 
    {
        event NowMeetCut MeetCutEvent;
    }
}