using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DataAccess
{
    public class ConnectionInfo
    {
        private string m_StrConnecion = string.Empty;
        private string m_Provider = string.Empty;
        private string m_DataSource = string.Empty;
        private string m_PersistSecurity = "False";
        private string m_User = string.Empty;
        private string m_Pass = string.Empty;
        private string m_xtra = string.Empty;

        public string StrConnection
        {
            get
            {
                if (m_StrConnecion == string.Empty)
                    BuildConnection();

                return m_StrConnecion;
            }
            set { m_StrConnecion = value; }
        }

        public string Provider
        {
            get { return m_Provider; }
            set { m_Provider = value; }
        }

        public string DataSource
        {
            get { return m_DataSource; }
            set { m_DataSource = value; }
        }

        public bool PersisteSecurity
        {
            get { return bool.Parse(m_PersistSecurity); }
            set { m_PersistSecurity = value.ToString(); }
        }

        public string User
        {
            get { return m_User; }
            set { m_User = value; }
        }

        public string Password
        {
            get { return m_Pass; }
            set { m_Pass = value; }
        }

        public string Extra
        {
            get { return m_xtra; }
            set { m_xtra = value; }
        }

        private void BuildConnection()
        {
            m_StrConnecion = "Provider=" + m_Provider + ";";
            m_StrConnecion += "Data Source=" + m_DataSource + ";";

            if (m_User != string.Empty)
                m_StrConnecion += "User Id=" + m_User + ";";

            if (m_Pass != string.Empty)
                m_StrConnecion += "Password=" + m_Pass + ";";

            m_StrConnecion += "Persist Security Info=" + m_PersistSecurity + ";";

            if (m_xtra != string.Empty)
                m_StrConnecion += m_xtra + ";";
        }
    }
}
