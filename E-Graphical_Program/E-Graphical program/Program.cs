namespace E_Graphical_program
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Initialize's Applicaiton through running Form1.
        /// </summary>
        [STAThread]

        static void Main()
        {
       
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}