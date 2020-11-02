using System;
using System.Collections.Generic;
using Waiting4Rain.Games.TileGame;
using Xunit;

namespace Waiting4Rain.Games.TileGameTests
{
    public class BoardTests
    {
        [Fact]
        public void NewBoards_Equals_NewBoardsAreEqual()
        {
            var boardA = new Board();
            var boardB = new Board();

            Assert.True(boardA.Equals(boardB));
            Assert.True(boardB.Equals(boardA));
            Assert.True(boardA == boardB);
            Assert.True(boardB == boardA);
        }

        [Fact]
        public void NewBoardANewBoardB1Item_Equals_NewBoardsAreEqual()
        {
            var boardA = new Board();
            var boardB = new Board
            {
                new List<string> { "T1" }
            };

            Assert.NotEqual(boardA, boardB);
            Assert.NotEqual(boardB, boardA);
            Assert.True(boardA != boardB);
            Assert.True(boardB != boardA);
        }

        [Fact]
        public void BothBoardsWith1Item_Equals_NewBoardsAreEqual()
        {
            var boardA = new Board
            {
                new List<string> { "T1" }
            };
            var boardB = new Board
            {
                new List<string> { "T1" }
            };

            Assert.Equal(boardA, boardB);
            Assert.Equal(boardB, boardA);
            Assert.True(boardA == boardB);
            Assert.True(boardB == boardA);
        }

        [Fact]
        public void ManyItems_Equals_NewBoardsAreEqual()
        {
            var boardA = new Board
            {
                new List<string> { "T1", "T2" },
                new List<string> { "T3", "T4" }
            };
            var boardB = new Board
            {
                new List<string> { "T1", "T2" },
                new List<string> { "T3", "T4" }
            };

            Assert.True(boardA == boardB);
            Assert.Equal(boardB, boardA);
            Assert.True(boardA == boardB);
            Assert.True(boardB == boardA);
        }

        [Fact]
        public void ManyItems_NotEquals_NewBoardsAreEqual()
        {
            var boardA = new Board
            {
                new List<string> { "T1", "T2" },
                new List<string> { "T3", "T4" }
            };
            var boardB = new Board
            {
                new List<string> { "T1", "T2" },
                new List<string> { "T5", "T4" }
            };

            Assert.NotEqual(boardA, boardB);
            Assert.NotEqual(boardB, boardA);
            Assert.True(boardA != boardB);
            Assert.True(boardB != boardA);
        }
    }
}
