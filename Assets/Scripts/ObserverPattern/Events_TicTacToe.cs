using ObserverPattern;

namespace TicTacToe
{
    public static class Events_TicTacToe
    {
        public static class UI
        {
            public static ObserveEvent<Scenes> OnPressPlay = new ObserveEvent<Scenes>();
            public static ObserveEvent<Scenes> OnPressHome = new ObserveEvent<Scenes>();
        }
    }
}