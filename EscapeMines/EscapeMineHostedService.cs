using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EscapeMines.Abstractions;
using EscapeMines.Enums;
using EscapeMines.Exceptions;
using EscapeMines.Models;
using EscapeMines.Settings;
using Microsoft.Extensions.Options;

namespace EscapeMines
{
    public class EscapeMineHostedService : BackgroundService
    {

        private readonly IFileService _readFile;
        private readonly IBoardService _boardService;
        private readonly IMineService _mineService;
        private readonly IOptions<PathSetting> _pathSetting;
        private readonly ITurtleService _turtleService;

        public EscapeMineHostedService(IFileService readFile, IBoardService boardService, IMineService mineService, IOptions<PathSetting> pathSetting, ITurtleService turtleService)
        {
            _pathSetting = pathSetting;
            _turtleService = turtleService;
            _readFile = readFile;
            _boardService = boardService;
            _mineService = mineService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            DoWork();
            await Task.CompletedTask;
        }

        public void DoWork()
        {
            List<Mine> mines = new List<Mine>();
            List<string> commandList = new List<string>();
            List<Result> resultList = new List<Result>();

            var textRows = _readFile.GetFile(_pathSetting.Value.GameCommandTextPath);
            if (textRows.Length == 0)
                throw new FileNotFoundException("File not found or file is empty, please check");

            var boardPosition = Array.ConvertAll(textRows[0].Split(' '), int.Parse);
            var minesPositions = textRows[1].Split(' ').ToList();
            var exitGatePosition = Array.ConvertAll(textRows[2].Split(' '), int.Parse);
            var turtlePosition = textRows[3].Split(' ').ToList();

            for (int i = 4; i < textRows.Length; i++)
            {
                commandList.Add(textRows[i]);
            }


            var board = _boardService.CreateBoard(boardPosition[0], boardPosition[1]);

            foreach (var minePosition in minesPositions)
            {
                var mine = _mineService.CreateMine(Convert.ToInt32(minePosition.Split(',')[0]), Convert.ToInt32(minePosition.Split(',')[1]));

                if (!_boardService.CheckIfPointInsideTheBoard(board, mine.Location))
                {
                    throw new MineOutOfBoardException("Mines can not be out of minefield, please correct the command text file and retry!");
                }

                mines.Add(mine);
            }

            var exitGate = new ExitGate(exitGatePosition[0], exitGatePosition[1]);
            var turtle = _turtleService.CreateTurtle(Convert.ToInt32(turtlePosition[0]), Convert.ToInt32(turtlePosition[1]), turtlePosition[2]);

            if (!board.CheckIfPointInside(turtle.Position.Location))
            {
                Console.WriteLine("Turtle can not be out of minefield, please correct the command text file and retry!");
                return;
            }
            foreach (var command in commandList)
            {
                resultList.Add(_turtleService.ApplyCommand(command, exitGate, mines, board,turtle));
                turtle = new Turtle(Convert.ToInt32(turtlePosition[0]), Convert.ToInt32(turtlePosition[1]), turtlePosition[2]);
            }


            foreach (var result in resultList)
            {
                Console.WriteLine(result);
            }
        }
    }
}
