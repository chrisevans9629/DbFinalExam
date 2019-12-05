namespace DbFinalExam
{
    public static class Connection
    {
        public static string Database { get; set; } = "CIS625TeamProject";
        public static string Server { get; set; } = "csis615";
        public static string UserName { get; set; } = "cis625user002";
        public static string Password { get; set; } = "";
#if TestDb
        public static string ConnectionStr => @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
#else
        public static string ConnectionStr => 
            $@"Data Source={Server};Initial Catalog={Database};User Id={UserName};Password={Password}";
#endif

    }
}