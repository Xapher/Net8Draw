namespace NET8Draw
{
    internal static class Program
    {
        static Form1 application = new Form1();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            ApplicationConfiguration.Initialize();
            //application.initCanvas();
            
            Application.Run(application);

            
        }
    }
}