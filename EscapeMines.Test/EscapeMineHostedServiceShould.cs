using System.Collections.Generic;
using EscapeMines.Abstractions;
using EscapeMines.Commands;
using EscapeMines.Enums;
using EscapeMines.Exceptions;
using EscapeMines.Models;
using EscapeMines.Settings;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;


namespace EscapeMines.Test
{
    public class EscapeMineHostedServiceShould
    {
        private readonly Mock<IMineService> _mockMineService;
        private readonly Mock<IFileService> _mockFileService;
        private readonly Mock<IBoardService> _mockBoardService;
        private readonly Mock<ITurtleService> _mockTurtleService;
        private readonly EscapeMineHostedService _sut;
        private Move _sutMove;

        public EscapeMineHostedServiceShould()
        {
            IOptions<PathSetting> pathSetting = Options.Create(new PathSetting() { GameCommandTextPath = "C:\\Case\\EscapeMines\\Settings.txt" });

            _mockMineService = new Mock<IMineService>();
            _mockFileService = new Mock<IFileService>();
            _mockBoardService = new Mock<IBoardService>();
            _mockTurtleService = new Mock<ITurtleService>();

            _sut = new EscapeMineHostedService(_mockFileService.Object, _mockBoardService.Object, _mockMineService.Object, pathSetting, _mockTurtleService.Object);
        }


        [Test]
        public void ThrowMineOutOfBoardExceptionWhenMineIsOutOfBoard()
        {

            var stringArray = new List<string>()
            {
                "4 3", "1,2 3,0 3,2", "2 3", "1 0 N", "R M L M M M", "R M M M M M"
            };

            _mockFileService.Setup(a => a.GetFile(It.IsAny<string>()))
                .Returns(stringArray.ToArray());

            _mockBoardService.Setup(a => a.CreateBoard(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new Board(3, 4));

            _mockMineService.Setup(a => a.CreateMine(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new Mine(5, 6));

            Assert.That(() => _sut.DoWork(), Throws.TypeOf<MineOutOfBoardException>());
        }

        [Test]
        public void ThrowFileNotFoundExceptionWhenFilePathIsInvalidOrFileIsEmpty()
        {
            _mockFileService.Setup(a => a.GetFile(It.IsAny<string>()))
                .Returns(new string[0]);

            Assert.That(() => _sut.DoWork(), Throws.TypeOf<FileNotFoundException>());

        }

        [Test]
        public void ThrowTurtleOutOfBoardExceptionWhenTurtleMoveToOutOfBoard()
        {
            _sutMove = new Move(new Board(3, 4));

            Assert.That(() => _sutMove.Apply(new Position() { Heading = Directions.E, Location = new Point() { X = 5, Y = 4 } }), Throws.TypeOf<TurtleOutOfBoardException>());

        }
    }
}