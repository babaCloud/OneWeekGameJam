namespace sakuGame.Guzai
{
    public delegate void JudgeTimeEndStorage(sakuGame.ItemNames itemNames,bool isSlash);
    interface IJudgeEndTime
    {
        event JudgeTimeEndStorage JudgeTime;
    }

}
