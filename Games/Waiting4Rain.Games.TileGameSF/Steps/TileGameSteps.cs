using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using TechTalk.SpecFlow;
using Waiting4Rain.Games.TileGame;
using FluentAssertions;
using FluentAssertions.Common;

namespace Waiting4Rain.Games.TileGameSF.Steps
{
    internal class TileGameContext
    {
        internal TileGameContext()
        {
            Board = new Board();
        }

        public Board Board { get; set; }
    }

    internal class SpecFlowBoard : Board
    {
        internal SpecFlowBoard(Table table)
        {
            for (int r = 0; r < table.Rows.Count; r++)
            {
                var row = table.Rows[r].Values.First();
                Add(row.Trim().Split(" ").ToList());
            }
        }
    }

    [Binding]
    public class TileGameSteps
    {
        public TileGameSteps()
        {
            TileGameContext = new TileGameContext();
        }

        internal TileGameContext TileGameContext { get; }

        [Given(@"the final position is:")]
        public void GivenTheFinalPositionIs(Table table)
        {
            TileGameContext.Board = new SpecFlowBoard(table);
        }
        
        [Then(@"the board is:")]
        public void ThenTheBoardIs(Table table)
        {
            var finalBoard = new SpecFlowBoard(table);
            finalBoard.Should().Equal(TileGameContext.Board);
        }
    }
}
