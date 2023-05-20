namespace WorkManager_A
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            Globale.jwm = new JSONwm();
            string workspace = Globale.jwm.getValue(ChiaviRoot.Workspace.ToString());

            if (string.IsNullOrEmpty(workspace) || !Directory.Exists(workspace)) 
            { 
                using (var login = new Login())
                {
                    switch (login.ShowDialog())
                    {
                        case DialogResult.OK:
                            Application.Run(new WMmain());
                            break;
                    }
                }
            }
            else
            {
                Application.Run(new WMmain());
            }
        }
    }
}