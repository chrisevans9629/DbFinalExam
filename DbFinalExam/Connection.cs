namespace DbFinalExam
{
    public static class Connection
    {
        public static string Database { get; set; } = "CIS625TeamProject";
        public static string Server { get; set; } = "csis615";
        public static string UserName { get; set; } = "cis615user002";
        public static string Password { get; set; } = "";
        public static string ConnectionStr => 
            $@"Data Source={Server};Initial Catalog={Database};User Id={UserName};Password={Password}";
    }
}