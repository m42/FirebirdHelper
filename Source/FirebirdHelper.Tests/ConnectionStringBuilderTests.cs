using m42.FirebirdHelper;
using System;
using Xunit;

namespace FirebirdHelper.Tests
{
    public class ConnectionStringBuilderTests
    {
        [Fact]
        public void Ctor_ThrowsArgumentNullException_WhenDatabaseParameterIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ConnectionStringBuilder(null));

            Assert.Equal("database", exception.ParamName);
        }

        [Fact]
        public void Ctor_ThrowsArgumentNullException_WhenDatabaseParameterIsEmptyString()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new ConnectionStringBuilder(string.Empty));

            Assert.Equal("database", exception.ParamName);
        }

        [Fact]
        public void Ctor_SetsDatabase()
        {
            var sut = new ConnectionStringBuilder(@"c:\data\database.fdb");
            Assert.Equal(@"c:\data\database.fdb", sut.Database);
        }

        [Fact]
        public void GetConnectionString_ReturnsCompleteConnectionString()
        {
            var connectionString = new ConnectionStringBuilder(@"c:\data\database.fdb")
                .WithDataSource("server")
                .WithUsername("MyUser")
                .WithPassword("MyP@ssword!")
                .WithRole("RDB$ADMIN")
                .WithPort(3051)
                .GetConnectionString();

            var expected =
                @"Database=c:\data\database.fdb;" +
                "DataSource=server;" +
                "User=MyUser;" +
                "Password=MyP@ssword!;" +
                "Role=RDB$ADMIN;" +
                "Port=3051;" +
                "Dialect=3;" +
                "Charset=ISO8859_1;" +
                "Connection lifetime=15;" +
                "Pooling=True;" +
                "MinPoolSize=0;" +
                "MaxPoolSize=50;" +
                "Packet Size=8192;" +
                "ServerType=0";

            Assert.Equal(expected, connectionString);
        }

        [Fact]
        public void Charset_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Equal("ISO8859_1", sut.Charset);
        }

        [Fact]
        public void ConnectionLifetime_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Equal(15, sut.ConnectionLifetime);
        }

        [Fact]
        public void DataSource_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Equal("localhost", sut.DataSource);
        }

        [Fact]
        public void Dialect_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Equal(3, sut.Dialect);
        }

        [Fact]
        public void MaxPoolSize_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Equal(50, sut.MaxPoolSize);
        }

        [Fact]
        public void MinPoolSize_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Equal(0, sut.MinPoolSize);
        }

        [Fact]
        public void PacketSize_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Equal(8192, sut.PacketSize);
        }

        [Fact]
        public void Password_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Equal("masterkey", sut.Password);
        }

        [Fact]
        public void Pooling_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.True(sut.Pooling);
        }

        [Fact]
        public void Port_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Equal(3050, sut.Port);
        }

        [Fact]
        public void Role_HasNoDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Null(sut.Role);
        }

        [Fact]
        public void ServerType_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Equal(ServerType.Standard, sut.ServerType);
        }

        [Fact]
        public void Username_HasDefaultValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            Assert.Equal("SYSDBA", sut.Username);
        }

        [Fact]
        public void WithCharset_SetsPropertyValue_WhenNotEmpty()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithCharset("NONE");
            sut.WithCharset(string.Empty);
            Assert.Equal("NONE", sut.Charset);
        }

        [Fact]
        public void WithConnectionLifetime_SetsPropertyValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithConnectionLifetime(30);
            Assert.Equal(30, sut.ConnectionLifetime);
        }

        [Fact]
        public void WithDataSource_SetsPropertyValue_WhenNotEmpty()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithDataSource("server");
            sut.WithDataSource(string.Empty);
            Assert.Equal("server", sut.DataSource);
        }

        [Fact]
        public void WithDialect_SetsPropertyValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithDialect(1);
            Assert.Equal(1, sut.Dialect);
        }

        [Fact]
        public void WithMaxPoolSize_SetsPropertyValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithMaxPoolSize(100);
            Assert.Equal(100, sut.MaxPoolSize);
        }

        [Fact]
        public void WithMinPoolSize_SetsPropertyValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithMinPoolSize(10);
            Assert.Equal(10, sut.MinPoolSize);
        }

        [Fact]
        public void WithPacketSize_SetsPropertyValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithPacketSize(4096);
            Assert.Equal(4096, sut.PacketSize);
        }

        [Fact]
        public void WithPassword_SetsPropertyValue_WhenNotEmpty()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithPassword("MyP@ssword!");
            sut.WithPassword(string.Empty);
            Assert.Equal("MyP@ssword!", sut.Password);
        }

        [Fact]
        public void WithPooling_SetsPropertyValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithPooling();
            Assert.True(sut.Pooling);
        }

        [Fact]
        public void WithoutPooling_SetsPropertyValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithoutPooling();
            Assert.False(sut.Pooling);
        }

        [Fact]
        public void WithPort_SetsPropertyValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithPort(3051);
            Assert.Equal(3051, sut.Port);
        }

        [Fact]
        public void WithRole_SetsPropertyValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithRole("RDB$ADMIN");
            Assert.Equal("RDB$ADMIN", sut.Role);
        }

        [Fact]
        public void WithServerTypeEmbedded_SetsPropertyValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithServerTypeEmbedded();
            Assert.Equal(ServerType.Embedded, sut.ServerType);
        }

        [Fact]
        public void WithServerTypeStandard_SetsPropertyValue()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithServerTypeStandard();
            Assert.Equal(ServerType.Standard, sut.ServerType);
        }

        [Fact]
        public void WithUsername_SetsPropertyValue_WhenNotEmpty()
        {
            var sut = new ConnectionStringBuilder("n/a");
            sut.WithUsername("MyUser");
            sut.WithUsername(string.Empty);
            Assert.Equal("MyUser", sut.Username);
        }
    }
}
