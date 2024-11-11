namespace LilyFNServer.Utils
{
    public class Log
    {
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Format("{0} [INFO]: {1}", DateTime.Now, message));
        }
        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format("{0} [WARN]: {1}", DateTime.Now, message));
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Format("{0} [ERROR]: {1}", DateTime.Now, message));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
