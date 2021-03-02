using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test
{
    [TestClass]
    public class DbContextSqlLiteTest : DbContextSqlLite
    {
        [TestMethod]
        public async Task  DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.IsTrue( await _dbContext.Database.CanConnectAsync());
        }
    }
}