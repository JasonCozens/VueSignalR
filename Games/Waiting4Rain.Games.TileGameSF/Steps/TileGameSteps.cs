using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TechTalk.SpecFlow;
using Waiting4Rain.Games.TileGame;

namespace Waiting4Rain.Games.TileGameSF.Steps
{
    internal class TileGameContext
    {
        internal TileGameContext()
        {
            Board = new Board();
        }

        public Board Board { get; }
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
            for (int r = 0; r < table.Rows.Count; r++)
            {
                var row = table.Rows[r].Values.First();
                TileGameContext.Board.Add(row.Trim().Split(" ").ToList());
            }
            Debug.WriteLine("STOP");
        }
        
        [Then(@"the board is:")]
        public void ThenTheBoardIs(Table table)
        {
        }
    }
}
