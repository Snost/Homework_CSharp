using ExamCSharp;

class Program
{
    static void Main(string[] args)
    {
        Start();
    }

    static void Start()
    {
        Console.CursorVisible = false;

        LoadingScreen loadingScreen = new LoadingScreen();
        loadingScreen.Show();
        LoginScreen loginScreen = new LoginScreen();

        if (!loginScreen.Run())
        {
            Console.Clear();
            Console.WriteLine("Invalid login. Exiting...");
        }
        else
        {
            MainMenu.Show(loginScreen.CurrentUser);
        }
    }
}