using System;
using System.Linq;
using Infrastructure.TorreHanoi.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.TorreHanoi.Domain
{
    [TestClass]
    public class PinoUnit
    {
        private const string CategoriaTeste = "Domain/Pino";

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
            Assert.IsNotNull(torre.Torre3);
            Assert.IsNotNull(torre.Torre1);
            Assert.IsNotNull(torre.Torre2);
            Assert.AreEqual(torre.Torre1.Tipo, global::Domain.TorreHanoi.TipoPino.Torre1);
            Assert.AreEqual(torre.Torre3.Tipo, global::Domain.TorreHanoi.TipoPino.Torre3);
            Assert.AreEqual(torre.Torre2.Tipo, global::Domain.TorreHanoi.TipoPino.Torre2);
            Assert.AreEqual(torre.Torre2.Discos.Count, 0);
            Assert.AreEqual(torre.Torre3.Discos.Count, 0);
            Assert.AreEqual(torre.Torre1.Discos.Count, 3);
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void RemoverDisco_Deverar_Retornar_Sucesso()
        {
            var torre = new global::Domain.TorreHanoi.TorreHanoi(3, _mockLogger.Object);

            Assert.IsNotNull(torre);
            Assert.IsNotNull(torre.Torre1);
            Assert.AreEqual(torre.Torre1.Discos.Count, 3);

            torre.Torre1.RemoverDisco();

            Assert.AreEqual(torre.Torre1.Discos.Count, 2);
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void AdicionarDisco_Deverar_Retornar_Sucesso()
        {
            var torre = new global::Domain.TorreHanoi.TorreHanoi(3, _mockLogger.Object);

            Assert.IsNotNull(torre);
            Assert.IsNotNull(torre.Torre2);
            Assert.AreEqual(torre.Torre2.Discos.Count, 0);

            torre.Torre2.AdicionarDisco(torre.Discos.First());

            Assert.AreEqual(torre.Torre2.Discos.Count, 1);
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        [ExpectedException(typeof(Exception), "Não é possivel adicionar um disco maior em cima de um menor")]
        public void AdicionarDisco_Deverar_Retornar_Erro()
        {
            var torre = new global::Domain.TorreHanoi.TorreHanoi(3, _mockLogger.Object);

            Assert.IsNotNull(torre);
            Assert.IsNotNull(torre.Torre2);
            Assert.AreEqual(torre.Torre2.Discos.Count, 0);

            torre.Torre2.AdicionarDisco(torre.Discos.Last());

            Assert.AreEqual(torre.Torre2.Discos.Count, 1);

            torre.Torre2.AdicionarDisco(torre.Discos.First());
        }
    }
}
