using System.Data.SqlClient;

namespace ExcelRead
{
    class ConnDataBase
    {
        //连接字串
       public static string connString = "Data Source=.;Initial Catalog=sk_test;User ID=sa;Pwd=955219";
        //创建connection对象
       public static SqlConnection connection = new SqlConnection(connString);
    }
}
