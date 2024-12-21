using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IBRAHIM_JAMA
{
    class Connnection
    {
       public SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=School_System;Integrated Security=True");
       public SqlCommand cmd = new SqlCommand();
       public SqlDataAdapter adapt = new SqlDataAdapter();
    }
}
