using System;
using System.Collections.Generic;
using System.Text;

namespace Craze.Utility.Exceptions
{
    public class DuplicateEntryException : Exception
    {
        public DuplicateEntryException() : base()
        {

        }

        public DuplicateEntryException(string message) : base(message)
        {

        }

        public DuplicateEntryException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
