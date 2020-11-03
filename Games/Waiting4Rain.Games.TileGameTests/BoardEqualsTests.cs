using System;
using System.Collections.Generic;
using Waiting4Rain.Games.TileGame;
using Xunit;

namespace Waiting4Rain.Games.TileGameTests
{
    public class BoardEqualsTests
    {
        [Fact]
        public void Board_NotEqual_ToNull()
        {
            var board = new Board();

            Assert.False(board.Equals(null));
            Assert.False(board == null);
        }

        [Fact]
        public void Board_Equals_IsReflexive()
        {
            var board = new Board();

            Assert.True(board.Equals(board));
#pragma warning disable CS1718 // Comparison made to same variable
            Assert.True(board == board);
#pragma warning restore CS1718 // Comparison made to same variable
        }

        // Make this a theory.
        [Fact]
        public void Boards_Equals_IsSymmetric()
        {
            var boardA = new Board();
            var boardB = new Board();

            Assert.True(boardA.Equals(boardB));
            Assert.True(boardB.Equals(boardA));
            Assert.True(boardA == boardB);
            Assert.True(boardB == boardA);
        }

        // Make this a theory.
        [Fact]
        public void Boards_Equals_IsTransitive()
        {
            var boardA = new Board();
            var boardB = new Board();
            var boardC = new Board();

            Assert.True(boardA.Equals(boardB));
            Assert.True(boardB.Equals(boardC));
            Assert.True(boardA == boardB);
            Assert.True(boardB == boardC);
        }

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
