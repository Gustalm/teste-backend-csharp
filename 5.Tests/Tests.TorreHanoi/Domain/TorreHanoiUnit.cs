using System;
using System.Linq;
using Infrastructure.TorreHanoi.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.TorreHanoi.Domain
{
    [TestClass]
    public class TorreHanoiUnit
    {
        private const string CategoriaTeste = "Domain/TorreHanoi";

        private Mock<ILogger> _mockLogger;

        [TestInitialize]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger>();
            _mockLogger.Setup(s => s.Logar(It.IsAny<string>(), It.IsAny<TipoLog>()));
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void Construtor_Deve_Retornar_Sucesso()
        {
            var torre = new global::Domain.TorreHanoi.TorreHanoi(3, _mockLogger.Object);

            Assert.IsNotNull(torre);
            Assert.AreEqual(torre.Torre1.Discos.Count, 3);
            Assert.AreEqual(torre.Torre2.Discos.Count, 0);
            Assert.AreEqual(torre.Torre3.Discos.Count, 0);
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void Processar_Deverar_Retornar_Sucesso()
        {
            var torre = new global::Domain.TorreHanoi.TorreHanoi(3, _mockLogger.Object);
            var ordemDiscosEsperada = torre.Discos.OrderByDescending(x => x.Id);

            torre.Processar();

            Assert.AreEqual(torre.Torre1.Discos.Count, 0);
            Assert.AreEqual(torre.Torre2.Discos.Count, 0);
            Assert.AreEqual(torre.Torre3.Discos.Count, 3);
            Assert.IsTrue(ordemDiscosEsperada.SequenceEqual(torre.Discos));
        }
    }
}
