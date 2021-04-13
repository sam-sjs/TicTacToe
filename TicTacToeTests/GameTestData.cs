using System.Collections;
using System.Collections.Generic;

namespace TicTacToeTests
{
    public class GameTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Win top row cross
            yield return new object[] {"1,1", "2,1", "1,2", "2,2", "1,3"};
            // Win vertical centre naught
            yield return new object[] {"1,1", "1,2", "2,1", "2,2", "1,3", "3,2"};
            // Win diagonal 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}