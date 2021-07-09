namespace sakuGame
{
    namespace InputSystem
    {
        public delegate void InputDelgate(MouseClick mouseClick);
        interface IInputer
        {
            event InputDelgate InputEvent;
        }
        public enum MouseClick
        {
            RightClick,
            LeftClick
        }
    }
}
