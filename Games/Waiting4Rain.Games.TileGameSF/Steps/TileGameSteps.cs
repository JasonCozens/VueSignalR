using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TechTalk.SpecFlow;

namespace Waiting4Rain.Games.TileGameSF.Steps
{
    internal class TileGameContext
    {

    }


    [Binding]
    public class TileGameSteps
    {

        [Given(@"the final position is:")]
        public void GivenTheFinalPositionIs(Table table)
        {
            var board = new List<List<string>>();
            for (int r = 0; r < table.Rows.Count; r++)
            {
                var row = table.Rows[r].Values.First();
                board.Add(row.Trim().Split(" ").ToList());
            }
            Debug.WriteLine("STOP");
        }
        
        [Then(@"the board is:")]
        public void ThenTheBoardIs(Table table)
        {
        }
    }
}
