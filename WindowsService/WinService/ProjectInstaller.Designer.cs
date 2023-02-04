namespace WinService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._winServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this._winServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // _winServiceProcessInstaller
            // 
            this._winServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this._winServiceProcessInstaller.Password = null;
            this._winServiceProcessInstaller.Username = null;
            // 
            // _winServiceInstaller
            // 
            this._winServiceInstaller.Description = "Extendable Windows Service";
            this._winServiceInstaller.DisplayName = "Extendable Windows Service";
            this._winServiceInstaller.ServiceName = "Extendable Windows Service";
            this._winServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this._winServiceProcessInstaller,
            this._winServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller _winServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller _winServiceInstaller;
    }
}