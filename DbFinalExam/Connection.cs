namespace DbFinalExam
{
    public static class Connection
    {
        public static string Database { get; set; } 
        public static string Server { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string ConnectionStr => 
            $@"Data Source={Server};Initial Catalog={Database};User Id={UserName};Password={Password}";
    }
}