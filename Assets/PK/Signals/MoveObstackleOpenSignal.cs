using System;


namespace PK.GameJam
{
    public static class MoveObstackleOpenSignal
    {
        public static event Action<int> openAnim;
        public static void Trigger(int index)
        {
            openAnim?.Invoke(index);
        }
    }
        public static class MoveObstackleCloseSignal
    {
        public static event Action<int> closeAnim;
        public static void Trigger(int index)
        {
            closeAnim?.Invoke(index);
        }
    }
}
