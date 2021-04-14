using System.Collections;
using System.Collections.Generic;
using TicTacToe;

namespace TicTacToeTests.Game
{
    public class GameEndParameters : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Token>
                {
                    Token.Cross, Token.Cross, Token.Cross,
                    Token.Naught, Token.Naught, Token.Empty,
                    Token.Empty, Token.Empty, Token.Empty
                },
                true
            };
            
            yield return new object[]
            {
                new List<Token>
                {
                    Token.Empty, Token.Naught, Token.Cross,
                    Token.Cross, Token.Naught, Token.Empty,
                    Token.Cross, Token.Naught, Token.Empty
                },
                true
            };
            
            yield return new object[]
            {
                new List<Token>
                {
                    Token.Cross, Token.Empty, Token.Empty,
                    Token.Empty, Token.Cross, Token.Naught,
                    Token.Empty, Token.Naught, Token.Cross
                },
                true
            };
            
            yield return new object[]
            {
                new List<Token>
                {
                    Token.Cross, Token.Naught, Token.Cross,
                    Token.Cross, Token.Naught, Token.Naught,
                    Token.Naught, Token.Cross, Token.Cross
                },
                true
            };
            
            yield return new object[]
            {
                new List<Token>
                {
                    Token.Cross, Token.Naught, Token.Empty,
                    Token.Cross, Token.Naught, Token.Cross,
                    Token.Naught, Token.Empty, Token.Empty
                },
                false
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}