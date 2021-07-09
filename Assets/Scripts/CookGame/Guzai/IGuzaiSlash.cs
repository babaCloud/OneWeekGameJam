namespace sakuGame
{
    namespace Guzai
    {
        public delegate void NowSlashStorage();
        interface IGuzaiSlash
        {
            event NowSlashStorage NowSlashEvent;
        }

    }
}
