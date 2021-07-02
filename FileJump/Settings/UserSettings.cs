using FileJump.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileJump.Settings
{
    public static class UserSettings
    {
        /// <summary>
        /// Checks if the user decided to remember it's login details
        /// </summary>
        public static bool RememberLogin
        {
            get { return GetRememberLogin(); }
            set { SetRememberLogin(value); }
        }

        /// <summary>
        /// The email of the active user's account
        /// </summary>
        public static string UserEmail
        {
            get { return GetUserEmail(); }
            set { SetUserEmail(value); }
        }

        /// <summary>
        /// The access token to perform API calls
        /// </summary>
        public static string UserAccessToken
        {
            get { return GetUserToken(); }
            set { SetUserToken(value); }
        }

        /// <summary>
        /// True if user is currently logged on
        /// </summary>
        public static bool LoggedOn
        {
            get { return GetIsLoggedOn();  }
            set { SetIsLoggedOn(value); }
        }

        /// <summary>
        /// The name given to this device
        /// </summary>
        public static string MachineName
        {
            get { return GetMachineName(); }
            set { SetMachineName(value); }
        }

        /// <summary>
        /// The folder where the received files will go
        /// </summary>
        public static string DestinationFolder
        {
            get { return GetDestinationFolder(); }
            set { SetDestinationFolder(value); }
        }

        /// <summary>
        /// The type of device. 1 = Desktop, 2 = Laptop, 3 = Phone
        /// </summary>
        public static int DeviceType
        {
            get { return GetDeviceType(); }
            set { SetDeviceType(value); }
        }

        /// <summary>
        /// True if the user has selected this application to run on windows startup
        /// </summary>
        public static bool RunOnStartUp
        {
            get { return GetRunOnStartup(); }
            set { SetRunOnStartup(value); }
        }

        /// <summary>
        /// The first name of the logged on user
        /// </summary>
        public static string UserFirstName
        {
            get { return GetUserFirstName(); }
            set { SetUserFirstName(value); }
        }

        /// <summary>
        /// The last name of the logged on user
        /// </summary>
        public static string UserLastName
        {
            get { return GetUserLastName(); }
            set { SetUserLastName(value); }
        }

        public static string UserPassword
        {
            get { return GetUserPassword(); }
            set { SetUserPassword(value); }
        }


        // METHODS


        private static void SetUserPassword(string value)
        {
            Properties.Settings.Default["user_password"] = value;
            Properties.Settings.Default.Save();
        }

        private static string GetUserPassword()
        {
            return Properties.Settings.Default["user_password"].ToString();
        }

        private static string GetUserFirstName()
        {
            return Properties.Settings.Default["user_FirstName"].ToString();
        }


        
        private static void SetUserFirstName(string firstName)
        {
            Properties.Settings.Default["user_FirstName"] = firstName;
            Properties.Settings.Default.Save();
        }

        private static void SetUserLastName(string lastName)
        {
            Properties.Settings.Default["user_LastName"] = lastName;
            Properties.Settings.Default.Save();
        }

        private static string GetUserLastName()
        {
            return Properties.Settings.Default["user_LastName"].ToString();
        }

        private static bool GetRunOnStartup()
        {
            return (bool)Properties.Settings.Default["RunOnStartup"];
        }

        private static void SetRunOnStartup(bool value)
        {
            Properties.Settings.Default["RunOnStartup"] = value;
            Properties.Settings.Default.Save();
        }

        private static int GetDeviceType()
        {
            return (int)Properties.Settings.Default["DeviceType"];
        }

        private static void SetDeviceType(int type)
        {
            Properties.Settings.Default["DeviceType"] = type;
            ProgramSettings.DeviceType = (NetworkDeviceType)type;
            Properties.Settings.Default.Save();
        }

        private static string GetDestinationFolder()
        {
            return Properties.Settings.Default["DestinationFolder"].ToString();
        }

        private static void SetDestinationFolder(string path)
        {
            Properties.Settings.Default["DestinationFolder"] = path;
            ProgramSettings.StorageFolderPath = path;
            Properties.Settings.Default.Save();
        }

        private static string GetMachineName()
        {
            return Properties.Settings.Default["MachineName"].ToString();
        }

        private static void SetMachineName(string name)
        {
            Properties.Settings.Default["MachineName"] = name;
            ProgramSettings.DeviceName = name;
            Properties.Settings.Default.Save();
        }

        private static bool GetIsLoggedOn()
        {
            return (bool)Properties.Settings.Default["LoggedOn"];
        }

        private static void SetIsLoggedOn(bool loggedOn)
        {
            Properties.Settings.Default["LoggedOn"] = loggedOn;
            Properties.Settings.Default.Save();
        }

        private static bool GetRememberLogin()
        {
            return (bool)Properties.Settings.Default["RememberLogin"];
        }

        private static void SetRememberLogin(bool value)
        {
            Properties.Settings.Default["RememberLogin"] = value;
            Properties.Settings.Default.Save();
        }

        private static string GetUserEmail()
        {
            return Properties.Settings.Default["user_email"].ToString();
        }

        private static void SetUserEmail(string email)
        {
            Properties.Settings.Default["user_email"] = email;
            Properties.Settings.Default.Save();
        }

        private static string GetUserToken()
        {
            return Properties.Settings.Default["user_token"].ToString();
        }

        private static void SetUserToken(string value)
        {
            Properties.Settings.Default["user_token"] = value;
            Properties.Settings.Default.Save();
        }

        public static void ClearUserSettings()
        {
            SetUserToken("");
            SetUserEmail("");
            SetUserFirstName("");
            SetUserLastName("");
            SetUserPassword("");
            SetRememberLogin(false);
            SetIsLoggedOn(false);
            
        }
    }
}
