namespace sakuGame.BGM
{
    public delegate void EndGameStorage();
    interface IWhenEndBgm
    {
        event EndGameStorage EndGameEvent;
    }

}
