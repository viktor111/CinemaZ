using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test
{
    [TestClass]
    public class DbContextTest : DbContextSqlLite
    {
        [TestMethod]
        public async Task  DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.IsTrue( await _dbContext.Database.CanConnectAsync());
        }
    }
}