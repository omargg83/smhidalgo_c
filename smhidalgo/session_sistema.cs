using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smhidalgo
{
    class session_sistema
    {
        private static string connectionString_tmp = "";
        private static int idpersona_tmp = 0;
        private static string nombre_tmp = "";
        private static int idtienda_tmp = 1;

        public static string nombre_sis = "SMHIDALGO";


        public static string connectionString
        {
            get { return connectionString_tmp; }
            set { connectionString_tmp = value; }
        }

        public static string nombre
        {
            get { return nombre_tmp; }
            set { nombre_tmp = value; }
        }

        public static int idpersona
        {
            get { return idpersona_tmp; }
            set { idpersona_tmp = value; }
        }

        public static int idtienda
        {
            get { return idtienda_tmp; }
            set { idtienda_tmp = value; }
        }

    }
}
