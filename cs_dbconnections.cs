using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMRP
{
    class cs_dbconnections
    {
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BasicMRP.Properties.Settings.basicmrpdbConnectionString"].ConnectionString);
        //public static SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=E:\CS PROJELER\BASICMRP\BasicMRPWorking\BasicMRP\basicmrpdb.mdf;Integrated Security = True");
    }
}
