using System;
using System.Text;

namespace m42.FirebirdHelper
{
    public class ConnectionStringBuilder
    {
        public string Charset { get; private set; } = "ISO8859_1";
        public int ConnectionLifetime { get; private set; } = 15;
        public string Database { get; }
        public string DataSource { get; private set; } = "localhost";
        public int Dialect { get; private set; } = 3;
        public int MaxPoolSize { get; private set; } = 50;
        public int MinPoolSize { get; private set; } = 0;
        public int PacketSize { get; private set; } = 8192;
        public string Password { get; private set; } = "masterkey";
        public bool Pooling { get; private set; } = true;
        public int Port { get; private set; } = 3050;
        public string Role { get; private set; }
        public ServerType ServerType { get; private set; } = ServerType.Standard;
        public string Username { get; private set; } = "SYSDBA";

        public ConnectionStringBuilder(string database)
        {
            if (string.IsNullOrEmpty(database))
                throw new ArgumentNullException(nameof(database));

            Database = database;
        }

        public string GetConnectionString()
        {
            var connectionString = new StringBuilder();
            connectionString.Append($"Database={Database};");
            connectionString.Append($"DataSource={DataSource};");
            connectionString.Append($"User={Username};");
            connectionString.Append($"Password={Password};");
            connectionString.Append($"Role={Role};");
            connectionString.Append($"Port={Port};");
            connectionString.Append($"Dialect={Dialect};");
            connectionString.Append($"Charset={Charset};");
            connectionString.Append($"Connection lifetime={ConnectionLifetime};");
            connectionString.Append($"Pooling={Pooling};");
            connectionString.Append($"MinPoolSize={MinPoolSize};");
            connectionString.Append($"MaxPoolSize={MaxPoolSize};");
            connectionString.Append($"Packet Size={PacketSize};");
            connectionString.Append($"ServerType={(int)ServerType}");
            return connectionString.ToString();
        }

        public ConnectionStringBuilder WithCharset(string charset = "ISO8859_1")
        {
            if (!string.IsNullOrEmpty(charset))
                Charset = charset;

            return this;
        }

        public ConnectionStringBuilder WithConnectionLifetime(int connectionLifetime = 15)
        {
            ConnectionLifetime = connectionLifetime;
            return this;
        }

        public ConnectionStringBuilder WithDataSource(string dataSource = "localhost")
        {
            if (!string.IsNullOrEmpty(dataSource))
                DataSource = dataSource;

            return this;
        }

        public ConnectionStringBuilder WithDialect(int dialect = 3)
        {
            Dialect = dialect;
            return this;
        }

        public ConnectionStringBuilder WithMaxPoolSize(int maxPoolSize = 50)
        {
            MaxPoolSize = maxPoolSize;
            return this;
        }

        public ConnectionStringBuilder WithMinPoolSize(int minPoolSize = 0)
        {
            MinPoolSize = minPoolSize;
            return this;
        }

        public ConnectionStringBuilder WithPooling()
        {
            Pooling = true;
            return this;
        }

        public ConnectionStringBuilder WithoutPooling()
        {
            Pooling = false;
            return this;
        }

        public ConnectionStringBuilder WithPacketSize(int packetSize = 8192)
        {
            PacketSize = packetSize;
            return this;
        }

        public ConnectionStringBuilder WithPassword(string password = "masterkey")
        {
            if (!string.IsNullOrEmpty(password))
                Password = password;

            return this;
        }

        public ConnectionStringBuilder WithPort(int port = 3050)
        {
            Port = port;
            return this;
        }

        public ConnectionStringBuilder WithRole(string role)
        {
            Role = role;
            return this;
        }

        public ConnectionStringBuilder WithServerTypeEmbedded()
        {
            ServerType = ServerType.Embedded;
            return this;
        }

        public ConnectionStringBuilder WithServerTypeStandard()
        {
            ServerType = ServerType.Standard;
            return this;
        }

        public ConnectionStringBuilder WithUsername(string username = "SYSDBA")
        {
            if (!string.IsNullOrEmpty(username))
                Username = username;

            return this;
        }

    }
}
