namespace ASEProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application that initialises Form1.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}