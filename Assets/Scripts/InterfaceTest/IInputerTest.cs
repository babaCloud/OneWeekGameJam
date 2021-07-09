public delegate void InputDeleagate2(KeyEnum keyEnum);
interface IInputerTest
{
    event InputDeleagate2 InputEvent2;
}
public enum KeyEnum
{
    Return,Space,Null
}
