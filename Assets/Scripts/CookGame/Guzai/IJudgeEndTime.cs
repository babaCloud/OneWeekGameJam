namespace sakuGame.Guzai
{
    public delegate void JudgeTimeEndStorage();
    interface IJudgeEndTime
    {
        event JudgeTimeEndStorage JudgeTime;
    }

}
